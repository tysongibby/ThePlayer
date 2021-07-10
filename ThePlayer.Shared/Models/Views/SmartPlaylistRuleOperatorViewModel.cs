﻿namespace ThePlayer.Shared.Models.Views
{
    public class SmartPlaylistRuleOperatorViewModel
    {
        private string displayName;
        private string name;

        public SmartPlaylistRuleOperatorViewModel(string displayName, string name)
        {
            this.displayName = displayName;
            this.name = name;
        }

        public string DisplayName
        {
            get { return this.displayName; }
            set { this.displayName = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public override string ToString()
        {
            return this.displayName;
        }

        public override bool Equals(object obj)
        {
            var item = obj as SmartPlaylistRuleOperatorViewModel;

            if(item == null)
            {
                return false;
            }

            return this.name.Equals(((SmartPlaylistRuleOperatorViewModel)obj).name);
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode();
        }
    }
}
