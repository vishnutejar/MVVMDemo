using MVVMDemo.views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MapPage());
            MainPage = new NavigationPage(new ListOfProducts());
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
