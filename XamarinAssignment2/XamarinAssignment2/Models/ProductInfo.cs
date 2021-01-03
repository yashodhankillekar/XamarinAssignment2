using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XamarinAssignment2.Models
{
    class ProductInfo : INotifyPropertyChanged
    {
        int _ProductRowId;
        string _ProductId;
        string _ProductName;
        string _ProductCategory;
        string _ProductManufacturer;
        string _ProductDescription;
        int _ProductPrice;
        string _ProductAddedByUser;

        public int ProductRowId
        {
            get
            {
                return _ProductRowId;
            }
            set
            {
                _ProductRowId = value;
                OnPropertyChanged("ProductRowId");
            }
        }
        public string ProductId
        {
            get
            {
                return _ProductId;
            }
            set
            {
                _ProductId = value;
                OnPropertyChanged("ProductId");
            }
        }
        public string ProductName
        {
            get
            {
                return _ProductName;
            }
            set
            {
                _ProductName = value;
                OnPropertyChanged("ProductName");
            }
        }

        public string ProductManufacturer
        {
            get
            {
                return _ProductManufacturer;
            }
            set
            {
                _ProductManufacturer = value;
                OnPropertyChanged("ProductManufacturer");
            }
        }
        public string ProductCategory
        {
            get
            {
                return _ProductCategory;
            }
            set
            {
                _ProductCategory = value;
                OnPropertyChanged("ProductManufacturer");
            }
        }
        public string ProductDescription
        {
            get
            {
                return _ProductDescription;
            }
            set
            {
                _ProductDescription = value;
                OnPropertyChanged("ProductDescription");
            }
        }
        public string ProductAddedByUser
        {
            get
            {
                return _ProductAddedByUser;
            }
            set
            {
                _ProductAddedByUser = value;
                OnPropertyChanged("ProductAddedByUser");
            }
        }
        public int ProductPrice
        {
            get
            {
                return _ProductPrice;
            }
            set
            {
                _ProductPrice = value;
                OnPropertyChanged("ProductPrice");
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
