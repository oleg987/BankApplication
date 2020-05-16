using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BankApplication.Models
{
    public class RoleCreateModel
    {
        [Required]
        public string Name { get; set; }
    }
}
