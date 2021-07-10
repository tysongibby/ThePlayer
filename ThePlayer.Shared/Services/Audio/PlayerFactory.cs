namespace ThePlayer.Shared.Services.Audio
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer Create(bool hasMediaFoundationSupport)
        {
            IPlayer player = CSCorePlayer.Instance;
            player.HasMediaFoundationSupport = hasMediaFoundationSupport;

            return player;
        }
    }
}
