using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankApplication.Models.ViewModels
{
    public class PersonUpdateViewModel
    {
        [Required]
        [EmailAddress]
        [UIHint("email")]
        public string Email { get; set; }

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
