using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Text.Json;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using JetstreamServiceNET.Model;
using JetstreamServiceNET.Utility;
using JetstreamServiceNET.Views;
using RestSharp;
using RestSharp.Authenticators;

namespace JetstreamServiceNET.ViewModels
{

    public class VerwaltungViewModel : ViewModelBase
    {
        private Order _selectedOrder = new Order();
        private Content _content = new Content();
        private bool _IsIndeterminate = new bool();

        public string jwtKey { get; set; }
        public string registrationURL { get; set; }

        private ObservableCollection<Order> _orders = new ObservableCollection<Order>();


        public Order selectedOrder
        {
            get { return _selectedOrder; }
            set
            {
                if (value != _selectedOrder)
                {
                    SetProperty<Order>(ref _selectedOrder, value);
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

        public ObservableCollection<Order> Orders
        {
            get { return _orders; }
            set
            {
                if (value != _orders)
                {
                    SetProperty<ObservableCollection<Order>>(ref _orders, value);
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
        private RelayCommand _cmdDelete;
        private RelayCommand _cmdModify;
        
        public VerwaltungViewModel()
        {
            _cmdRead = new RelayCommand(param => Execute_Read(), param => CanExecute_Read());
            _cmdDelete = new RelayCommand(param => Execute_Delete(), param => CanExecute_Delete());
            _cmdModify = new RelayCommand(param => Execute_Modify(), param => CanExecute_Modify());

            jwtKey = Properties.Settings.Default.JWTToken;
            string baseURL = Properties.Settings.Default.APILink;
            string registration = Properties.Settings.Default.registrationLink;
            registrationURL = baseURL + registration;
            IsIndeterminate = false;
        }

        public RelayCommand CmdRead
        {
            get { return _cmdRead; }
            set { _cmdRead = value; }
        }

        public RelayCommand CmdDelete
        {
            get { return _cmdDelete; }
            set { _cmdDelete = value; }
        }

        public RelayCommand CmdModify
        {
            get { return _cmdModify; }
            set { _cmdModify = value; }
        }

        private void Execute_Read()
        {
            IsIndeterminate = true;
            try
            {
                var options = new RestClientOptions(registrationURL)
                {
                    MaxTimeout = 10000,
                    ThrowOnAnyError = true
                };
                var client = new RestClient(options);

                var request = new RestRequest()
                    .AddHeader("Authorization", $"Bearer " + jwtKey);

                var response = client.Get(request);
                var statusCode = "Status Code: " + response.StatusCode;

                Orders = JsonSerializer.Deserialize<ObservableCollection<Order>>(response.Content);
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

        private void Execute_Delete()
        {
            IsIndeterminate = true;
            try
            {
                string? id = selectedOrder.Id.ToString();

                var options = new RestClientOptions(registrationURL + id)
                {
                    MaxTimeout = 10000,
                    ThrowOnAnyError = true
                };
                var client = new RestClient(options);

                var request = new RestRequest()
                    .AddHeader("Authorization", $"Bearer " + jwtKey);

                var response = client.Delete(request);
                var statusCode = "Status Code: " + response.StatusCode;

                content.status = statusCode;
                MessageBox.Show($" Eintrag mit id {id} gelöscht", "Löschen", MessageBoxButton.OK, MessageBoxImage.Information);
                Execute_Read();
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

        private void Execute_Modify()
        {
            IsIndeterminate = true;
            try
            {
                Order bestellungen = new Order();
                bestellungen = selectedOrder;
                string id = selectedOrder.Id.ToString();

                ModifizierungWindow win1 = new ModifizierungWindow(bestellungen);
                win1.ShowDialog();

                if (win1.DialogResult == true)
                {
                    string json = JsonSerializer.Serialize<Order>(bestellungen);

                    var options = new RestClientOptions(registrationURL + id)
                    {
                        MaxTimeout = 10000,
                        ThrowOnAnyError = true
                    };
                    var client = new RestClient(options);

                    var request = new RestRequest()
                        .AddHeader("Authorization", $"Bearer " + jwtKey)
                        .AddJsonBody(json);

                    var response = client.Put(request);
                    content.status = "Status Code: " + response.StatusCode;

                }
                else if (win1.DialogResult == false)
                {
                    content.status = "Canceled changed";
                    Execute_Read();
                }
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

        private bool CanExecute_Modify()
        {
            if (selectedOrder == null)
                return false;
            else
                return selectedOrder.Id != null;
        }

        private bool CanExecute_Delete()
        {
            if (selectedOrder == null)
                return false;
            else
                return selectedOrder.Id != null;
        }

        private bool CanExecute_Read()
        {
            return true;
        }
    }
}
