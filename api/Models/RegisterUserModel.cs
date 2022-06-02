using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class RegisterUserModel
    {
        
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string confirmPassword { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
    }
}
