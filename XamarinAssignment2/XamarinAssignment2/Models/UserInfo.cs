using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XamarinAssignment2.Models
{
    public class UserInfo : INotifyPropertyChanged
    {
        private int _UserRowId;
        private string _UserName;
        private string _UserPassword;


        public int UserRowId
        {
            get
            {
                return _UserRowId;
            }
            set
            {
                _UserRowId = value;
                OnPropertyChanged("UserRowId");
            }
        }

        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string UserPassword
        {
            get
            {
                return _UserPassword;
            }
            set
            {
                _UserPassword = value;
                OnPropertyChanged("UserPassword");
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
