using ChatApp.Services;
using ChatApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdminChatListPage : ContentPage
	{
        ObservableCollection<UserPerson> userList;

		public AdminChatListPage ()
		{
			InitializeComponent ();

            if (AdminServices.userPeople == null || !ReferenceEquals(userList, AdminServices.userPeople))
            {

                AdminServices.userPeople = null;
                userList = new ObservableCollection<UserPerson>();
                AdminServices.SetUp(ref userList);
                AdminServices.Counter++;
                

            }

            UsersList.ItemsSource = userList;

            UsersList.ItemSelected += UsersList_ItemSelected;

        }

        private void UsersList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Debug.WriteLine(e.SelectedItem.ToString());
            var person = (UserPerson)e.SelectedItem;
            Navigation.PushAsync(new AdminChatPage(person.Name));
        }
    }
}