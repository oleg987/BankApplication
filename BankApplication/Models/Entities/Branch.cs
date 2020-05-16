using System;
using System.Collections.Generic;

namespace BankApplication.Models.Entities
{
    public partial class Branch
    {
        public Branch()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public int BankId { get; set; }

        public virtual Bank Bank { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
