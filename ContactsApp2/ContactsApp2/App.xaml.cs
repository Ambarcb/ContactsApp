using ContactsApp2.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactsApp2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ContactAgendaPage(null));
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
