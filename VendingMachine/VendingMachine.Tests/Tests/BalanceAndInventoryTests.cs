using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using VendingMachine.Core.OrderManager;

namespace VendingMachine.Tests.Tests
{
    [TestFixture]
    public class NonConcurrentAccessBalanceAndInventoryTests
    {

        [Test]
        public void Should_Update_Balance_Correctly_After_2_Subsequent_Purchase_By_2_Different_Cards_With_Same_Account()
        {
            var init = new Initialization("Adam");
            var account = init.Account;
            var cashCard1 = init.CashCard1;
            var cashCard2 = init.CashCard2;

            var vendingMachine = init.VendingMachine;
            const int pin = 123;
            const int quantity = 2;

            vendingMachine.ProcessOrder(cashCard1, pin, quantity);
            vendingMachine.ProcessOrder(cashCard2, pin, quantity);

            var expectedResult2 = 50;
            var result2 = account.Balance;

            Assert.AreEqual(expectedResult2, result2);
        }

        [Test]
        public void Should_Not_Process_2nd_Order_When_Cans_Are_Run_Out_With_First_Order()
        {
            var init = new Initialization("George");
            var cashCard1 = init.CashCard1;
            var cashCard2 = init.CashCard2;

            var vendingMachine = init.VendingMachine;
            const int pin = 023;
            const int quantity = 25;

            vendingMachine.ProcessOrder(cashCard1, pin, quantity);

            var expectedResult = 0;
            var result = vendingMachine.Inventory;

            Assert.AreEqual(expectedResult, result);

            const int quantity2 = 5;
            Assert.Throws(typeof(InvalidOrderRequestException),
                delegate { vendingMachine.ProcessOrder(cashCard2, pin, quantity2); });
        }
    }
}
