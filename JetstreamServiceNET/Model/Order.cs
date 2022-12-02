using JetstreamServiceNET.ViewModels;
using JetstreamServiceNET.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JetstreamServiceNET.Model
{
    public class Order : ViewModelBase
    {

        private int? _Id;
        public int? Id
        {
            get { return _Id; }
            set
            {
                if (_Id != value)
                {
                    SetProperty(ref _Id, value);
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
                    //_Name = value;
                    SetProperty(ref _Name, value);
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
                    SetProperty(ref _Email, value);
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
                    SetProperty(ref _Telefon, value);
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
                    SetProperty(ref _AuftragDatum, value);
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
                    SetProperty(ref _Service, value);
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
                    SetProperty(ref _Status, value);
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
                    SetProperty(ref _Prioritaet, value);
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
                    SetProperty(ref _Bemerkung, value);
                }
            }
        }
    }
}
