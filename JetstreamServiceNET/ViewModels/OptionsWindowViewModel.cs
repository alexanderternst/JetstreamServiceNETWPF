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
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Resources;

namespace JetstreamServiceNET.ViewModels
{
    public class OptionsWindowViewModel : ViewModelBase
    {
        private Options _options = new Options();

        public Action CloseAction { get; set; }


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
            _cmdSend = new RelayCommand(param => Execute_Send(), param => CanExecute_Send());

            options.link = Properties.Settings.Default.APILink;
            string lang = Properties.Settings.Default.LanguageID;
            
            if (lang == "DE-CH")
                options.language = "German";
            else if (lang == "en")
                options.language = "English";
            else if (lang == "fr")
                options.language = "French";
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
            else if (options.language == "French")
            {
                Properties.Settings.Default.LanguageID = "fr";
            }
            Properties.Settings.Default.APILink = options.link;
            Properties.Settings.Default.Save();


            MessageBox.Show(" Please restart the application", "Restart", MessageBoxButton.OK, MessageBoxImage.Information);
            CloseAction();
        }
            
        private bool CanExecute_Send()
        {
            if (options == null)
                return false;
            else
                return options.link != "" && options.link != null;
        }

    }
}