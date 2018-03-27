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
	public partial class ChatPage : ContentPage
	{
        private string _personName;


        public ChatPage (string personName)
		{
			InitializeComponent ();
            _personName = personName;
            sendButton.Clicked += SendButton_Clicked;
		}

        private async void SendButton_Clicked(object sender, EventArgs e)
        {
            await ChatClientService.Send(new ChatMessage { Name = _personName, MessageStr = messageEntry.Text });
        }
    }
}