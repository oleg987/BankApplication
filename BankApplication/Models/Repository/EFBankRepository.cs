using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Models.Entities;

namespace BankApplication.Models.Repository
{

    public class EFBankRepository : IBankRepository
    {
        private DataDbContext ctx;

        public EFBankRepository(DataDbContext ctx)
        {
            this.ctx = ctx;
        }

        public Bank Get()
        {
            return ctx.Banks.FirstOrDefault();
        }

        public void Update(Bank entity)
        {
            ctx.Banks.Update(entity);
        }
    }
}
