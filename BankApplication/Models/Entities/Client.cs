using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApplication.Models.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public int PersonId { get; set; }        
        public DateTime RegistrationDate { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }

        public Client()
        {
            Accounts = new HashSet<Account>();
        }
    }
}
