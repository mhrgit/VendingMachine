using System.Collections.Generic;
using VendingMachine.Core.Entities.Account;

namespace VendingMachine.Core.Services
{
    public interface IAccountVerificationService
    {
        bool VerifyAccount(IAccount account, int pin);
    }
}
