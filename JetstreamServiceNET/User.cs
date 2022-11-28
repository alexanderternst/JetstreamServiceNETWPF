using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JetstreamServiceNET
{
    public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        private int? _Id;
        public int? Id
        {
            get { return _Id; }
            set
            {
                if (_Id != value)
                {
                    _Id = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Age"));
                }
            }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("City"));
                }
            }
        }
        private DateTime _birthday;
        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {
                if (_birthday != value)
                {
                    _birthday = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("City"));
                }
            }
        }


        public virtual void SetProperty<T>(ref T storage, T value, [CallerMemberName] string property = null)
        {
            storage = value;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
