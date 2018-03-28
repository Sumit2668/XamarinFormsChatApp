using ChatApp.Services;
using ChatApp.Shared.Models;
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
	public partial class AdminChatPage : ContentPage
	{
        private string _name;
        private UserPerson _person;
        int count = 0;
		public AdminChatPage (string name)
		{
			InitializeComponent ();
            _name = name;
            Title = _name;

            _person = AdminServices.userPeople.Where(p => p.Name == _name).FirstOrDefault();

            sendButton.Clicked += SendButton_ClickedAsync;

            ChatClientService.OnMessageRecieved += ChatClientService_OnMessageRecieved1;

            ReelMessages(_person.Messages);

        }

        private void ChatClientService_OnMessageRecieved1(object sender, Message e)
        {
            if (e.Owner == "admin")
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

            else if (e.Owner == _name)
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

        private async void SendButton_ClickedAsync(object sender, EventArgs e)
        {
            await ChatClientService.Send(new Message
            {
                Id = count,
                Owner = "admin",
                Reciever = _name,
                Content = messageEntry.Text
            });

            count++;
        }

        public void ReelMessages (List<Message> messages)
        {
            foreach (var message in messages)
            {
                if (message.Owner == "admin")
                {
                    StackLayout sL = new StackLayout();
                    sL.HorizontalOptions = LayoutOptions.End;
                    sL.Padding = 10;
                    sL.BackgroundColor = Color.FromHex("#F6F6F6");

                    Label lbl = new Label();
                    lbl.Text = message.Content;
                    lbl.TextColor = Color.FromHex("#2196F3");

                    sL.Children.Add(lbl);

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        this.parentStack.Children.Add(sL);
                        scrollView.ScrollToAsync(parentStack.Width, parentStack.Height, true);

                        messageEntry.Text = "";
                    });


                }

                else
                {
                    StackLayout sL = new StackLayout();
                    sL.HorizontalOptions = LayoutOptions.Start;
                    sL.Padding = 10;
                    sL.BackgroundColor = Color.FromHex("#2196F3");

                    Label lbl = new Label();
                    lbl.Text = message.Content;
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
        }
	}
}