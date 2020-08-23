using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mDome.MobileApp.Services;
using mDome.MobileApp.Views;

namespace mDome.MobileApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            Device.SetFlags(new[] { "Expander_Experimental" });
            MainPage = new LoginPage();
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
