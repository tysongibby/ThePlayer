using Microsoft.JSInterop;
using System.IO;
using System;
using System.Threading.Tasks;
using static ClientFileApi.ClientFileAccess;

namespace ClientFileApi
{
    // requires audioPlayer.js
    public class AudioPlayer : JSModuleBase
    {
        public AudioPlayer(IJSRuntime js) : base(js, "./_content/ClientFileApi/js/audioPlayer.js")
        {
        }

        //public async void Play()
        //{
        //    await InvokeAsync<object>("audioPlayer.play");
        //}
        //public async void Pause()
        //{
        //    await InvokeAsync<object>("audioPlayer.pause");
        //}

        //public async void Stop()
        //{
        //    await InvokeAsync<object>("audioPlayer.stop");
        //}

        //public async void Repeat()
        //{
        //    await InvokeAsync<object>("audioPlayer.repeat");
        //}

        public async ValueTask<IJSObjectReference> PlayAsync(ClientFile file)
        {
            return await InvokeAsync<IJSObjectReference>("playAudioFile", file.Name);
        }



        public async ValueTask<IJSObjectReference> PlayAudioDataAsync(byte[] data)
        {
            return await InvokeAsync<IJSObjectReference>("playAudioData", data);
        }

        public async ValueTask<byte[]> DecodeAudioFileAsync(ClientFile file)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            try
            {
                return await InvokeAsync<byte[]>("decodeAudioFile", file.Name);
            }
            catch (Exception e)
            {
                throw new FileNotFoundException(e.Message, e);
            }
        }

    }
}
