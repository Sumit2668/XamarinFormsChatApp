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
	public partial class AdminChatListPage : ContentPage
	{
		public AdminChatListPage ()
		{
			InitializeComponent ();
            testButton.Clicked += TestButton_Clicked;
		}

        private async void TestButton_Clicked(object sender, EventArgs e)
        {
            ChatClientService.SetUp();
            await ChatClientService.Connect();
            await ChatClientService.Send(new ChatMessage { Name = "Vincent Nwonah", MessageStr = "Hello World"});
        }
    }
}