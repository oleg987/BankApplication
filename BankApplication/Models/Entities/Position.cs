using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApplication.Models.Entities
{
    public class Position
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int SalaryId { get; set; }

        public virtual Salary Salary { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

        public Position()
        {
            Employees = new HashSet<Employee>();
        }
    }
}
