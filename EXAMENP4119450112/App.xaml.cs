using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EXAMENP4119450112
{
    public partial class App : Application
    {

        static Controllers.LocalizacionController database;

        public static Controllers.LocalizacionController Database
        {
            get
            {
                if (database == null)
                {
                    var pathadatabase = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    var dbname = "Progra 4.db3";
                    var fullpath = Path.Combine(pathadatabase, dbname);
                    database = new Controllers.LocalizacionController(fullpath);
                }
                return database;
            }

        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.PageLocalizacion());
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
