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
        public string Owner { get; set; }
        public string Reciever { get; set; }
        public string Content { get; set; }
    }
}
