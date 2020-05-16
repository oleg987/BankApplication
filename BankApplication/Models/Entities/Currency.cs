using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApplication.Models.Entities
{
    public enum CurrencyName
    {
        UAH = 1,
        USD = 2,
        EUR = 3
    }

    public class Currency
    {
        public int Id { get; set; }
        public CurrencyName Name { get; set; }
    }
}
