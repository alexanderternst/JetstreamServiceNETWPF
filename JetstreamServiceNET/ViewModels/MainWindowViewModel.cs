using JetstreamServiceNET.Utility;
using System.Windows;

namespace JetstreamServiceNET.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private RelayCommand _cmdAuth;
        private RelayCommand _cmdOptions;
        private RelayCommand _cmdAbout;

        /// <summary>
        /// Konstruktor welcher Command Binding instanziiert
        /// </summary>
        public MainWindowViewModel()
        {
            _cmdAuth = new RelayCommand(param => Execute_Auth());
            _cmdOptions = new RelayCommand(param => Execute_Options());
            _cmdAbout = new RelayCommand(param => Execute_About());
        }

        /// <summary>
        /// Prop für Command Binding
        /// </summary>
        public RelayCommand CmdAuth
        {
            get { return _cmdAuth; }
            set { _cmdAuth = value; }
        }
        /// <summary>
        /// Prop für Command Binding
        /// </summary>
        public RelayCommand CmdOptions
        {
            get { return _cmdOptions; }
            set { _cmdOptions = value; }
        }
        /// <summary>
        /// Prop für Command Binding
        /// </summary>
        public RelayCommand CmdAbout
        {
            get { return _cmdAbout; }
            set { _cmdAbout = value; }
        }

        /// <summary>
        /// Methode welche Fenster aufruft
        /// </summary>
        private void Execute_Auth()
        {
            AuthentificationWindow authWindow = new AuthentificationWindow();
            authWindow.ShowDialog();
        }
        /// <summary>
        /// Methode welche Fenster aufruft
        /// </summary>
        private void Execute_Options()
        {
            OptionsWindow optionWindow = new OptionsWindow();
            optionWindow.ShowDialog();
        }

        /// <summary>
        /// Methode welche Fenster mit Informationen aufruft
        /// </summary>
        private void Execute_About()
        {
            MessageBox.Show("JetstreamSkiservice tool created by Alexander Ernst\nApplication which lets you create and modify orders with API as Backend.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
