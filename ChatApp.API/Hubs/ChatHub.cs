using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatApp.API.Hubs
{
    public class ChatHub : Hub
    {
        public void SendMessage(ChatMessage message)
        {
            Clients.All.GetMessage(message);
        }
    }

    public class ChatMessage
    {
        public string Name { get; set; }
        public string MessageStr { get; set; }
    }
}