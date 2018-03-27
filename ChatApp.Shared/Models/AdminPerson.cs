using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Shared.Models
{
    public class AdminPerson : BasePerson
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
