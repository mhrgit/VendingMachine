using System;
using System.Runtime.Remoting.Channels;
using VendingMachine.Core.Entities.Account;
using VendingMachine.Core.OrderManager;
using VendingMachine.Core.Services;

namespace VendingMachine.Core.Entities.Machine
{
    public class VendingMachine : IVendingMachine
    {
        private readonly IAccountVerificationService _accountVerificationService;
        private readonly IOrderManager _orderManager;
        public int Inventory { get; set; } = 25;
        public VendingMachineState State { get; set; }

        protected static VendingMachine _singletonInstance;

        protected VendingMachine(IAccountVerificationService accountVerificationService, IOrderManager orderManager)
        {
            _accountVerificationService = accountVerificationService;
            _orderManager = orderManager;
            State = VendingMachineState.EnoughCan;            
        }

        public static VendingMachine CanVendingMachineInstance(IAccountVerificationService accountVerificationService, IOrderManager orderManager)
        {
            if (_singletonInstance == null)
            {
                _singletonInstance = new VendingMachine(accountVerificationService, orderManager);
            }

            return _singletonInstance;
        }

        private bool VerifyAccount(IAccount account, int pin)
        {
            return _accountVerificationService.VerifyAccount(account, pin);
        }

        public void ProcessOrder(ICashCard cashCard, int pin, int quantity)
        {
            if (VerifyAccount(cashCard.Account, pin))
            {
                _orderManager.UpdateAccountAndInventory(this, quantity);
            }
            else
            {
                throw new InvalidAccountCredentialsException();
            }
        }
    }
}
