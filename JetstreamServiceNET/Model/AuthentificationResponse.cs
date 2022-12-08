using JetstreamServiceNET.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JetstreamServiceNET.Model
{
    public class AuthentificationResponse : ViewModelBase
    {
        private string _user;
        [JsonPropertyName("userName")]
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
        private string _jwt;
        [JsonPropertyName("token")]
        public string jwt
        {
            get { return _jwt; }
            set
            {
                if (_jwt != value)
                {
                    SetProperty(ref _jwt, value);
                }
            }
        }
    }
}
