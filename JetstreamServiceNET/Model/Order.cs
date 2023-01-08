using JetstreamServiceNET.ViewModels;
using System;
using System.Text.Json.Serialization;

namespace JetstreamServiceNET.Model
{
    public class Order : ViewModelBase
    {

        private int? _id;
        [JsonPropertyName("registration_id")]
        public int? Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    SetProperty(ref _id, value);
                }
            }
        }

        private string? _name;
        [JsonPropertyName("registration_name")]
        public string? Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    SetProperty(ref _name, value);
                }
            }
        }

        private string? _email;
        [JsonPropertyName("registration_email")]
        public string? Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    SetProperty(ref _email, value);
                }
            }
        }

        private string? _phone;
        [JsonPropertyName("registration_phone")]
        public string? Phone
        {
            get { return _phone; }
            set
            {
                if (_phone != value)
                {
                    SetProperty(ref _phone, value);
                }
            }
        }

        private DateTime _createDate;
        [JsonPropertyName("registration_create_date")]
        public DateTime CreateDate
        {
            get { return _createDate; }
            set
            {
                if (_createDate != value)
                {
                    SetProperty(ref _createDate, value);
                }
            }
        }

        private DateTime _pickupDate;
        [JsonPropertyName("registration_pickup_date")]
        public DateTime PickupDate
        {
            get { return _pickupDate; }
            set
            {
                if (_pickupDate != value)
                {
                    SetProperty(ref _pickupDate, value);
                }
            }
        }

        private string? _status;
        [JsonPropertyName("registration_status")]
        public string? Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    SetProperty(ref _status, value);
                }
            }
        }

        private string? _priority;
        [JsonPropertyName("registration_priority")]
        public string? Priority
        {
            get { return _priority; }
            set
            {
                if (_priority != value)
                {
                    SetProperty(ref _priority, value);
                }
            }
        }

        private string? _service;
        [JsonPropertyName("registration_service")]
        public string? Service
        {
            get { return _service; }
            set
            {
                if (_service != value)
                {
                    SetProperty(ref _service, value);
                }
            }
        }


        private string? _comment;
        [JsonPropertyName("registration_comment")]
        public string? Comment
        {
            get { return _comment; }
            set
            {
                if (_comment != value)
                {
                    SetProperty(ref _comment, value);
                }
            }
        }
    }
}
