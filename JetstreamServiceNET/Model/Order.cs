using JetstreamServiceNET.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JetstreamServiceNET.Model
{
    public class Order : ViewModelBase
    {

        private int? _Id;
        [JsonPropertyName("registration_id")]
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
        [JsonPropertyName("registration_name")]
        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                {
                    SetProperty(ref _Name, value);
                }
            }
        }

        private string _Email;
        [JsonPropertyName("registration_email")]
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

        private string _Phone;
        [JsonPropertyName("registration_phone")]
        public string Phone
        {
            get { return _Phone; }
            set
            {
                if (_Phone != value)
                {
                    SetProperty(ref _Phone, value);
                }
            }
        }

        private DateTime _CreateDate;
        [JsonPropertyName("registration_create_date")]
        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set
            {
                if (_CreateDate != value)
                {
                    SetProperty(ref _CreateDate, value);
                }
            }
        }

        private DateTime _PickupDate;
        [JsonPropertyName("registration_pickup_date")]
        public DateTime PickupDate
        {
            get { return _PickupDate; }
            set
            {
                if (_PickupDate != value)
                {
                    SetProperty(ref _PickupDate, value);
                }
            }
        }

        private string _Status;
        [JsonPropertyName("registration_status")]
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

        private string _Priority;
        [JsonPropertyName("registration_priority")]
        public string Priority
        {
            get { return _Priority; }
            set
            {
                if (_Priority != value)
                {
                    SetProperty(ref _Priority, value);
                }
            }
        }

        private string _Service;
        [JsonPropertyName("registration_service")]
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


        private string _Comment;
        [JsonPropertyName("registration_comment")]
        public string Comment
        {
            get { return _Comment; }
            set
            {
                if (_Comment != value)
                {
                    SetProperty(ref _Comment, value);
                }
            }
        }
    }
}
