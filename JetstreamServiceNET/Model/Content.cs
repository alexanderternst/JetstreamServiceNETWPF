﻿using JetstreamServiceNET.ViewModels;

namespace JetstreamServiceNET.Model
{
    public class Content : ViewModelBase
    {
        private string? _status;
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

        private bool _IsIndeterminate = new();

        public bool IsIndeterminate
        {
            get { return _IsIndeterminate; }
            set
            {
                if (value != _IsIndeterminate)
                {
                    SetProperty(ref _IsIndeterminate, value);
                }
            }
        }
    }
}
