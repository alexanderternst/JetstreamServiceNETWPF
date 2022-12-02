using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using JetstreamServiceNET.Model;
using JetstreamServiceNET.Utility;
using JetstreamServiceNET.Views;
using RestSharp;
using RestSharp.Authenticators;

namespace JetstreamServiceNET.ViewModels
{

    public class VerwaltungViewModel : ViewModelBase
    {
        private User _selectedOrder = new User();

        // Breakpoint bei User Klasse setzen
        public User selectedOrder
        {
            get { return _selectedOrder; }
            set
            {
                if (value != _selectedOrder)
                {
                    SetProperty<User>(ref _selectedOrder, value);
                }
            }
        }


        private RelayCommand _cmdRead;
        private RelayCommand _cmdDelete;
        private RelayCommand _cmdModify;

        public ObservableCollection<User> Mitarbeiter { get; set; }

        public VerwaltungViewModel()
        {
            _cmdRead = new RelayCommand(param => Execute_Read());
            _cmdDelete = new RelayCommand(_cmdSaveparam => Execute_Delete());
            _cmdModify = new RelayCommand(_cmdSaveparam => Execute_Modify());


            Mitarbeiter = new ObservableCollection<User>
            {
                new User() {
                    Id = 1,
                    Name = "John Doe",
                    Email = "john.doe@gmx.com",
                    Telefon = "077 463 35 93",
                    AuftragDatum = new DateTime(1971, 7, 23),
                    Service = "Heisswachsen",
                    Status= "Offen",
                    Prioritaet = "Express",
                    Bemerkung = "Bitte vorsicht mit Ski"
                    },
                new User() {
                    Id = 2,
                    Name = "Jane Doe",
                    Email = "jane.doe@gmx.com",
                    Telefon = "077 828 82 73",
                    AuftragDatum = new DateTime(2000, 10, 11),
                    Service = "Heisswachsen",
                    Status= "Offen",
                    Prioritaet = "Express",
                    Bemerkung = "keine Bemerkungen"
                    },
                new User() { Id = 3, Name = "Sammy Doe", AuftragDatum = new DateTime(1991, 9, 2) },
                new User() { Id = 4, Name = "Sammy Doe", AuftragDatum = new DateTime(1991, 9, 2) },
                new User() { Id = 5, Name = "Sammy Doe", AuftragDatum = new DateTime(1991, 9, 2) },
                new User() { Id = 6, Name = "Sammy Doe", AuftragDatum = new DateTime(1991, 9, 2) },
                new User() { Id = 7, Name = "Sammy Doe", AuftragDatum = new DateTime(1991, 9, 2) },
                new User() { Id = 8, Name = "Sammy Doe", AuftragDatum = new DateTime(1991, 9, 2) },
                new User() { Id = 9, Name = "Sammy Doe", AuftragDatum = new DateTime(1991, 9, 2) },
                new User() { Id = 10, Name = "Sammy Doe", AuftragDatum = new DateTime(1991, 9, 2) },
                new User() { Id = 11, Name = "Sammy Doe", AuftragDatum = new DateTime(1991, 9, 2) },
                new User() { Id = 12, Name = "Sammy Doe", AuftragDatum = new DateTime(1991, 9, 2) },
                new User() { Id = 13, Name = "Sammy Doe", AuftragDatum = new DateTime(1991, 9, 2) },

            };
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
            MessageBox.Show("Reading data", "Read");
        }

        private void Execute_Delete()
        {
            MessageBox.Show("Deleting data", "Deleting");
        }

        private void Execute_Modify()
        {
            //MessageBox.Show($"{selectedOrder.Id}", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            //ModifizierungViewModel vwm = new ModifizierungViewModel(selectedOrder);
            Modifizierung win1 = new Modifizierung(selectedOrder);
            win1.ShowDialog();
        }
    }

}
