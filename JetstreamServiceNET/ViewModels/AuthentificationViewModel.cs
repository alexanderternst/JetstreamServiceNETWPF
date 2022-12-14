using JetstreamServiceNET.Model;
using JetstreamServiceNET.Properties;
using JetstreamServiceNET.Utility;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace JetstreamServiceNET.ViewModels
{
    public class AuthentificationViewModel : ViewModelBase
    {
        private Authentification _authentification = new Authentification();

        private bool _IsIndeterminate = new bool();

        public string apiLink { get; set; }

        public Action CloseAction { get; set; }

        public Authentification authentification
        {
            get { return _authentification; }
            set
            {
                if (value != _authentification)
                {
                    SetProperty<Authentification>(ref _authentification, value);
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

        private RelayCommand _cmdSend;

        public AuthentificationViewModel()
        {
            _cmdSend = new RelayCommand(param => Execute_Send(), param => CanExecute_Send());
            apiLink = Properties.Settings.Default.APILink;
            IsIndeterminate = false;
        }

        public RelayCommand CmdSend
        {
            get { return _cmdSend; }
            set { _cmdSend = value; }
        }

        private void Execute_Send()
        {
            IsIndeterminate = true;

            try
            {
                string json = JsonSerializer.Serialize<Authentification>(authentification);

                var options = new RestClientOptions(apiLink + "/api/User/login")
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
                    AuthentificationResponse authResponse = new AuthentificationResponse();
                    authResponse = JsonSerializer.Deserialize<AuthentificationResponse>(response.Content);

                    Properties.Settings.Default.JWTToken = authResponse.jwt;
                    Properties.Settings.Default.Save();

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
            finally { IsIndeterminate = false; }
        }

        private bool CanExecute_Send()
        {
            if (authentification == null)
                return false;
            else
                return authentification.user != null && authentification.password != null && authentification.user != "" && authentification.password != "";
        }
    }
}
