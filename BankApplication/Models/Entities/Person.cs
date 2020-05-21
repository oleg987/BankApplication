using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankApplication.Models.Entities
{
    [Table("Persons")]
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PassportNumber { get; set; }
        public string PassportSeries { get; set; }
        public string Tin { get; set; }

        public string UserId { get; set; }
        public int? EmployeeId { get; set; }
        public int? ClientId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Client Client { get; set; }
    }
}
