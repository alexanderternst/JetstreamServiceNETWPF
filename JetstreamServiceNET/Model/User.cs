using JetstreamServiceNET.ViewModels;
using System.Text.Json.Serialization;

namespace JetstreamServiceNET.Model
{
    public class User : ViewModelBase
    {
        private int _Id;
        [JsonPropertyName("user_id")]
        public int Id
        {
            get { return _Id; }
            set
            {
                if (_Id != value)
                {
                    SetProperty(ref _Id, value);
                }
            }
        }

        private string _username;
        [JsonPropertyName("username")]
        public string Username
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
        private string _password;
        [JsonPropertyName("password")]
        public string Password
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

        private int _counter;
        [JsonPropertyName("counter")]
        public int Counter
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
    }
}
