using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Shared.Models
{
    public class UserPerson : BasePerson
    {
        public List<Message> Messages { get; set; }
    }
}
