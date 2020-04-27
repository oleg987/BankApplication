using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApplication.Models
{
    public class Bank
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }

        public Bank()
        {
            Id = 1;
            Title = "MegaBank";
            Address = "WallStreet 1";
        }
    }
}
