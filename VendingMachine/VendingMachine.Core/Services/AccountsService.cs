using System.Collections.Generic;
using System.Linq;
using VendingMachine.Core.Entities.Account;

namespace VendingMachine.Core.Services
{
    public class AccountsService : IAccountsService
    {
        public IList<IAccount> Accounts { get; set; }
        public IAccount GetAccountByName(string name)
        {
            return Accounts.Single(i => i.Name == name);
        }

        public AccountsService()
        {
            Accounts = GetAccounts();
        }

        private IList<IAccount> GetAccounts()
        {
            return new List<IAccount>()
            {
                new VendingAccount { Name = "Jack", Balance = 1250, Pin = 010},
                new VendingAccount { Name = "Sam", Balance = 0, Pin = 222},
                new VendingAccount { Name = "Dennise", Balance = 1255, Pin = 111},
                new VendingAccount { Name = "Lara", Balance = 49, Pin = 100},
                new VendingAccount { Name = "Melissa", Balance = -100, Pin = 022},
                new VendingAccount { Name = "George", Balance = 2000, Pin = 023},
                new VendingAccount { Name = "Adam", Balance = 250, Pin = 123},
                new VendingAccount { Name = "Mike", Balance = 1000, Pin = 121},
                new VendingAccount { Name = "Paul", Balance = 50, Pin = 001}
            };
        }
    }
}
