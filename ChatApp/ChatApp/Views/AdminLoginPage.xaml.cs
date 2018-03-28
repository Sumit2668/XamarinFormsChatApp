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
	public partial class AdminLoginPage : ContentPage
	{
		public AdminLoginPage ()
		{
			InitializeComponent ();
            login.Clicked += Login_Clicked;
		}

        private async void Login_Clicked(object sender, EventArgs e)
        {
            ChatClientService.SetUp();
            await ChatClientService.Connect();
            ChatClientService.Counter++;
            Navigation.PushAsync(new AdminChatListPage());
        }
    }
}