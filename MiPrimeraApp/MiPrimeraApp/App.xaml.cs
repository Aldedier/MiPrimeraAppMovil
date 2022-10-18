using MiPrimeraApp.ViewPages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiPrimeraApp
{
    public partial class App : Application
    {
        public static NavigationPage Navegacion { get; internal set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
