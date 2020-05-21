using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BankApplication.Models
{
    public class UserCreateModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [UIHint("email")]
        public string Email { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }
    }
}
