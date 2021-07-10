﻿using System;

namespace Dopamine.Services.Lyrics
{
    public class LyricsLineViewModel
    {
        private TimeSpan time;
        private string text;
        private bool isTimed;
        private bool isHighlighted;
      
        public TimeSpan Time
        {
            get { return this.time; }
        }

        public string Text
        {
            get { return this.text; }
        }

        public bool IsTimed
        {
            get { return this.isTimed; }
        }

        public bool IsHighlighted
        {
            get { return this.isTimed & this.isHighlighted; }
            set { this.isHighlighted = value; }
        }
     
        public LyricsLineViewModel(TimeSpan time, string text)
        {
            this.time = time;
            this.text = text;

            this.isTimed = true;
        }

        public LyricsLineViewModel(string text)
        {
            this.time = TimeSpan.Zero;
            this.text = text;

            this.isTimed = false;
        }
    }
}