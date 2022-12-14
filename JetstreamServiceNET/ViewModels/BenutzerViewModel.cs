using JetstreamServiceNET.Model;
using JetstreamServiceNET.Utility;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace JetstreamServiceNET.ViewModels
{
    public class BenutzerViewModel : ViewModelBase
    {
        private User _selectedUser = new User();
        private Content _content = new Content();
        private bool _IsIndeterminate = new bool();

        public string jwtKey { get; set; }
        public string userURL { get; set; }

        private ObservableCollection<User> _users = new ObservableCollection<User>();


        public User selectedUser
        {
            get { return _selectedUser; }
            set
            {
                if (value != _selectedUser)
                {
                    SetProperty<User>(ref _selectedUser, value);
                }
            }
        }

        public Content content
        {
            get { return _content; }
            set
            {
                if (value != _content)
                {
                    SetProperty<Content>(ref _content, value);
                }
            }
        }

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                if (value != _users)
                {
                    SetProperty<ObservableCollection<User>>(ref _users, value);
                }
            }
        }

        public bool IsIndeterminate
        {
            get { return _IsIndeterminate; }
            set
            {
                if (value != _IsIndeterminate)
                {
                    SetProperty(ref _IsIndeterminate, value);
                }
            }
        }

        private RelayCommand _cmdRead;
        private RelayCommand _cmdUnban;

        public BenutzerViewModel()
        {
            _cmdRead = new RelayCommand(param => Execute_Read(), param => CanExecute_Read());
            _cmdUnban = new RelayCommand(param => Execute_Unban(), param => CanExecute_Unban());

            jwtKey = Properties.Settings.Default.JWTToken;
            string baseURL = Properties.Settings.Default.APILink;
            string user = Properties.Settings.Default.userLink;
            userURL = baseURL + user;
            IsIndeterminate = false;
        }

        public RelayCommand CmdRead
        {
            get { return _cmdRead; }
            set { _cmdRead = value; }
        }

        public RelayCommand CmdUnban
        {
            get { return _cmdUnban; }
            set { _cmdUnban = value; }
        }

        
        private void Execute_Read()
        {
            IsIndeterminate = true;
            try
            {
                var options = new RestClientOptions(userURL)
                {
                    MaxTimeout = 10000,
                    ThrowOnAnyError = true
                };
                var client = new RestClient(options);

                var request = new RestRequest()
                    .AddHeader("Authorization", $"Bearer " + jwtKey);

                var response = client.Get(request);
                var statusCode = "Status Code: " + response.StatusCode;

                Users = JsonSerializer.Deserialize<ObservableCollection<User>>(response.Content);
                content.status = statusCode;
            }
            catch (Exception ex)
            {
                content.status = "Error: " + ex.Message;
            }
            finally
            {
                IsIndeterminate = false;
            }
        }

        private void Execute_Unban()
        {
            IsIndeterminate = true;
            try
            {
                var options = new RestClientOptions(userURL + "unban/" + selectedUser.Id)
                {
                    MaxTimeout = 10000,
                    ThrowOnAnyError = true
                };
                var client = new RestClient(options);

                var request = new RestRequest()
                    .AddHeader("Authorization", $"Bearer " + jwtKey);

                var response = client.Put(request);
                var statusCode = "Status Code: " + response.StatusCode;

                content.status = statusCode;
            }
            catch (Exception ex)
            {
                content.status = "Error: " + ex.Message;
            }
            finally
            {
                IsIndeterminate = false;
                Execute_Read();
            }
            
        }

        private bool CanExecute_Read()
        {
            return true;
        }

        private bool CanExecute_Unban()
        {
            if (selectedUser == null)
                return false;
            else
                return selectedUser.Id != 0;
        }
    }
}
