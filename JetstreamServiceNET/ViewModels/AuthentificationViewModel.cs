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

        // Breakpoint bei User Klasse setzen
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

        private RelayCommand _cmdSend;

        public AuthentificationViewModel()
        {
            _cmdSend = new RelayCommand(param => Execute_Send());
        }

        public RelayCommand CmdSend
        {
            get { return _cmdSend; }
            set { _cmdSend = value; }
        }

        private void Execute_Send()
        {
            string json = JsonSerializer.Serialize<Authentification>(authentification);

            var options = new RestClientOptions("https://localhost:7253/api/User/login")
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
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                MessageBox.Show("Invalid credentials", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(response.Content, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
