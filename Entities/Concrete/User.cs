using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string UserEMail { get; set; }
        public string UserPassword { get; set; }
    }
}
