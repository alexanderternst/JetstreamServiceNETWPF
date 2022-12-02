using JetstreamServiceNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace JetstreamServiceNET.ViewModels
{
    public class ModifizierungViewModel : ViewModelBase
    {
        private User _order;
        public ModifizierungViewModel(User order)
        {
            _order = order;
            MessageBox.Show(_order.Name);
        }
    }
}
