using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;

namespace BankApplication.Models.Entities
{
    public enum TransactionType
    {
        Put = 1,
        Withdrawal = 2
    }

    public enum TransactionStatus
    {
        Success = 1,
        Error = 2,
        In_Process = 3,
        Canceled = 4
    }

    public class Transaction
    {
        public int Id { get; set; }
        public int? FromId { get; set; }
        public int? ToId { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public TransactionStatus Status { get; set; }
        public DateTime Created { get; set; }

        [ForeignKey("FromId")]
        public virtual Account From { get; set; }
        [ForeignKey("ToId")]
        public virtual Account To { get; set; }

    }
}
