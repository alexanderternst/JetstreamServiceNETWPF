using JetstreamServiceNET.Model;
using JetstreamServiceNET.Utility;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Resources;

namespace JetstreamServiceNET.ViewModels
{
    public class ErstellungViewModel : ViewModelBase
    {
        private Order _order = new Order();
        private Content _content = new Content();

        public string registrationURL { get; set; }

        // Breakpoint bei User Klasse setzen
        public Order order
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

        private string _priority;
        public string priority
        {
            get { return _priority; }
            set {
                if (value != _priority)
                {
                    SetProperty(ref _priority, value);
                }

                if (_priority == "Express")
                {
                    order.PickupDate = order.CreateDate.AddDays(5);
                }
                else if (_priority == "Tief")
                {
                    order.PickupDate = order.CreateDate.AddDays(12);
                }
                else
                {
                    order.PickupDate = order.CreateDate.AddDays(7);
                }
            }
        }

        private RelayCommand _cmdSend;

        public ErstellungViewModel()
        {
            // Check if Values are empty
            _cmdSend = new RelayCommand(param => Execute_Send());
            order.CreateDate = DateTime.Now;

            string baseURL = Properties.Settings.Default.APILink;
            string registration = Properties.Settings.Default.registrationLink;
            registrationURL = baseURL + registration;
        }

        public RelayCommand CmdSend
        {
            get { return _cmdSend; }
            set { _cmdSend = value; }
        }

        private void Execute_Send()
        {
            try
            {
                order.Priority = priority;
                string json = JsonSerializer.Serialize<Order>(order);

                var options = new RestClientOptions($"{registrationURL}")
                {
                    MaxTimeout = 10000,
                    ThrowOnAnyError = true
                };
                var client = new RestClient(options);

                var request = new RestRequest()
                    .AddJsonBody(json);

                var response = client.Post(request);
                content.status = "Status Code: " + response.StatusCode;
            }
            catch (Exception ex)
            {
                content.status = "Error: " + ex.Message;
            }
        }
    }
}
