using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApplication.Models.Repository
{
    public class UnitOfWork : IDisposable
    {
        private DataDbContext dataDb;
        private SecurityDbContext securityDb;

        private IUserRepository userRepository;
        private IBankRepository bankRepository;
        private IPersonRepository personRepository;

        public UnitOfWork(DataDbContext dataDb, SecurityDbContext securityDb)
        {
            this.dataDb = dataDb;
            this.securityDb = securityDb;
        }

        public IUserRepository UserRepository { 
            get
            {
                if (userRepository == null)
                {
                    userRepository = new EFUserRepository(dataDb, securityDb);
                }

                return userRepository;
            } 
        }
        public IBankRepository BankRepository {
            get
            {
                if(bankRepository == null)
                {
                    bankRepository = new EFBankRepository(dataDb);
                }

                return bankRepository;
            }
        }
        public IPersonRepository PersonRepository { 
            get
            {
                if(personRepository == null)
                {
                    personRepository = new EFPersonRepository(dataDb);
                }

                return personRepository;
            }
        }

        public void SaveChanges()
        {
            dataDb.SaveChanges();
            securityDb.SaveChanges();
        }

        private bool disposed = false;

        private void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                dataDb.Dispose();
                securityDb.Dispose();

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
