using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ClientFileApi;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace ClientPages.Shared
{
    public partial class Audio
    {
        [Parameter, EditorRequired]
        public ClientFileAccess.ClientFile File { get; set; } = default !;
        private WaveFormSvgData waveFormSvgData;
        IJSObjectReference playing;
        CancellationTokenSource disposalCts = new();

        //protected override async Task OnInitializedAsync()
        //{
        //    // get file wave form data
        //    byte[] waveFormData = await ClientFileAccess.DecodeAudioFileAsync(File);
        //    // generate svg wave form
        //    await Task.Run(() =>
        //    {
        //        waveFormSvgData = GenerateWaveformSvg(waveFormData);
        //    },
        //    disposalCts.Token);
        //}


        public void Dispose()
        {
            disposalCts.Cancel();
            GC.SuppressFinalize(this);
        }

        public async Task TogglePlayingAudioAsync()
        {
            if (playing is null)
            {
                // Toggle to play
                playing = await ClientFileAccess.PlayAudioFileAsync(File);
            }
            else
            {
                // Toggle to stop
                await playing.InvokeVoidAsync("stop");
                await playing.DisposeAsync();
                playing = null;
            }
        }

        private WaveFormSvgData GenerateWaveformSvg(byte[] samplesData)
        {
            // Generates repeated strings like "M 0 38 v 8"
            var audioDataFloat = MemoryMarshal.Cast<byte, float>(samplesData);
            var width = 400;
            var height = 64;
            var topPath = new StringBuilder(15 * width);
            var botPath = new StringBuilder(15 * width);
            var numSamples = audioDataFloat.Length;
            var samplesPerColumn = numSamples / width;
            var minusHalfHeight = -height / 2;
            var midpointHeightStr = ((int)(height * 0.6)).ToString();
            for (var x = 0; x < width; x++)
            {
                var chunk = audioDataFloat.Slice(x * samplesPerColumn, samplesPerColumn);
                var min = chunk[0];
                var max = chunk[0];
                var sampleResolution = 8;
                for (var i = sampleResolution; i < chunk.Length; i += sampleResolution)
                {
                    ref var sample = ref chunk[i];
                    if (sample < min)
                        min = sample;
                    if (sample > max)
                        max = sample;
                }

                topPath.Append('M').Append(x).Append(' ').Append(midpointHeightStr).Append('v').Append((int)(minusHalfHeight * max));
                botPath.Append('M').Append(x).Append(' ').Append(midpointHeightStr).Append('v').Append((int)(minusHalfHeight * min / 2));
            }

            return new WaveFormSvgData(topPath.ToString(), botPath.ToString());
        }

        public record WaveFormSvgData(string TopPath, string BottomPath);
    }
}