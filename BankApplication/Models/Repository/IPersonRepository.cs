using BankApplication.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApplication.Models.Repository
{
    public interface IPersonRepository
    {
        Person GetById(int id);
        void Update(Person person);
        void Delete(int id);
        void Restore(int id);

        IQueryable<Person> GetAll();
    }
}
