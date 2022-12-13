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
    /// Interaction logic for OptionsWindow.xaml
    /// </summary>
    public partial class OptionsWindow : Window
    {
        public OptionsWindow()
        {
            InitializeComponent();
            OptionsWindowViewModel ovm = new OptionsWindowViewModel(); // this creates an instance of the ViewModel
            this.DataContext = ovm; // this sets the newly created ViewModel as the DataContext for the View
            if (ovm.CloseAction == null)
                ovm.CloseAction = new Action(() => this.Close());
        }
    }
}
