using System;
using System.Collections.Generic;

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
            Pets.ItemsSource = pets;
        }

    }
}

