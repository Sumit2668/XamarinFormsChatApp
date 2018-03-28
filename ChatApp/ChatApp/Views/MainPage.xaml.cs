using ChatApp.Services;
using ChatApp.Shared.Models;
using Microsoft.AspNet.SignalR.Client;
using Plugin.Connectivity;
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
                if(CrossConnectivity.Current.IsConnected)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        adminLogin.IsVisible = false;
                        personName.IsVisible = false;
                        login.IsVisible = false;
                        activity.IsVisible = true;
                    });
                    ChatClientServiceUser ch = new ChatClientServiceUser();
                    await ch.Connect();
                    Navigation.PushAsync(new ChatPage(personName.Text, ref ch));
                }

                else
                {
                    await DisplayAlert("ChatApp", "Check Network Connection", "Close");
                }

            }

            else
            {
                personName.Placeholder = "Enter a Name First!";
            }
        }
    }

    public class ChatClientServiceUser
    {
        private HubConnection _connection;
        private IHubProxy _proxy;
        public event EventHandler<Message> OnMessageRecieved;
        public int Counter = 0;

        public ChatClientServiceUser()
        {
            _connection = new HubConnection("http://chatappapi.azurewebsites.net");
            _proxy = _connection.CreateHubProxy("ChatHub");
        }




        public async Task Connect()
        {
            if (Counter == 0)
            {
                await _connection.Start();
                _proxy.On("GetMessage", (Message message) => OnMessageRecieved(this, message));
            }

        }

        public Task Send(Message message)
        {
            return _proxy.Invoke("SendMessage", message);
        }

    }
}