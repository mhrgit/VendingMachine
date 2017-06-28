using System;
using System.Collections.Generic;
using VendingMachine.Core.Entities.Account;
using VendingMachine.Core.Services;

namespace VendingMachine.Core.Entities.Machine
{
    public interface IVendingMachine
    {
        void ProcessOrder(ICashCard cashCard, int pin, int quantity);
        int Inventory { get; set; }
        VendingMachineState State { get; set; }
    }
}
