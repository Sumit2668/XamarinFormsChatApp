using ChatApp.Services;
using ChatApp.Shared.Models;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatApp.Views
{

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChatPage : ContentPage
	{
        public string _personName;
        int count = 0;
        ChatClientServiceUser chUser;


        public ChatPage (string personName, ref ChatClientServiceUser ch)
		{
			InitializeComponent ();
            _personName = personName.ToLower();
            sendButton.Clicked += SendButton_Clicked;
            chUser = ch;
            chUser.OnMessageRecieved += ChatClientService_OnMessageRecieved;
		}


        private void ChatClientService_OnMessageRecieved(object sender, Message e)
        {
          
            if (e.Reciever == "admin")
            {
                StackLayout sL = new StackLayout();
                sL.HorizontalOptions = LayoutOptions.End;
                sL.Padding = 10;
                sL.BackgroundColor = Color.FromHex("#F6F6F6");

                Label lbl = new Label();
                lbl.Text = e.Content;
                lbl.TextColor = Color.FromHex("#2196F3");

                sL.Children.Add(lbl);

                Device.BeginInvokeOnMainThread(() =>
                {
                    this.parentStack.Children.Add(sL);
                    scrollView.ScrollToAsync(parentStack.Width, parentStack.Height, true);

                    messageEntry.Text = "";
                });

               
            }

            else if (e.Reciever == _personName)
            {
                StackLayout sL = new StackLayout();
                sL.HorizontalOptions = LayoutOptions.Start;
                sL.Padding = 10;
                sL.BackgroundColor = Color.FromHex("#2196F3");

                Label lbl = new Label();
                lbl.Text = e.Content;
                lbl.TextColor = Color.White;

                sL.Children.Add(lbl);
                
                Device.BeginInvokeOnMainThread(() =>
                {
                    this.parentStack.Children.Add(sL);
                    scrollView.ScrollToAsync(parentStack.Width, parentStack.Height, true);

                    messageEntry.Text = "";
                });
               
            }
        }

        private async void SendButton_Clicked(object sender, EventArgs e)
        {
            await chUser.Send(new Message {
                Id = count,
                Owner = _personName,
                Reciever ="admin",
                Content = messageEntry.Text
            });

            count++;
        }
    }

    
}