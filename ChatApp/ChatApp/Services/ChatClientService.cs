using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using ChatApp.Shared.Models;
using System.Threading.Tasks;

namespace ChatApp.Services
{
    public static class ChatClientService
    {
        private static HubConnection _connection;
        private static IHubProxy _proxy;
        public static event EventHandler<ChatMessage> OnMessageRecieved;
        public static int Counter = 0;

        public static void SetUp()
        {
            if (Counter == 0)
            {
                _connection = new HubConnection("http://chatappapi.azurewebsites.net");
                _proxy = _connection.CreateHubProxy("ChatHub");

            }
           
        }

        public static async Task Connect()
        {
            if (Counter == 0)
            {
                await _connection.Start();
                _proxy.On("GetMessage", (ChatMessage message) => OnMessageRecieved(null, message));
            }
            
        }

        public static Task Send(ChatMessage message)
        {
            return _proxy.Invoke("SendMessage", message);
        }

    }

    public class ChatMessage
    {
        public string Name { get; set; }
        public string MessageStr { get; set; }
    }

}
