﻿using System;
using System.Collections.Generic;
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

        private void Login_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdminChatListPage());
        }
    }
}