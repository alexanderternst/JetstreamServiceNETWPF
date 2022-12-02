using JetstreamServiceNET.Model;
using JetstreamServiceNET.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JetstreamServiceNET.ViewModels
{
    public class ErstellungViewModel : ViewModelBase
    {
        private User _order = new User();

        // Breakpoint bei User Klasse setzen
        public User order
        {
            get { return _order; }
            set
            {
                if (value != _order)
                {
                    SetProperty<User>(ref _order, value);
                }
            }
        }


        private RelayCommand _cmdSend;

        public ErstellungViewModel()
        {
            // Check if Values are empty
            _cmdSend = new RelayCommand(param => Execute_Send());
        }

        public RelayCommand CmdSend
        {
            get { return _cmdSend; }
            set { _cmdSend = value; }
        }

        private void Execute_Send()
        {
            MessageBox.Show($"Name: {order.Name}\nEmail: {order.Email}\nTelefon {order.Telefon}", "Sending");
        }
    }
}
