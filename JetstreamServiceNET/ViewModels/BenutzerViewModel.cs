using JetstreamServiceNET.Model;
using JetstreamServiceNET.Properties;
using JetstreamServiceNET.Utility;
using RestSharp;
using System;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows;

namespace JetstreamServiceNET.ViewModels
{
    public class BenutzerViewModel : ViewModelBase
    {
        private User _selectedUser = new User();
        private Content _content = new Content();

        public string JwtKey { get; set; }
        public string UserURL { get; set; }

        private ObservableCollection<User> _users = new ObservableCollection<User>();

        /// <summary>
        /// User Property mit INotifyPropertyChanged
        /// </summary>
        public User SelectedUser
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

        /// <summary>
        /// Content Property mit INotifyPropertyChanged
        /// </summary>
        public Content Content
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

        /// <summary>
        /// ObservableCollection User Property mit INotifyPropertyChanged
        /// </summary>
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

        private RelayCommand _cmdRead;
        private RelayCommand _cmdUnban;

        /// <summary>
        /// Konstruktor welcher Command Binding instanziiert und Properties setzt
        /// </summary>
        public BenutzerViewModel()
        {
            _cmdRead = new RelayCommand(param => Execute_Read(), param => CanExecute_Read());
            _cmdUnban = new RelayCommand(param => Execute_Unban(), param => CanExecute_Unban());

            JwtKey = Properties.Settings.Default.JWTToken;
            UserURL = Settings.Default.APILink + Settings.Default.userLink;
            Content.IsIndeterminate = false;
        }

        /// <summary>
        /// Prop für Command Binding
        /// </summary>
        public RelayCommand CmdRead
        {
            get { return _cmdRead; }
            set { _cmdRead = value; }
        }

        /// <summary>
        /// Prop für Command Binding
        /// </summary>
        public RelayCommand CmdUnban
        {
            get { return _cmdUnban; }
            set { _cmdUnban = value; }
        }

        /// <summary>
        /// Methode welche HTTP GET Request ausführt
        /// </summary>
        private void Execute_Read()
        {
            Content.IsIndeterminate = true;
            try
            {
                var options = new RestClientOptions(UserURL)
                {
                    MaxTimeout = 10000,
                    ThrowOnAnyError = true
                };
                var client = new RestClient(options);

                var request = new RestRequest()
                    .AddHeader("Authorization", $"Bearer " + JwtKey);

                var response = client.Get(request);

                Users = JsonSerializer.Deserialize<ObservableCollection<User>>(response.Content);
                Content.Status = "Status Code: " + response.StatusCode;
            }
            catch (Exception ex)
            {
                Content.Status = "Error: " + ex.Message;
            }
            finally
            {
                Content.IsIndeterminate = false;
            }
        }

        /// <summary>
        /// Methode welche HTTP PUT Request ausführt
        /// </summary>
        private void Execute_Unban()
        {
            Content.IsIndeterminate = true;
            try
            {
                var options = new RestClientOptions(UserURL + "unban/" + SelectedUser.Id)
                {
                    MaxTimeout = 10000,
                    ThrowOnAnyError = true
                };
                var client = new RestClient(options);

                var request = new RestRequest()
                    .AddHeader("Authorization", $"Bearer " + JwtKey);

                var response = client.Put(request);
                var statusCode = "Status Code: " + response.StatusCode;

                Content.Status = statusCode;
                MessageBox.Show($"User with id {SelectedUser.Id} unbanned", "Unban", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                Content.Status = "Error: " + ex.Message;
            }
            finally
            {
                Content.IsIndeterminate = false;
                Execute_Read();
            }

        }

        /// <summary>
        /// Methode welche überprüft ob Button aktiviert sein sollen
        /// </summary>
        /// <returns>true/false/returns>
        private bool CanExecute_Read()
        {
            return true;
        }

        /// <summary>
        /// Methode welche überprüft ob Button aktiviert sein sollen
        /// </summary>
        /// <returns>true/false</returns>
        private bool CanExecute_Unban()
        {
            if (SelectedUser == null)
                return false;
            else
                return SelectedUser.Id != 0;
        }
    }
}
