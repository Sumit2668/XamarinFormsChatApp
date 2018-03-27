using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Shared.Models
{
    public class Message
    {
        public int Id { get; set; }
        public BasePerson Owner { get; set; }
        public BasePerson Reciever { get; set; }
        public string Content { get; set; }
    }
}
