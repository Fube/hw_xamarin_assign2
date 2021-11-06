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
    public partial class PetRegister : ContentPage, INotifyPropertyChanged
    {
        public new event PropertyChangedEventHandler PropertyChanged;

        private Pet _pet;

        public Pet Pet {
            get => _pet;
            set
            {
                _pet = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Pet)));
            }
        }

        public PetRegister()
        {
            _pet = new Pet();
            InitializeComponent();
            BindingContext = this;
        }

        public async void Register(object sender, EventArgs args) 
        {
            var prince = App.Principal.ID;
            var owners = await App.Owners.Value.GetAsync();
            var owner = owners.FirstOrDefault(n => n.User?.ID == prince);

            if(owner == null)
            {
                owner = new Owner { User = App.Principal };
                await App.Owners.Value.SaveAsync(owner);
            }

            _pet.OwnerID = owner.ID;
            await App.Pets.SaveAsync(_pet);
            owner.Pets.Add(_pet);

            await App.Owners.Value.Update(owner);

            await Navigation.PopAsync();
        }
    }
}

