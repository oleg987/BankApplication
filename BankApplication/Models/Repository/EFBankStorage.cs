using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BankApplication.Models.Repository
{
    public class EFBankStorage : IBankRepository
    {
        private AplicationDataContext ctx;

        public EFBankStorage(AplicationDataContext ctx)
        {
            this.ctx = ctx;
        }

        public Bank GetBank()
        {
            var bank = ctx.Bank.FirstOrDefault();

            return bank;
        }

        public void Update(Bank bank)
        {
            throw new NotImplementedException();
        }
    }
}
