using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankApplication.Models.Entities
{
    public enum AccountStatus
    {
        Open = 1,
        Closed,
        Blocked,
        On_Check
    }

    public class Account
    {
        public int Id { get; set; }        
        public string Number { get; set; }        
        public decimal StartCapital { get; set; }
        public decimal Balance { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public AccountStatus Status { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
        public virtual InterestRate InterestRate { get; set; }        
        public virtual ICollection<Transaction> Transactions { get; set; }

        public Account()
        {
            Transactions = new HashSet<Transaction>();
        }
    }
}
