using PharmaFinder.Core.Data;
using System;
using System.Collections.Generic;

namespace PharmaFinder.Core.Repository
{
    public interface IBankRepository
    {
        List<Bank> GetAllBanks();
        Bank GetBankById(decimal bankId);
        void CreateBank(Bank bank);
        void UpdateBank(Bank bank);
        void DeleteBank(decimal bankId);
    }
}
