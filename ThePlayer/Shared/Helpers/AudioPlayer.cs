using Microsoft.JSInterop;
using System.Threading.Tasks;
using static ThePlayer.Shared.Helpers.ClientFileAccess;

namespace ThePlayer.Shared.Helpers
{
    // requires audioPlayer.js
    public class AudioPlayer : JSModuleBase
    {
        public AudioPlayer(IJSRuntime js) : base(js, "./js/audioPlayer.js")
        {
        }

        public async void Play()
        {
            await InvokeAsync<object>("audioPlayer.play");
        }

        public async ValueTask<IJSObjectReference> PlayAsync(ClientFile file)
        {
            return await InvokeAsync<IJSObjectReference>("playAudioFile", file.Name);
        }

        public async void Pause()
        {
            await InvokeAsync<object>("audioPlayer.pause");
        }

        public async void Stop()
        {
            await InvokeAsync<object>("audioPlayer.stop");
        }

        public async void Repeat()
        {
            await InvokeAsync<object>("audioPlayer.repeat");
        }

        public async ValueTask<byte[]> DecodeAudioFileAsync(ClientFile file)
        {
            return await InvokeAsync<byte[]>("decodeAudioFile", file.Name);
        }


        public async ValueTask<IJSObjectReference> PlayAudioDataAsync(byte[] data)
        {
            return await InvokeAsync<IJSObjectReference>("playAudioData", data);
        }

    }
}
