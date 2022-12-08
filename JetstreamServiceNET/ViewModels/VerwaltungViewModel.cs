﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Windows;
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

        private ObservableCollection<Order> _orders = new ObservableCollection<Order>();


        // Breakpoint bei User Klasse setzen
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

        // Breakpoint bei User Klasse setzen
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

        private RelayCommand _cmdRead;
        private RelayCommand _cmdDelete;
        private RelayCommand _cmdModify;

        public VerwaltungViewModel()
        {
            _cmdRead = new RelayCommand(param => Execute_Read());
            _cmdDelete = new RelayCommand(_cmdSaveparam => Execute_Delete());
            _cmdModify = new RelayCommand(_cmdSaveparam => Execute_Modify());
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
            try
            {
                var options = new RestClientOptions("https://localhost:7253/api/Registration")
                {
                    MaxTimeout = 10000,
                    ThrowOnAnyError = true
                };
                var client = new RestClient(options);

                var request = new RestRequest()
                    .AddHeader("Authorization", "Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJhbGV4IiwibmJmIjoxNjcwMjMyNTcwLCJleHAiOjE2NzAzMTg5NzAsImlhdCI6MTY3MDIzMjU3MH0.WyZ1zHATPn8Wn9HXxVsauFAOHRzUKrAwQ-oWJ4jTDHFooO0ngqZg5w5MWyudgdd2Kppt_zEX3kGDL7lcHBdOhg");

                var response = client.Get(request);
                string json = response.Content;
                var statusCode = "Status Code: " + response.StatusCode;

                Orders = JsonSerializer.Deserialize<ObservableCollection<Order>>(json);
                content.status = statusCode;

                MessageBox.Show($"Einträge geladen", "Laden", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                content.status = "Fehler: " + ex.Message;
            }
        }

        private void Execute_Delete()
        {
            try
            {
                string id = selectedOrder.Id.ToString();

                var options = new RestClientOptions($"https://localhost:7253/api/Registration/{id}")
                {
                    MaxTimeout = 10000,
                    ThrowOnAnyError = true
                };
                var client = new RestClient(options);

                var request = new RestRequest()
                    .AddHeader("Authorization", "Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJhbGV4IiwibmJmIjoxNjcwMjMyNTcwLCJleHAiOjE2NzAzMTg5NzAsImlhdCI6MTY3MDIzMjU3MH0.WyZ1zHATPn8Wn9HXxVsauFAOHRzUKrAwQ-oWJ4jTDHFooO0ngqZg5w5MWyudgdd2Kppt_zEX3kGDL7lcHBdOhg");

                var response = client.Delete(request);
                string json = response.Content;
                var statusCode = "Status Code: " + response.StatusCode;

                Execute_Read();
                content.status = statusCode;

                MessageBox.Show($"Eintrag mit id {id} gelöscht", "Löschen", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                content.status = "Fehler: " + ex.Message;
            }
        }

        private void Execute_Modify()
        {
            ModifizierungWindow win1 = new ModifizierungWindow(selectedOrder);
            win1.ShowDialog();
        }
    }

}
