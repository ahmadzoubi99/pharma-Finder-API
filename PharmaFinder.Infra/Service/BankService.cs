using PharmaFinder.Core.Data;
using PharmaFinder.Core.Repository;
using PharmaFinder.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Infra.Service
{
    public class BankService : IBankService
    {
        private readonly IBankRepository _bankRepository;

        public BankService(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public List<Bank> GetAllBanks()
        {
            return _bankRepository.GetAllBanks();
        }

        public Bank GetBankById(decimal bankId)
        {
            return _bankRepository.GetBankById(bankId);
        }

        public void CreateBank(Bank bank)
        {
            _bankRepository.CreateBank(bank);
        }

        public void UpdateBank(Bank bank)
        {
            _bankRepository.UpdateBank(bank);
        }

        public void DeleteBank(decimal bankId)
        {
            _bankRepository.DeleteBank(bankId);
        }
    }
}
