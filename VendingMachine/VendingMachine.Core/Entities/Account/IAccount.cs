using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Core.Entities.Account
{
    public interface IAccount
    {
        string Name { get; set; }
        decimal Balance { get; set; }
        byte Pin { get; set; }
        AccountState State { get; set; }
    }
}
