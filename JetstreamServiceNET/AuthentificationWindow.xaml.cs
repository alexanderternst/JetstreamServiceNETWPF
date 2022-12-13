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
        public AuthentificationWindow()
        {
            InitializeComponent();
            AuthentificationViewModel auvm = new AuthentificationViewModel(); // this creates an instance of the ViewModel
            this.DataContext = auvm; // this sets the newly created ViewModel as the DataContext for the View
            if (auvm.CloseAction == null)
                auvm.CloseAction = new Action(() => this.Close());
        }
    }
}
