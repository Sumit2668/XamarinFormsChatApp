using ChatApp.Services;
using ChatApp.Shared.Models;
using Plugin.Connectivity;
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
            if(username.Text == "admin" && password.Text == "admin")
            {
                if (CrossConnectivity.Current.IsConnected)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        username.IsVisible = false;
                        password.IsVisible = false;
                        login.IsVisible = false;
                        activity.IsVisible = true;
                    });
                    ChatClientService.SetUp();
                    await ChatClientService.Connect();
                    ChatClientService.Counter++;
                    Navigation.PushAsync(new AdminChatListPage());
                }

                else
                {
                    DisplayAlert("ChatApp", "No Network Cnnection", "Close");
                }
            }

            else
            {
                DisplayAlert("ChatApp", "Invalid Login Credentials", "Close");
            }
            
           
        }
    }
}