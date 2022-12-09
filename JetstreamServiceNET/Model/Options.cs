using JetstreamServiceNET.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JetstreamServiceNET.Model
{
    public class Options : ViewModelBase
    {
        private string _link;
        public string link
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
        public string language
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
