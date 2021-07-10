namespace ThePlayer.Shared.Services.Audio
{
    public interface IPlayerFactory
    {
       IPlayer Create(bool hasMediaFoundationSupport);
    }
}