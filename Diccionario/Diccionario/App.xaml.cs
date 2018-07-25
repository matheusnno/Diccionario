using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Diccionario.Views;
using Diccionario.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Diccionario
{
    public partial class App : Application
    {
        static DataAccess dbUtils;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new DicionarioPage());
        }

        public static DataAccess DAUtil
        {
            get
            {
                if (dbUtils == null)
                {
                    dbUtils = new DataAccess();
                }
                return dbUtils;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
