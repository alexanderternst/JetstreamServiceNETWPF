using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Windows;
using JetstreamServiceNET.Model;
using JetstreamServiceNET.Properties;
using JetstreamServiceNET.Utility;
using RestSharp;

namespace JetstreamServiceNET.ViewModels
{
    public class VerwaltungViewModel : ViewModelBase
    {
        private Order _selectedOrder = new Order();
        private Content _content = new Content();
        private string _SearchContent;

        public string JwtKey { get; set; }
        public string RegistrationURL { get; set; }

        private ObservableCollection<Order> _orders = new ObservableCollection<Order>();

        /// <summary>
        /// Order Property mit INotifyPropertyChanged
        /// </summary>
        public Order SelectedOrder
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
        /// ObservableCollection Order Property mit INotifyPropertyChanged
        /// </summary>
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

        /// <summary>
        /// String Property mit INotifyPropertyChanged
        /// </summary>
        public string SearchContent
        {
            get { return _SearchContent; }
            set
            {
                if (value != _SearchContent)
                {
                    SetProperty(ref _SearchContent, value);
                }
            }
        }

        private RelayCommand _cmdRead;
        private RelayCommand _cmdDelete;
        private RelayCommand _cmdModify;
        private RelayCommand _cmdSearch;

        /// <summary>
        /// Konstruktor welcher Command Binding instanziiert und Properties setzt
        /// </summary>
        public VerwaltungViewModel()
        {
            _cmdRead = new RelayCommand(param => Execute_Read(), param => CanExecute_Read());
            _cmdDelete = new RelayCommand(param => Execute_Delete(), param => CanExecute_Delete());
            _cmdModify = new RelayCommand(param => Execute_Modify(), param => CanExecute_Modify());
            _cmdSearch = new RelayCommand(param => Execute_Search(), param => CanExecute_Search());

            JwtKey = Settings.Default.JWTToken;
            RegistrationURL = Settings.Default.APILink + Settings.Default.registrationLink;
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
        public RelayCommand CmdDelete
        {
            get { return _cmdDelete; }
            set { _cmdDelete = value; }
        }

        /// <summary>
        /// Prop für Command Binding
        /// </summary>
        public RelayCommand CmdModify
        {
            get { return _cmdModify; }
            set { _cmdModify = value; }
        }

        /// <summary>
        /// Prop für Command Binding
        /// </summary>
        public RelayCommand CmdSearch
        {
            get { return _cmdSearch; }
            set { _cmdSearch = value; }
        }

        /// <summary>
        /// Methode welche HTTP GET Request ausführt
        /// </summary>
        private void Execute_Read()
        {
            Content.IsIndeterminate = true;
            try
            {
                var options = new RestClientOptions(RegistrationURL)
                {
                    MaxTimeout = 10000,
                    ThrowOnAnyError = true
                };
                var client = new RestClient(options);

                var request = new RestRequest()
                    .AddHeader("Authorization", $"Bearer " + JwtKey);

                var response = client.Get(request);

                Orders = JsonSerializer.Deserialize<ObservableCollection<Order>>(response.Content);
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
        /// Methode welche HTTP DELETE Request ausführt
        /// </summary>
        private void Execute_Delete()
        {
            Content.IsIndeterminate = true;
            try
            {
                string? id = SelectedOrder.Id.ToString();

                var options = new RestClientOptions(RegistrationURL + id)
                {
                    MaxTimeout = 10000,
                    ThrowOnAnyError = true
                };
                var client = new RestClient(options);

                var request = new RestRequest()
                    .AddHeader("Authorization", $"Bearer " + JwtKey);

                var response = client.Delete(request);

                Content.Status = "Status Code: " + response.StatusCode;
                MessageBox.Show($" Eintrag mit id {id} gelöscht", "Löschen", MessageBoxButton.OK, MessageBoxImage.Information);
                Execute_Read();
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
        private void Execute_Modify()
        {
            Content.IsIndeterminate = true;
            try
            {
                Order bestellungen = new Order();
                bestellungen = SelectedOrder;
                string id = SelectedOrder.Id.ToString();

                ModifizierungWindow win1 = new ModifizierungWindow(bestellungen);
                win1.ShowDialog();

                if (win1.DialogResult == true)
                {
                    string json = JsonSerializer.Serialize<Order>(bestellungen);

                    var options = new RestClientOptions(RegistrationURL + id)
                    {
                        MaxTimeout = 10000,
                        ThrowOnAnyError = true
                    };
                    var client = new RestClient(options);

                    var request = new RestRequest()
                        .AddHeader("Authorization", $"Bearer " + JwtKey)
                        .AddJsonBody(json);

                    var response = client.Put(request);
                    Content.Status = "Status Code: " + response.StatusCode;
                }
                else if (win1.DialogResult == false)
                {
                    Content.Status = "Canceled changes";
                }
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
        /// Methode welche in Liste nach spezifischem Text sucht und Reihen mit diesem Text wieder anzeigt
        /// </summary>
        private void Execute_Search()
        {
            try
            {
                Execute_Read();
                IEnumerable<Order> filteredOrder;
                filteredOrder = Orders.Where(x => x.Name.Contains(SearchContent, StringComparison.OrdinalIgnoreCase) || x.Id.ToString().Contains(SearchContent, StringComparison.OrdinalIgnoreCase) || x.Phone.Contains(SearchContent, StringComparison.OrdinalIgnoreCase) || x.Email.Contains(SearchContent, StringComparison.OrdinalIgnoreCase) || x.Priority.Contains(SearchContent, StringComparison.OrdinalIgnoreCase) || x.Service.Contains(SearchContent, StringComparison.OrdinalIgnoreCase) || x.Status.Contains(SearchContent, StringComparison.OrdinalIgnoreCase));
                var myObservableCollection = new ObservableCollection<Order>(filteredOrder);
                Orders = myObservableCollection;
            }
            catch (Exception ex)
            {
                Content.Status = "Error: " + ex.Message;
            }
            finally
            {
                SearchContent = "";
            }
        }

        /// <summary>
        /// Methode welche überprüft ob Button aktiviert sein soll
        /// </summary>
        /// <returns>true/false</returns>
        private bool CanExecute_Modify()
        {
            if (SelectedOrder == null)
                return false;
            else
                return SelectedOrder.Id != null;
        }

        /// <summary>
        /// Methode welche überprüft ob Button aktiviert sein soll
        /// </summary>
        /// <returns>true/false</returns>
        private bool CanExecute_Delete()
        {
            if (SelectedOrder == null)
                return false;
            else
                return SelectedOrder.Id != null;
        }

        /// <summary>
        /// Methode welche true zurückgibt, da man Einträge immer lesen können soll
        /// </summary>
        /// <returns>true</returns>
        private bool CanExecute_Read()
        {
            return true;
        }

        /// <summary>
        /// Methode welche überprüft ob Search Funktion aktiv sein soll
        /// </summary>
        /// <returns>true/false</returns>
        private bool CanExecute_Search()
        {
            if (Orders.Count == 0)
                return false;
            else
                return SearchContent != null && SearchContent != "";
        }
    }
}
