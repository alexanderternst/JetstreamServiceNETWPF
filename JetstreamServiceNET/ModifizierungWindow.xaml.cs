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

        /// <summary>
        /// Konstruktor welcher Daten von anderem Fenster nimmt und speichert
        /// </summary>
        /// <param name="order"></param>
        public ModifizierungWindow(Order order)
        {
            InitializeComponent();
            _order = order;
            DataContext = _order;
        }

        /// <summary>
        /// Methode welche auf klicken des Senden Knopfes reagiert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        /// <summary>
        /// Methode welche auf klicken des Abbrechen Knopfes reagiert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
