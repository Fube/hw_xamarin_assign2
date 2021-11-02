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
    public partial class RegisterPage : ContentPage, INotifyPropertyChanged
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

        public RegisterPage()
        {
            _user = new User();
            InitializeComponent();
            BindingContext = this;
        }

        private async void btnRegister_ClickedAsync(object sender, EventArgs args)
        {

            (int _, string userName, string email, string passWord, string phone) = _user;

            if (!(string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(passWord)))
            {
                if(!_user.IsValid(out string message))
                {
                    await DisplayAlert("Register result", message, "OK");
                }
                else
                {
                    var r = await App.Roles.Value.GetOneByPredicate(n => n.Name == "VIEWER");
                    if (_user.Roles == null) _user.Roles = new List<Role>();

                    _user.Roles.Add(r);
                    await App.Users.Value.SaveAsync(_user);

                    //await DisplayAlert("Register result", "Success", "OK");
                    await Navigation.PopAsync();
                }
            }
            else
            {
                await DisplayAlert("Register result", "Failure", "OK");
            }

        }
    }
}
