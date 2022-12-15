using JetstreamServiceNET.ViewModels;

namespace JetstreamServiceNET.Model
{
    public class Options : ViewModelBase
    {
        private string _link;
        public string Link
        {
            get { return _link; }
            set
            {
                if (_link != value)
                {
                    SetProperty(ref _link, value);
                }
            }
        }
        private string _language;
        public string Language
        {
            get { return _language; }
            set
            {
                if (_language != value)
                {
                    SetProperty(ref _language, value);
                }
            }
        }
    }
}
