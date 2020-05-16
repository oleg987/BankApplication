using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApplication.Models.Entities
{
    public enum InterestType
    {
        Long_term = 1,
        Short_term = 2,
        Urgent_term = 3
    }

    public class InterestRate
    {
        public int Id { get; set; }
        public int CurrencyId { get; set; }
        public InterestType Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }

        public virtual Currency Currency { get; set; }
    }
}
