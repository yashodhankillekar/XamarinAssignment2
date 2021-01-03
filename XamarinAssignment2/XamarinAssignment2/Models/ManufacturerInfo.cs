using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XamarinAssignment2.Models
{
    class ManufacturerInfo : INotifyPropertyChanged
    {
        int _ManufacturerRowId;
        string _ManufacturerName;

        public int ManufacturerRowId
        {
            get
            {
                return _ManufacturerRowId;
            }
            set
            {
                _ManufacturerRowId = value;
                OnPropertyChanged("ManufacturerRowId");
            }
        }
        public string ManufacturerName
        {
            get
            {
                return _ManufacturerName;
            }
            set
            {
                _ManufacturerName = value;
                OnPropertyChanged("ManufacturerName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string pName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(pName));
            }
        }
    }
}
