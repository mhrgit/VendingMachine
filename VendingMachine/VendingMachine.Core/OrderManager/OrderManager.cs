using System;
using VendingMachine.Core.Entities.Account;
using VendingMachine.Core.Entities.Machine;

namespace VendingMachine.Core.OrderManager
{
    public class OrderManager : IOrderManager
    {
        private const decimal PRICE = 50;
        private readonly IAccount _account;
        public OrderManager(IAccount account)
        {
            _account = account;
        }

        public void UpdateAccountAndInventory(IVendingMachine vendingMachine, int quantity)
        {
            lock (_account)
                lock (vendingMachine)
            {
                if (_account.Balance >= quantity*PRICE && quantity <= vendingMachine.Inventory && quantity > 0)
                {
                    _account.Balance -= quantity*PRICE;
                    vendingMachine.Inventory -= quantity;
                    UpdateAccountState(_account);
                    UpdatVendingMachineState(vendingMachine);
                }
                else
                {
                    throw new InvalidOrderRequestException();
                }
            }
        }
        private void UpdateAccountState(IAccount account)
        {
            account.State = account.Balance > 0 ? AccountState.SufficientBalance : AccountState.InsufficientBalance;
        }

        private void UpdatVendingMachineState(IVendingMachine vendingMachine)
        {
            vendingMachine.State = vendingMachine.Inventory > 0 ? VendingMachineState.EnoughCan : VendingMachineState.RunOutOfCan;
        }
    }
}
