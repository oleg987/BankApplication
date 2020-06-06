using BankApplication.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApplication.Models.ViewModels
{
    public class PersonIndexViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Passport { get; set; }
        public string Tin { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime RegistrationDate { get; set; }

        //public List<Transaction> Transactions { get; set; }

        //public PersonIndexViewModel()
        //{
        //    Transactions = new List<Transaction>();
        //}
    }
}
