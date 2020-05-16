using BankApplication.Models.Entities;
using System;
using System.Collections.Generic;

namespace BankApplication.Models.Entities
{
    public partial class Employee
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int BranchId { get; set; }
        public int PositonId { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Position Position { get; set; }
        public virtual Person Person { get; set; }
    }
}
