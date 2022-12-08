using JetstreamServiceNET.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JetstreamServiceNET.Model
{
    public class Content : ViewModelBase
    {
        private string _status;
        public string status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    SetProperty(ref _status, value);
                }
            }
        }

    }
}
