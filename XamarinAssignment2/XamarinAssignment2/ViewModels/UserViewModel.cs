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
    class UserViewModel : ViewModelBase
    {
        private UserInfo _User;

        private ObservableCollection<UserInfo> _Users;

        private UserService service;

        private bool _IsAddEnabled;

        public UserViewModel()
        {

            User = new UserInfo();
            Users = new ObservableCollection<UserInfo>();

            service = new UserService();
            _IsAddEnabled = false;

            LoginCommand = new Command(Login);
            RegisterCommand = new Command(Register);
            NavigationCommand = new Command(NavigateToList);
            
        }


        // The Command and other properties

        public ICommand LoginCommand { private set; get; }
        public ICommand RegisterCommand { private set; get; }
        public ICommand NavigationCommand { private set; get; }
        

        public UserInfo User
        {
            get { return _User; }
            set
            {
                _User = value;
                OnPropertyChanged("User");
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
        public ObservableCollection<UserInfo> Users
        {
            get { return _Users; }
            set
            {
                _Users = value;
                OnPropertyChanged("Users");
            }
        }

        private void ClearInputs()
        {
            User = new UserInfo();
        }

        /// <summary>
        /// Adding new Users
        /// </summary>
        /// 

        private async void Login()
        {
            Users.Clear();
            UserInfo usr = await service.GetUser(User);
            await App.Current.MainPage.Navigation.PushModalAsync(new Views.ListPage());
        }

        private async void Register()
        {
            await service.PostUser(User);
            await App.Current.MainPage.Navigation.PushModalAsync(new Views.ListPage());
        }

        private async void NavigateToList()
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new Views.ListPage());
        }

        

    }
}