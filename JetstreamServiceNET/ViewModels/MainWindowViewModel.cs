using JetstreamServiceNET.Model;
using JetstreamServiceNET.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace JetstreamServiceNET.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private RelayCommand _cmdAuth;
        private RelayCommand _cmdOptions;

        public MainWindowViewModel()
        {
            _cmdAuth = new RelayCommand(param => Execute_Auth());
            _cmdOptions = new RelayCommand(param => Execute_Options());
        }

        public RelayCommand CmdAuth
        {
            get { return _cmdAuth; }
            set { _cmdAuth = value; }
        }
        public RelayCommand CmdOptions
        {
            get { return _cmdOptions; }
            set { _cmdOptions = value; }
        }

        private void Execute_Auth()
        {
            AuthentificationWindow authWindow = new AuthentificationWindow();
            authWindow.ShowDialog();
        }

        private void Execute_Options()
        {
            OptionsWindow optionWindow = new OptionsWindow();
            optionWindow.ShowDialog();
        }
    }
}
