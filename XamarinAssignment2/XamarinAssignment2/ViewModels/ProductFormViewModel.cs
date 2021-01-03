using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinAssignment2.Models;
using XamarinAssignment2.Services;
using XamarinAssignment2.Views;

namespace XamarinAssignment2.ViewModels
{
    class ProductFormViewModel : ViewModelBase
    {
        private ProductInfo _Product;

        private ObservableCollection<ManufacturerInfo> _Manufacturers;
        private ObservableCollection<CategoryInfo> _Categories;

        private ProductService service;

        private CategoryService catService;
        private ManufacturerService manuService;

        private bool _IsAddEnabled;

        public ProductFormViewModel()
        {
            Product = new ProductInfo();
            service = new ProductService();

            _Manufacturers = new ObservableCollection<ManufacturerInfo>();
            _Categories = new ObservableCollection<CategoryInfo>();

            catService = new CategoryService();
            manuService = new ManufacturerService();
            _IsAddEnabled = true;

            getData();

            AddProductCommand = new Command(AddProduct);

        }

        public ICommand AddProductCommand { private set; get; }

        public ProductInfo Product
        {
            get { return _Product; }
            set
            {
                _Product = value;
                OnPropertyChanged("Product");
            }
        }

        public ObservableCollection<CategoryInfo> Categories
        {
            get { return _Categories; }
            set
            {
                _Categories = value;
                OnPropertyChanged("Categories");
            }
        }

        public ObservableCollection<ManufacturerInfo> Manufacturers
        {
            get { return _Manufacturers; }
            set
            {
                _Manufacturers = value;
                OnPropertyChanged("Manufacturers");
            }
        }

        public bool IsAddEnabled
        {
            get { return _IsAddEnabled; }
            set
            {
                _IsAddEnabled = value;
                OnPropertyChanged("IsAddEnabled");
            }
        }

        private async void AddProduct()
        {
            await service.PostProduct(Product);
        }

        private async void getData()
        {
            foreach (var item in await catService.GetData())
            {
                Categories.Add(item);
            }

            foreach (var item in await manuService.GetData())
            {
                Manufacturers.Add(item);
            }
        }
    }
}
