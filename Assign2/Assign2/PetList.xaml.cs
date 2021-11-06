using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace Assign2
{
    public partial class PetList : ContentPage
    {
        public PetList()
        {
            InitializeComponent();
            BindingContext = this;
            loadPets();
        }

        private async void loadPets()
        {
            var pets = await App.Pets.GetAsync();
            Pets.ItemsSource = pets.Select(n => new
            {
                OwnerID = n.OwnerID,
                Name = n.Name,
                Type = n.Type,
                ImagePath = $"{n.Type.ToLower()}.jpg"
            });
        }

        private async void HandleDoubleTap(object sender, EventArgs e)
        {
            var bindable = (BindableObject)sender;
            dynamic context = bindable.BindingContext;
            int ownerId = context.OwnerID;

            if(!App.Principal.IsAdmin && App.Principal.ID != ownerId)
            {
                await DisplayAlert("Unauthorized", "You are not allowed to modify this pet", "Ok");
                return;
            }
            // TODO: Add pet edit nav push
        }
    }
}

