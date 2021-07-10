
namespace ThePlayer.Shared.Models.Views
{
    public class MetadataArtworkValue
    {
        private byte[] value;
        private bool isValueChanged;
  
        public bool IsValueChanged
        {
            get { return this.isValueChanged; }
        }
   
        public byte[] Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                this.isValueChanged = true;
                this.OnPropertiesChanged();
            }
        }
 
        public MetadataArtworkValue()
        {
        }

        public MetadataArtworkValue(byte[] value)
        {
            this.value = value;
            this.OnPropertiesChanged();
        }
  
        private void OnPropertiesChanged()
        {
            //TODO: MetadataArtworkValue.cs line 37 Prism MVVM UI properts update code to?
            //RaisePropertyChanged(nameof(this.Value));
            //RaisePropertyChanged(nameof(this.IsValueChanged));
        }
    }
}
