using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Core.Entities.Machine;
using VendingMachine.Core.OrderManager;
using VendingMachine.Core.Services;

namespace VendingMachine.Tests.Mocks
{
    public class VendingMachineMock : Core.Entities.Machine.VendingMachine
    {
        public VendingMachineMock(IAccountVerificationService accountVerificationService, IOrderManager orderManager) 
            : base(accountVerificationService, orderManager)
        {
        }

        public static void ResetForTesting()
        {
            _singletonInstance = null;
        }
    }
}
