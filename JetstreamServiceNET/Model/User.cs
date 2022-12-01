using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JetstreamServiceNET.Model
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
                    OnPropertyChanged(new PropertyChangedEventArgs("Id"));
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
                    OnPropertyChanged(new PropertyChangedEventArgs("Name"));
                }
            }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set
            {
                if (_Email != value)
                {
                    _Email = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Name"));
                }
            }
        }

        private string _Telefon;
        public string Telefon
        {
            get { return _Telefon; }
            set
            {
                if (_Telefon != value)
                {
                    _Telefon = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Telefon"));
                }
            }
        }

        private DateTime _AuftragDatum;
        public DateTime AuftragDatum
        {
            get { return _AuftragDatum; }
            set
            {
                if (_AuftragDatum != value)
                {
                    _AuftragDatum = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("AuftragsDatum"));
                }
            }
        }

        private string _Service;
        public string Service
        {
            get { return _Service; }
            set
            {
                if (_Service != value)
                {
                    _Service = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Service"));
                }
            }
        }

        private string _Status;
        public string Status
        {
            get { return _Status; }
            set
            {
                if (_Status != value)
                {
                    _Status = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Status"));
                }
            }
        }

        private string _Prioritaet;
        public string Prioritaet
        {
            get { return _Prioritaet; }
            set
            {
                if (_Prioritaet != value)
                {
                    _Prioritaet = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Prioritaet"));
                }
            }
        }

        private string _Bemerkung;
        public string Bemerkung
        {
            get { return _Bemerkung; }
            set
            {
                if (_Bemerkung != value)
                {
                    _Bemerkung = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Bemerkung"));
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
