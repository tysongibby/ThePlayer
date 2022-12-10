using System;
using System.Collections.Generic;
using System.Text;

namespace ThePlayerComponents.Audio
{
    internal class PlayerFactory : IPlayerFactory
    {
        public IPlayer Create(bool hasMediaFoundationSupport)
        {
            IPlayer player = CSCorePlayer.Instance;
            player.HasMediaFoundationSupport = hasMediaFoundationSupport;

            return player;
        }
    }
}
