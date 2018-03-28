using ChatApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ChatApp.Services
{
    public static class AdminServices
    {
        public static int Counter = 0;
        public static ObservableCollection<UserPerson> userPeople;
        
        public static void SetUp (ref ObservableCollection<UserPerson> us)
        {
            userPeople = us;

            if (Counter == 0)
            {
                ChatClientService.OnMessageRecieved += ChatClientService_OnMessageRecieved;
            }
        }

        private static void ChatClientService_OnMessageRecieved(object sender, Message e)
        {
            var person = userPeople.Where(p => p.Name == e.Owner).FirstOrDefault();

            if (person == null)
            {
                userPeople.Add(new UserPerson
                {
                    Name = e.Owner,
                    Messages = new List<Message>
                    {
                        e
                    },
                });
            }

            else
            {
                person.Messages.Add(e);
            }




        }
    }
}
