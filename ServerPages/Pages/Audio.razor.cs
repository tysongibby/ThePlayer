using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using ServerPages;
using ServerPages.Shared;
using MudBlazor;
using System.Threading;
using ServerPages.Shared.Components;
using ClientFileApi;
using System.Runtime.InteropServices;
using System.Text;

namespace ServerPages.Pages
{
    public partial class Audio
    {
        [Parameter, EditorRequired]
        public ClientFileAccess.ClientFile File { get; set; } = default !;
        IJSObjectReference playing;
        CancellationTokenSource disposalCts = new();
        //public AudioPlayer AudioPlayer { get; set; }

        //private WaveFormSvgData waveFormSvgData;

        //protected override async Task OnInitializedAsync()
        //{
        //    // get file wave form data
        //    byte[] waveFormData = await AudioPlayer.DecodeAudioFileAsync(File);
        //    // generate svg wave form
        //    await Task.Run(() =>
        //    {
        //        waveFormSvgData = GenerateWaveformSvg(waveFormData);
        //    }, 
        //    disposalCts.Token);
        //}

        public async Task TogglePlayingAudioAsync()
        {
            if (playing is null)
            {
                // Toggle to play
                playing = await Player.PlayAsync(File);
            }
            else
            {
                // Toggle to stop
                await playing.InvokeVoidAsync("stop");
                await playing.DisposeAsync();
                playing = null;
            }
        }

        public void Dispose()
        {
            disposalCts.Cancel();
            GC.SuppressFinalize(this);
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
                    if (sample < min) min = sample;
                    if (sample > max) max = sample;
                }

                topPath.Append('M').Append(x).Append(' ').Append(midpointHeightStr).Append('v').Append((int)(minusHalfHeight * max));
                botPath.Append('M').Append(x).Append(' ').Append(midpointHeightStr).Append('v').Append((int)(minusHalfHeight * min / 2));
            }

            return new WaveFormSvgData(topPath.ToString(), botPath.ToString());
        }

        public record WaveFormSvgData(string TopPath, string BottomPath);


    }
}