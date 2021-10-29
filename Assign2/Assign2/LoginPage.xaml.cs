using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assign2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage, INotifyPropertyChanged
    {

        public new event PropertyChangedEventHandler PropertyChanged;

        private User _user;

        public User User
        {
            get => _user;
            set
            {
                _user = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(User)));
            }
        }
        public LoginPage()
        {
            _user = new User();
            InitializeComponent();
            BindingContext = this;
        }

        private async void btnRegister_ClickedAsync(object sender, EventArgs args) => await Navigation.PushAsync(new RegisterPage());

        private async void btnLogin_ClickedAsync(object sender, EventArgs args)
        {
            string userName = _user.Username;
            string passWord = _user.Password;

            if(userName.Equals("admin") && passWord.Equals("admin"))
            {
                IList<Role> roles = new List<Role>
                {
                    new Role { Name = "ADMIN" }
                };


                App.Principal = new User { Roles=roles };
                await DisplayAlert("Login result", "Successful admin login", "OK");
                await Navigation.PushAsync(new MainPage());
                return;
            }

            var user = await App.Users.Value.GetOneByPredicate(n => n.Username == userName);
            if (user != null && user.Password.Equals(passWord))
            {
                App.Principal = user;
                await DisplayAlert("Login result", "Success", "OK");
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Login result", "Failure", "OK");
            }

        }
    }
}