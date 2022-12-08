using JetstreamServiceNET.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JetstreamServiceNET.Model
{
    public class Authentification : ViewModelBase
    {
        private string _user;
        [JsonPropertyName("user_username")]
        public string user
        {
            get { return _user; }
            set
            {
                if (_user != value)
                {
                    SetProperty(ref _user, value);
                }
            }
        }
        private string _password;
        [JsonPropertyName("user_password")]
        public string password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    SetProperty(ref _password, value);
                }
            }
        }
    }
}
