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
    class ProductViewModel : ViewModelBase
    {
        private ProductInfo _Product;

        private ObservableCollection<ProductInfo> _Products;

        private ProductService service;

        private bool _IsAddEnabled;

        public ProductViewModel()
        {

            Product = new ProductInfo();
            Products = new ObservableCollection<ProductInfo>();

            service = new ProductService();
            _IsAddEnabled = false;


            GetProductsCommand = new Command(GetProducts);
            NavigationCommand = new Command(NavigateToList);
            GoToFormPage = new Command(NavigateToFormPage);
        }


        // The Command and other properties

        public ICommand GetProductsCommand { private set; get; }
        public ICommand NavigationCommand { private set; get; }
        public ICommand GoToFormPage { private set; get; }

        public ProductInfo Product
        {
            get { return _Product; }
            set
            {
                _Product = value;
                OnPropertyChanged("Product");
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
        public ObservableCollection<ProductInfo> Products
        {
            get { return _Products; }
            set
            {
                _Products = value;
                OnPropertyChanged("Products");
            }
        }

        private void ClearInputs()
        {
            Product = new ProductInfo();
        }

        /// <summary>
        /// Adding new Products
        /// </summary>
        /// 

        private async void GetProducts()
        {
            Products.Clear();
            foreach (ProductInfo prd in await service.GetData())
            {
                Products.Add(prd);
            }
        }

        private async void NavigateToList()
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new Views.ListPage());
        }

        private async void NavigateToFormPage()
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new Views.ProductFormPage());
        }
    }
}
