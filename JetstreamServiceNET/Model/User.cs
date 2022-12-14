using JetstreamServiceNET.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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

        private string _user;
        [JsonPropertyName("username")]
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
        [JsonPropertyName("password")]
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

        private int _counter;
        [JsonPropertyName("counter")]
        public int counter
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
