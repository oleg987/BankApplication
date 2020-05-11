using System;
using System.Collections.Generic;

namespace BankApplication.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public int? Name { get; set; }
        public int? BranchId { get; set; }

        public virtual Branch Branch { get; set; }
    }
}
