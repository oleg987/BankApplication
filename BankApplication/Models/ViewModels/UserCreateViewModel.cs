using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankApplication.Models.ViewModels
{
    public class UserCreateViewModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [EmailAddress]
        [UIHint("email")]
        public string Email { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string PassportNumber { get; set; }

        [Required]
        public string PassportSeries { get; set; }

        [Required]
        public string Tin { get; set; }
    }
}
