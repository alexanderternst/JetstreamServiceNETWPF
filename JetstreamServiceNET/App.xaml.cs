using JetstreamServiceNET.Properties;
using System.Windows;
using System.Threading;
using System.Globalization;



namespace JetstreamServiceNET
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.LanguageID);
        }
    }
}
