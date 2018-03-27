using ChatApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
            adminLogin.Clicked += AdminLogin_Clicked;
            login.Clicked += Login_Clicked;
		}

        private void AdminLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdminLoginPage());
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(personName.Text) )
            {
                ChatClientService.SetUp();
                await ChatClientService.Connect();
                Navigation.PushAsync(new ChatPage(personName.Text));
            }

            else
            {
                personName.Placeholder = "Enter a Name First!";
            }
        }
    }
}