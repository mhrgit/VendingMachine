using NUnit.Framework;
using VendingMachine.Core.OrderManager;

namespace VendingMachine.Tests.Tests
{
    [TestFixture]
    public class AccountBalanceTests
    {
        [Test]
        public void Should_Update_Balance_Correctly_With_Successful_Purchase()
        {
            // Adam has 250 in the account - please refer to AccountsService
            var init = new Initialization("Adam");
            var account = init.Account;
            var cashCard = init.CashCard1;

            var vendingMachine = init.VendingMachine;
            const int pin = 123;
            const int quantity = 2;

            vendingMachine.ProcessOrder(cashCard, pin, quantity);

            var expectedResult = 150;
            var result = account.Balance;

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Should_Process_Order_When_Maximum_Number_Of_Cans_Requested_With_Sufficient_Account_Balance()
        {
            // Jack has 1250 in the account - please refer to AccountsService
            var init = new Initialization("Jack");
            var account = init.Account;
            var cashCard = init.CashCard1;

            var vendingMachine = init.VendingMachine;
            const int pin = 010;
            const int quantity = 25;

            vendingMachine.ProcessOrder(cashCard, pin, quantity);

            var expectedResult = 0;
            var result = account.Balance;

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Should_Not_Process_Order_When_Maximum_Number_Of_Cans_Requested_With_Unsufficient_Account_Balance()
        {
            // Mike has 1000 in the account - please refer to AccountsService
            var init = new Initialization("Mike");
            var cashCard = init.CashCard1;

            var vendingMachine = init.VendingMachine;
            const int pin = 121;
            const int quantity = 25;

            Assert.Throws(typeof(InvalidOrderRequestException), 
                () => vendingMachine.ProcessOrder(cashCard, pin, quantity) );
        }

        [Test]
        public void Should_Not_Process_Order_When_Account_Balance_Is_Zero()
        {
            // Sam has 0 in the account - please refer to AccountsService
            var init = new Initialization("Sam");
            var cashCard = init.CashCard1;

            var vendingMachine = init.VendingMachine;
            const int pin = 222;
            const int quantity = 5;

            Assert.Throws(typeof(InvalidOrderRequestException),
               () => vendingMachine.ProcessOrder(cashCard, pin, quantity));
        }

        [Test]
        public void Should_Not_Process_Order_When_Account_Balance_Is_In_Minus()
        {
            // Melissa has -100 in the account - please refer to AccountsService
            var init = new Initialization("Melissa");
            var cashCard = init.CashCard1;

            var vendingMachine = init.VendingMachine;
            const int pin = 022;
            const int quantity = 1;

            Assert.Throws(typeof(InvalidOrderRequestException),
               () => vendingMachine.ProcessOrder(cashCard, pin, quantity));
        }

        [Test]
        public void Should_Not_Process_Order_When_Number_Of_Cans_Requested_Is_Zero()
        {
            // Adam has 250 in the account - please refer to AccountsService
            var init = new Initialization("Adam");
            var cashCard = init.CashCard1;

            var vendingMachine = init.VendingMachine;
            const int pin = 123;
            const int quantity = 0;

            Assert.Throws(typeof(InvalidOrderRequestException),
                () => vendingMachine.ProcessOrder(cashCard, pin, quantity));
        }

        [Test]
        public void Should_Not_Process_Order_When_Number_Of_Cans_Requested_Is_In_Minus()
        {
            // Adam has 250 in the account - please refer to AccountsService
            var init = new Initialization("Adam");
            var account = init.Account;
            var cashCard = init.CashCard1;

            var vendingMachine = init.VendingMachine;
            const int pin = 123;
            const int quantity = -2;

            Assert.Throws(typeof(InvalidOrderRequestException),
                () => vendingMachine.ProcessOrder(cashCard, pin, quantity));
        }
    }
}
