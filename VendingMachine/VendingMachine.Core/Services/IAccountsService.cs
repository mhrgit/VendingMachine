using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Core.Entities.Account;

namespace VendingMachine.Core.Services
{
    public interface IAccountsService
    {
        IList<IAccount> Accounts { get; set; }
        IAccount GetAccountByName(string name);
    }
}
