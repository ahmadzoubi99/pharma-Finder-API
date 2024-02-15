using PharmaFinder.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Core.Service
{
    public interface IBankService
    {
        List<Bank> GetAllBanks();
        Bank GetBankById(decimal bankId);
        void CreateBank(Bank bank);
        void UpdateBank(Bank bank);
        void DeleteBank(decimal bankId);
    }
}
