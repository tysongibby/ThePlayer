using System;
using System.Collections.Generic;
using System.Text;

namespace ThePlayerComponents.Audio
{
    public interface IPlayerFactory
    {
        IPlayer Create(bool hasMediaFoundationSupport);
    }
}
