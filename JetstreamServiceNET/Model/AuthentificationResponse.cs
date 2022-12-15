using JetstreamServiceNET.ViewModels;
using System.Text.Json.Serialization;

namespace JetstreamServiceNET.Model
{
    public class AuthentificationResponse : ViewModelBase
    {
        private string _user;
        [JsonPropertyName("userName")]
        public string User
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
        public string Jwt
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