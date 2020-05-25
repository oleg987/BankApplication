using BankApplication.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApplication.Models.Repository
{
    public interface IUserRepository
    {
        Task<bool> Create(ClientCreateViewModel model, string role);
    }
}
