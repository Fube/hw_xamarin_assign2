using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Assign2
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public new event PropertyChangedEventHandler PropertyChanged;
        public bool _IsUserListEnabled { get; set;}
        public bool IsUserListEnabled 
        { 
            get => _IsUserListEnabled;
            set
            {
                _IsUserListEnabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsUserListEnabled)));
            }
        }
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            IsUserListEnabled = App.Principal.IsAdmin;
        }

        private async void VetRegister(object sender, EventArgs e) => await Navigation.PushAsync(new VetRegister());

        private async void VetList(System.Object sender, System.EventArgs e) => await Navigation.PushAsync(new VetList());

        private async void Logout(object sender, EventArgs e)
        {
            App.Principal = null;
            await Navigation.PopToRootAsync();
        }

        private async void PetRegister(System.Object sender, System.EventArgs e) => await Navigation.PushAsync(new PetRegister());

        private async void Button_Clicked(System.Object sender, System.EventArgs e) => await Navigation.PushAsync(new PetList());

        private async void UserDisplay(object sender, EventArgs e) => await Navigation.PushAsync(new UserDisplay());
    }
}
