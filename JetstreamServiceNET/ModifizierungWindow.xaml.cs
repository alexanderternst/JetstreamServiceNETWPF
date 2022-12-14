using JetstreamServiceNET.Model;
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
    /// Interaction logic for Modifizierung.xaml
    /// </summary>
    public partial class ModifizierungWindow : Window
    {
        private Order _order = new Order();
        public ModifizierungWindow(Order order)
        {
            InitializeComponent();
            _order = order;
            DataContext = _order;
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult = false;
        }
    }
}
