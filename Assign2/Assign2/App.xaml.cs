using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assign2
{
    public partial class App : Application
    {
        private static string PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "assign2.db3");

        public static Lazy<GenericDBEntity<User>> Users = new Lazy<GenericDBEntity<User>>(() => new GenericDBEntity<User>(PATH));
        public static Lazy<GenericDBEntity<Vet>> Vets = new Lazy<GenericDBEntity<Vet>>(() => new GenericDBEntity<Vet>(PATH));
        public static Lazy<GenericDBEntity<Pet>> Pets = new Lazy<GenericDBEntity<Pet>>(() => new GenericDBEntity<Pet>(PATH));

        public static User Principal = null;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
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
