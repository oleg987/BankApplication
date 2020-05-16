using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Models.Entities;

namespace BankApplication.Models.Repository
{

    public class EFBankStorage : IRepository<Bank>
    {
        private DataDbContext ctx;

        public EFBankStorage(DataDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Add(Bank entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Bank Get(int id)
        {
            return ctx.Banks.FirstOrDefault(b => b.Id == id);
        }

        public IQueryable<Bank> GetAll()
        {
            return ctx.Banks;
        }

        public void Update(Bank entity)
        {
            ctx.Banks.Update(entity);
        }
    }
}
