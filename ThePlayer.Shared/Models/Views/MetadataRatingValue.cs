
namespace ThePlayer.Shared.Models.Views
{
    public class MetadataRatingValue
    {
        private int value;
        private bool isValueChanged;


        public bool IsValueChanged
        {
            get { return this.isValueChanged; }
        }
  
        public int Value
        {
            get { return this.value; }

            set
            {
                this.value = value;
                this.isValueChanged = true;
                this.OnPropertiesChanged();
            }
        }
        public MetadataRatingValue()
        {
        }

        public MetadataRatingValue(int value)
        {
            this.value = value;
            this.OnPropertiesChanged();
        }
        private void OnPropertiesChanged()
        {
            //TODO: MVVM Prism Bindable properties update to?
            //RaisePropertyChanged(nameof(this.Value));
            //RaisePropertyChanged(nameof(this.IsValueChanged));
        }
    }
}
