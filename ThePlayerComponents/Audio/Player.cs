using System;
using System.Collections.Generic;
using System.Text;

namespace ThePlayerComponents.Audio
{
    internal class Player : IPlayer, IDisposable
    {
        // Singleton
        private static Player? instance;

        // IPlayer
        private string? filename;
        private bool canPlay;
        private bool canPause;
        private bool canStop;

        public string? Filename
        {
            get { return this.filename; }
        }

        public bool CanPlay
        {
            get { return this.canPlay; }
        }

        public bool CanPause
        {
            get { return this.canPause; }
        }

        public bool CanStop
        {
            get { return this.canStop; }
        }

        public bool HasMediaFoundationSupport { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler? PlaybackFinished;

        public void ApplyFilter(double[] filterValues)
        {
            throw new NotImplementedException();
        }

        public void ApplyFilterValue(int index, double value)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IList<AudioDevice> GetAllAudioDevices()
        {
            throw new NotImplementedException();
        }

        public TimeSpan GetCurrentTime()
        {
            throw new NotImplementedException();
        }

        public TimeSpan GetTotalTime()
        {
            throw new NotImplementedException();
        }

        public float GetVolume()
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Play(string filename, AudioDevice audioDevice)
        {
            throw new NotImplementedException();
        }

        public bool Resume()
        {
            throw new NotImplementedException();
        }

        public void SetPlaybackSettings(int latency, bool eventMode, bool exclusiveMode, double[] filterValues, bool useAllAvailableChannels)
        {
            throw new NotImplementedException();
        }

        public void SetVolume(float volume)
        {
            throw new NotImplementedException();
        }

        public void Skip(int gotoSeconds)
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void SwitchAudioDevice(AudioDevice audioDevice)
        {
            throw new NotImplementedException();
        }
    }
}
