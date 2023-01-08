using JetstreamServiceNET.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JetstreamServiceNET
{
    /// <summary>
    /// Interaction logic for AuthentificationWindow.xaml
    /// </summary>
    public partial class AuthentificationWindow : Window
    {
        /// <summary>
        /// Konstruktor in dem wir Aktion zum schliessen eines Fensters setzen
        /// </summary>
        public AuthentificationWindow()
        {
            InitializeComponent();
            AuthentificationViewModel auvm = new AuthentificationViewModel();
            DataContext = auvm;
            if (auvm.CloseAction == null)
                auvm.CloseAction = new Action(() => this.Close());
        }
    }
}
