using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApplication.Models.Repository.FakeStorage
{
    public class FakeBankStorage : IBankRepository
    {
        private Bank bank;

        public FakeBankStorage()
        {
            bank = new Bank() { Id = 1, Title = "MegaBank", Address = "Some address"};
        }

        public Bank GetBank()
        {
            return bank;
        }

        public void Update(Bank bank)
        {
            this.bank = bank;
        }
    }
}
