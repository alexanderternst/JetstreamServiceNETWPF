using JetstreamServiceNET.Model;
using JetstreamServiceNET.Properties;
using JetstreamServiceNET.Utility;
using RestSharp;
using System;
using System.Text.Json;
using System.Windows;

namespace JetstreamServiceNET.ViewModels
{
    public class AuthentificationViewModel : ViewModelBase
    {
        private User _authentification = new User();

        private Content _content = new Content();
        public Action CloseAction { get; set; }

        public string UserURL { get; set; }

        /// <summary>
        /// Property von Typ Authentification für Login mit INotifyPropertyChanged
        /// </summary>
        public User Authentification
        {
            get { return _authentification; }
            set
            {
                if (value != _authentification)
                {
                    SetProperty<User>(ref _authentification, value);
                }
            }
        }

        /// <summary>
        /// Property von Typ Content für Status Bar mit INotifyPropertyChanged
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

        private RelayCommand _cmdSend;

        /// <summary>
        /// Konstruktor welcher Command Binding instanziiert und URL setzt.
        /// </summary>
        public AuthentificationViewModel()
        {
            _cmdSend = new RelayCommand(param => Execute_Send(), param => CanExecute_Send());
            UserURL = Settings.Default.APILink + Settings.Default.userLink;
            Content.IsIndeterminate = false;
        }

        /// <summary>
        /// CmdSend Prop welche wir für Command Binding verwenden
        /// </summary>
        public RelayCommand CmdSend
        {
            get { return _cmdSend; }
            set { _cmdSend = value; }
        }

        /// <summary>
        /// Methode welche HTTP POST Request ausführt
        /// </summary>
        private void Execute_Send()
        {
            Content.IsIndeterminate = true;
            try
            {
                string? json = JsonSerializer.Serialize<User>(Authentification);

                var options = new RestClientOptions(UserURL + "login")
                {
                    MaxTimeout = 10000,
                    ThrowOnAnyError = true
                };
                var client = new RestClient(options);

                var request = new RestRequest()
                    .AddJsonBody(json);

                var response = client.Post(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    User? authResponse = JsonSerializer.Deserialize<User>(response.Content);

                    Settings.Default.JWTToken = authResponse.Jwt;
                    Settings.Default.Save();

                    MessageBox.Show("Successful login", "Login", MessageBoxButton.OK, MessageBoxImage.Information);
                    CloseAction();
                }
                else
                {
                    MessageBox.Show($"{response.StatusCode}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally 
            { 
                Content.IsIndeterminate = false; 
            }
        }

        /// <summary>
        /// Methode welche überprüft ob Senden Button aktiviert soll sein
        /// </summary>
        /// <returns>true/false</returns>
        private bool CanExecute_Send()
        {
            if (Authentification == null)
                return false;
            else
                return Authentification.Username != null && Authentification.Password != null && Authentification.Username != "" && Authentification.Password != "";
        }
    }
}
