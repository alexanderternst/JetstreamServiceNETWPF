using JetstreamServiceNET.ViewModels;
using System.Text.Json.Serialization;

namespace JetstreamServiceNET.Model
{
    public class User : ViewModelBase
    {
        private int? _id;
        [JsonPropertyName("user_id")]
        public int? Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    SetProperty(ref _id, value);
                }
            }
        }

        private string? _username;
        [JsonPropertyName("user_username")]
        public string? Username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    SetProperty(ref _username, value);
                }
            }
        }
        private string? _password;
        [JsonPropertyName("user_password")]
        public string? Password
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

        private int? _counter;
        [JsonPropertyName("user_counter")]
        public int? Counter
        {
            get { return _counter; }
            set
            {
                if (_counter != value)
                {
                    SetProperty(ref _counter, value);
                }
            }
        }

        private string? _jwt;
        [JsonPropertyName("token")]
        public string? Jwt
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
