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
    public partial class PetEdit : ContentPage, INotifyPropertyChanged
    {
        public new event PropertyChangedEventHandler PropertyChanged;

        private Pet _pet { get; set; }
        public Pet Pet 
        { 
            get => _pet;
            set
            {
                _pet = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Pet)));
            }
        }
        public PetEdit(Pet pet)
        {
            InitializeComponent();
            Pet = pet;
            BindingContext = this;
        }

        private async void Update(object sender, EventArgs e)
        {
            await App.Pets.Update(Pet);
            await Navigation.PopAsync();
        }
    }
}