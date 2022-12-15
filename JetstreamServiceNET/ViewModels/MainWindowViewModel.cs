using JetstreamServiceNET.Utility;

namespace JetstreamServiceNET.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private RelayCommand _cmdAuth;
        private RelayCommand _cmdOptions;

        /// <summary>
        /// Konstruktor welcher Command Binding instanziiert
        /// </summary>
        public MainWindowViewModel()
        {
            _cmdAuth = new RelayCommand(param => Execute_Auth());
            _cmdOptions = new RelayCommand(param => Execute_Options());
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
    }
}
