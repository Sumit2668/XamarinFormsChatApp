using ChatApp.Services;
using ChatApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            if (UserServices.userPeople == null || !ReferenceEquals(userList, UserServices.userPeople))
            {

                UserServices.userPeople = null;
                userList = new ObservableCollection<UserPerson>();
                UserServices.SetUp(ref userList);
                UserServices.Counter++;
                

            }

            UsersList.ItemsSource = userList;
            

        }


    }
}