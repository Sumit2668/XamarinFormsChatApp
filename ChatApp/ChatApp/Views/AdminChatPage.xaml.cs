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
		public AdminChatPage (string name)
		{
			InitializeComponent ();
            _name = name;
            Title = _name;

            _person = AdminServices.userPeople.Where(p => p.Name == _name).FirstOrDefault();

        }
	}
}