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

        public static void SetUp()
        {
            _connection = new HubConnection("");
            _proxy = _connection.CreateHubProxy("ChatHub");
        }

        public static async Task Connect()
        {
            await _connection.Start();
            _proxy.On("GetMessage", (ChatMessage message) => OnMessageRecieved(null, message));
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
