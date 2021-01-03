using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XamarinAssignment2.Models
{
    class CategoryInfo : INotifyPropertyChanged
    {
        int _CategoryRowId;
        string _CategoryName;

        public int CategoryRowId
        {
            get
            {
                return _CategoryRowId;
            }
            set
            {
                _CategoryRowId = value;
                OnPropertyChanged("CategoryRowId");
            }
        }
        public string CategoryName
        {
            get
            {
                return _CategoryName;
            }
            set
            {
                _CategoryName = value;
                OnPropertyChanged("CategoryName");
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
