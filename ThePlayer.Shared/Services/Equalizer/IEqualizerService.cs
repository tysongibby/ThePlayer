using ThePlayer.Shared.Services.Audio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThePlayer.Shared.Services.Equalizer
{
    public interface IEqualizerService
    {
        Task<List<EqualizerPreset>> GetPresetsAsync();
        Task<EqualizerPreset> GetSelectedPresetAsync();
    }
}
