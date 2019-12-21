using System;
using System.Collections.Generic;
using System.Text;

namespace Checklist.DataLogic.Entities
{
    public class RefreshToken:BaseEntity
    {
        public DateTime CreationDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Token { get; set; }
        public string JwtToken { get; set; }
        public User User  { get; set; }
        public bool Used { get; set; } = false;
        public bool Invalidated { get; set; } = false;
    }
}
