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
    public partial class UserDisplay : ContentPage
    {
        public UserDisplay()
        {
            InitializeComponent();
            BindingContext = this;
            loadUsers();
        }

        private async void loadUsers()
        {
            var users = await App.Users.Value.GetAsync();
            UsersList.ItemsSource = users;
        }

        private void AdminCheckedChange(object sender, EventArgs args)
        {
            var cb = (CheckBox)sender;
            int id = (cb.BindingContext as User)?.ID ?? default;
            HandleRoleChange(id, "ADMIN", cb.IsChecked);
        }

        private void InternalCheckedChange(object sender, EventArgs args)
        {
            var cb = (CheckBox)sender;
            int id = (cb.BindingContext as User)?.ID ?? default;
            HandleRoleChange(id, "INTERNAL", cb.IsChecked);
        }

        private void ViewerCheckedChange(object sender, EventArgs args)
        {

            var cb = (CheckBox)sender;
            int id = (cb.BindingContext as User)?.ID ?? default;
            HandleRoleChange(id, "VIEWER", cb.IsChecked);
        }

        private async void HandleRoleChange(int id, string roleName, bool status)
        {
            var user = await App.Users.Value.GetOneByPredicate(n => n.ID == id);
            if (user == null)
            {
                Console.WriteLine("User not found!");
                return;
            }

            var role = await App.Roles.Value.GetOneByPredicate(n => n.Name == roleName);
            if (role == null)
            {
                Console.WriteLine("Role not found!");
                return;
            }

            if (status)
            {
                if (user.Roles == null) user.Roles = new List<Role>();
                user.Roles.Add(role);
            }
            else
            {
                user.Roles.RemoveAll(n => n.ID == role.ID);
            }

            await App.Users.Value.Update(user);
        }
    }
}