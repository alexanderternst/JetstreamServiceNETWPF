using JetstreamServiceNET.Model;
using JetstreamServiceNET.Properties;
using JetstreamServiceNET.Utility;
using RestSharp;
using System;
using System.Text.Json;

namespace JetstreamServiceNET.ViewModels
{
    public class ErstellungViewModel : ViewModelBase
    {
        private Order _order = new Order();
        private Content _content = new Content();
        public string RegistrationURL { get; set; }

        /// <summary>
        /// Property von Typ Order für Bestellung mit INotifyPropertyChanged
        /// </summary>
        public Order Order
        {
            get { return _order; }
            set
            {
                if (value != _order)
                {
                    SetProperty<Order>(ref _order, value);
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

        /// <summary>
        /// Property von Typ String für Priority mit INotifyPropertyChanged welche auch Logik integriert
        /// </summary>
        private string _priority;
        public string Priority
        {
            get { return _priority; }
            set
            {
                if (value != _priority)
                {
                    SetProperty(ref _priority, value);
                }
                if (_priority == "Express")
                {
                    Order.PickupDate = Order.CreateDate.AddDays(5);

                }
                else if (_priority == "Tief")
                {
                    Order.PickupDate = Order.CreateDate.AddDays(12);
                }
                else
                {
                    Order.PickupDate = Order.CreateDate.AddDays(7);
                }
            }
        }

        private RelayCommand _cmdSend;

        /// <summary>
        /// Konstruktor welcher Command Binding instanziiert und Properties setzt
        /// </summary>
        public ErstellungViewModel()
        {
            _cmdSend = new RelayCommand(param => Execute_Send(), param => CanExecute_Send());

            Order.CreateDate = DateTime.Now;
            RegistrationURL = Settings.Default.APILink + Settings.Default.registrationLink;
            Content.IsIndeterminate = false;
        }

        /// <summary>
        /// Prop für Command Binding
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
            try
            {
                Content.IsIndeterminate = true;
                Order.Id = 0;
                Order.Priority = Priority;

                if (Order.Comment == null)
                    Order.Comment = "";

                string json = JsonSerializer.Serialize<Order>(Order);

                var options = new RestClientOptions(RegistrationURL)
                {
                    MaxTimeout = 10000,
                    ThrowOnAnyError = true
                };
                var client = new RestClient(options);

                var request = new RestRequest()
                    .AddJsonBody(json);

                var response = client.Post(request);
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
        /// Methode welche überprüft ob Senden Button aktiviert sein soll
        /// </summary>
        /// <returns>true/false</returns>
        private bool CanExecute_Send()
        {
            if (Order == null)
                return false;
            else
                return Order.Name != null && Order.Email != null && Order.Phone != null && Order.Name != "" && Order.Email != "" && Order.Phone != "";
        }
    }
}
