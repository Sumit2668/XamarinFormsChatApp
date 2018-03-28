using ChatApp.Shared.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatApp.API.Hubs
{
    public class ChatHub : Hub
    {
        public void SendMessage(Message message)
        {
            Clients.All.GetMessage(message);
        }
    }
}