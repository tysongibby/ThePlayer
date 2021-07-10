using ThePlayer.Shared.Models;
using ThePlayer.Shared.Services.LastFm.Api;
using ThePlayer.Shared.Models.Views;
using System;
using System.Threading.Tasks;

namespace ThePlayer.Shared.Services.LastFm.Api.ScrobblingService
{
    public interface IScrobblingService
    {
        SignInState SignInState { get; set; }

        string Username { get; set; }

        string Password { get; set; }


        event Action<SignInState> SignInStateChanged;

        Task SignIn();

        void SignOut();

        Task SendTrackLoveAsync(TrackViewModel track, bool love);
    }
}
