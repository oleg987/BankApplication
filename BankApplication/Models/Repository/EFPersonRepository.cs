using BankApplication.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BankApplication.Models.Repository
{
    public class EFPersonRepository : IPersonRepository
    {
        private DataDbContext ctx;

        public EFPersonRepository(DataDbContext ctx)
        {
            this.ctx = ctx;
        }

        public IQueryable<Person> GetAll()
        {
            var persons = ctx.Persons
                .Include(p => p.Client)
                .Include(p => p.Employee)
                .Where(p => p.IsDeleted == false);
                
            return persons;
        }

        public Person GetById(int id)
        {
            // SELECT * FROM PERSONS WHERE ID=1;
            var person = ctx.Persons
                .Include(p => p.Client)
                .Include(p => p.Employee)
                .FirstOrDefault(p => p.Id == id);

            return person;
        }

        public void Update(Person person)
        {
            //ctx.Persons.Update(person);
            //ctx.SaveChanges();

            ctx.Entry(person).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var person = ctx.Persons.FirstOrDefault(p => p.Id == id && p.IsDeleted == false);

            //if (person != null)
            //{
            //    ctx.Persons.Remove(person);
            //    ctx.SaveChanges();
            //}
            if(person != null) 
            {
                person.IsDeleted = true;
                ctx.Entry(person).State = EntityState.Modified;
            }            
        }

        public void Restore(int id)
        {
            var person = ctx.Persons.FirstOrDefault(p => p.Id == id && p.IsDeleted == true);

            if (person != null)
            {
                person.IsDeleted = false;
                ctx.Entry(person).State = EntityState.Modified;
            }
        }

        public void Create(Person person)
        {
            ctx.Persons.Add(person);
        }
    }
}
