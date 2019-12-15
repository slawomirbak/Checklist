using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Checklist.DataLogic.Entities
{
    public class User:BaseEntity
    {
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public DateTime CreatedDate { get; set; }

        public void  PasswordHash(string password)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
