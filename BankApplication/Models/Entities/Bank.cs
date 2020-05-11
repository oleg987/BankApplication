using System;
using System.Collections.Generic;

namespace BankApplication.Models
{
    public partial class Bank
    {
        public Bank()
        {
            Branch = new HashSet<Branch>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Branch> Branch { get; set; }
    }
}
