using JetstreamServiceNET.Model;
using JetstreamServiceNET.Properties;
using JetstreamServiceNET.Utility;
using System;
using System.Windows;

namespace JetstreamServiceNET.ViewModels
{
    public class OptionsWindowViewModel : ViewModelBase
    {
        private Options _options = new Options();
        public Action CloseAction { get; set; }

        /// <summary>
        /// Options Property mit INotifyPropertyChanged
        /// </summary>
        public Options Options
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

        /// <summary>
        /// Konstruktor welcher Command Binding instanziiert und Properties setzt
        /// </summary>
        public OptionsWindowViewModel()
        {
            _cmdSend = new RelayCommand(param => Execute_Send(), param => CanExecute_Send());

            Options.Link = Settings.Default.APILink;
            Options.RegiLink = Settings.Default.registrationLink;
            Options.UserLink = Settings.Default.userLink;
            string lang = Settings.Default.LanguageID;

            if (lang == "DE-CH")
                Options.Language = "German";
            else if (lang == "en")
                Options.Language = "English";
            else if (lang == "fr")
                Options.Language = "French";
            else if (lang == "it")
                Options.Language = "Italian";
            else
                Options.Language = "English";
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
        /// Methode welche Werte in XML Settings Datei speichert
        /// </summary>
        private void Execute_Send()
        {
            if (Options.Language == "English")
            {
                Settings.Default.LanguageID = "en";
            }
            else if (Options.Language == "German")
            {
                Settings.Default.LanguageID = "DE-CH";
            }
            else if (Options.Language == "French")
            {
                Settings.Default.LanguageID = "fr";
            }
            else if (Options.Language == "Italian")
            {
                Settings.Default.LanguageID = "it";
            }
            else
            {
                Settings.Default.LanguageID = "en";
            }
            Settings.Default.APILink = Options.Link;
            Settings.Default.registrationLink = Options.RegiLink;
            Settings.Default.userLink = Options.UserLink;
            Settings.Default.Save();

            MessageBox.Show("Please restart the application", "Restart", MessageBoxButton.OK, MessageBoxImage.Information);
            CloseAction();
        }

        /// <summary>
        /// Methode welche überprüft ob Senden Knopf aktiviert sein soll
        /// </summary>
        /// <returns></returns>
        private bool CanExecute_Send()
        {
            if (Options == null)
                return false;
            else
                return Options.Link != "" && Options.Link != null && Options.UserLink != "" && Options.UserLink != null && Options.RegiLink != "" && Options.RegiLink != null;
        }

    }
}