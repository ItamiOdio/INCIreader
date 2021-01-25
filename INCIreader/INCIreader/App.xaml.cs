using System;
using Xamarin.Forms;
using System.IO;
using Xamarin.Forms.Xaml;

namespace INCIreader


{
    public partial class App : Application
    {
        static Database database;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "testowa6.db3"));
                }
                return database;
            }
        }


        public static INavigation Nav { get; set; }
        public App()
        {
            Device.SetFlags(new[] { "Brush_Experimental", "RadioButton_Experimental" });
            InitializeComponent();

            MainPage = new MainPage();
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
