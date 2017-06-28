
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Core.Entities.Account;

namespace VendingMachine.Core.Services
{
    public class AccountVerificationService : IAccountVerificationService
    {
        private readonly IAccountsService _accountsService;
        private IList<IAccount> RegisteredAccounts { get; set; }
        public bool VerifyAccount(IAccount account, int pin)
        {
            return RegisteredAccounts.SingleOrDefault(i => i.Name == account.Name && i.Pin == pin) != null;
        }

        public AccountVerificationService(IAccountsService accountsservice)
        {
            _accountsService = accountsservice;
            RegisteredAccounts = _accountsService.Accounts;
        }
    }
}
