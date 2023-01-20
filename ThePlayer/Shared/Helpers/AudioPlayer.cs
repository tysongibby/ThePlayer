using Microsoft.JSInterop;


namespace ThePlayer.Shared.Helpers
{
    // requires audioPlayer.js
    public class AudioPlayer : JSModuleBase
    {
        public AudioPlayer(IJSRuntime js) : base(js, "/js/audioPlayer.js")
        {
        }

        public async void Play()
        {
            await InvokeAsync<object>("audioPlayer.play");
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

    }
}
