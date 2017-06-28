using System.Xml;
using VendingMachine.Core.Entities.Account;
using VendingMachine.Core.Entities.Machine;

namespace VendingMachine.Core.OrderManager
{
    public interface IOrderManager
    {
        void UpdateAccountAndInventory(IVendingMachine vendingMachine, int quantity);
    }
}
