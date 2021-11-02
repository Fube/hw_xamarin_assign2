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
        public static Lazy<GenericDBEntity<Role>> Roles = new Lazy<GenericDBEntity<Role>>(() => new GenericDBEntity<Role>(PATH));
        public static GenericDBEntity<UserRole> UserRole = new GenericDBEntity<UserRole>(PATH);

        public static User Principal = null;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());

            migrateRoles();
        }

        public async void migrateRoles()
        {
            var got = await Roles.Value.GetAsync();
            if (got.Count > 0) return;

            var admin = new Role { Name = "ADMIN" };
            var intern = new Role { Name = "INTERNAL" };
            var viewer = new Role { Name = "VIEWER" };

            await Roles.Value.SaveAsync(admin);
            await Roles.Value.SaveAsync(intern);
            await Roles.Value.SaveAsync(viewer);
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
