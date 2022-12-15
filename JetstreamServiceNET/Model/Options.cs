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

        private string _userLink;
        public string UserLink
        {
            get { return _userLink; }
            set
            {
                if (_userLink != value)
                {
                    SetProperty(ref _userLink, value);
                }
            }
        }

        private string _regiLink;
        public string RegiLink
        {
            get { return _regiLink; }
            set
            {
                if (_regiLink != value)
                {
                    SetProperty(ref _regiLink, value);
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
