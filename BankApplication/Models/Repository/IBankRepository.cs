﻿using BankApplication.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApplication.Models.Repository
{
    public interface IBankRepository
    {
        Bank Get();
        void Update(Bank bank);
    }
}
