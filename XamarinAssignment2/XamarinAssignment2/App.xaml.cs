﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinAssignment2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Views.LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
