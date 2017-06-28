using VendingMachine.Core.Entities.Account;
using VendingMachine.Core.Entities.Machine;
using VendingMachine.Core.OrderManager;
using VendingMachine.Core.Services;
using VendingMachine.Tests.Mocks;

namespace VendingMachine.Tests
{
    public class Initialization
    {
        public IAccount Account { get; set; }
        public IVendingMachine VendingMachine { get; set; }
        public CashCard CashCard1 { get; set; }
        public CashCard CashCard2 { get; set; }

        public Initialization(string accountName)
        {
            var accountService = new AccountsService();
            Account = accountService.GetAccountByName(accountName);
            CashCard1 = new CashCard(Account);
            CashCard2 = new CashCard(Account);

            //To make these code better, IoC container could be used          
            Account.Balance = accountService.GetAccountByName(accountName).Balance;
            var accountVerificationService = new AccountVerificationService(accountService);
            var orderManager = new OrderManager(Account);

            VendingMachineMock.ResetForTesting();
            VendingMachine = VendingMachineMock.CanVendingMachineInstance(accountVerificationService, orderManager);
        }
    }
}