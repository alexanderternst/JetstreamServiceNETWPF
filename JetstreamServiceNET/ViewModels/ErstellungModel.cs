using JetstreamServiceNET.Model;
using JetstreamServiceNET.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JetstreamServiceNET.ViewModels
{
    public class ErstellungModel
    {
        private RelayCommand _cmdSend;

        public ErstellungModel()
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
            MessageBox.Show("Sending data", "Sending");
        }
    }
}
