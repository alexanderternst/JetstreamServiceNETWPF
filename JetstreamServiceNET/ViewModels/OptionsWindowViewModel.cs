using JetstreamServiceNET.Model;
using JetstreamServiceNET.Properties;
using JetstreamServiceNET.Utility;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace JetstreamServiceNET.ViewModels
{
    public class OptionsWindowViewModel : ViewModelBase
    {
        private Options _options = new Options();


        // Breakpoint bei User Klasse setzen
        public Options options
        {
            get { return _options; }
            set
            {
                if (value != _options)
                {
                    SetProperty<Options>(ref _options, value);
                }
            }
        }

        private RelayCommand _cmdSend;

        public OptionsWindowViewModel()
        {
            _cmdSend = new RelayCommand(param => Execute_Send());

            options.link = Properties.Settings.Default.APILink;
        }

        public RelayCommand CmdSend
        {
            get { return _cmdSend; }
            set { _cmdSend = value; }
        }

        private void Execute_Send()
        {
            if (options.language == "English")
            {
                Properties.Settings.Default.LanguageID = "en";
            }
            else if (options.language == "German")
            {
                Properties.Settings.Default.LanguageID = "DE-CH";
            }
            Properties.Settings.Default.APILink= options.link;
            Properties.Settings.Default.Save();

            MessageBox.Show("In order for the changes to take effect, please restart the application", "Restart", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
;