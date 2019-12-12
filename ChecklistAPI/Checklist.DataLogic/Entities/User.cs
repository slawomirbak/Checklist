using System;
using System.Collections.Generic;
using System.Text;

namespace Checklist.DataLogic.Entities
{
    public class User:BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
