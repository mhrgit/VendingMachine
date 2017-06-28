using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using VendingMachine.Core.OrderManager;

namespace VendingMachine.Tests.Tests
{
    [TestFixture]
    public class ConcurrentAccessBalanceAndInventoryTests
    {

        [Test]
        public void Should_Update_Balance_Correctly_If_Account_Accessed_At_The_Same_Time_With_Sufficient_Balance_And_Inventory()
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

            var thread1 = new Thread(() => vendingMachine.ProcessOrder(cashCard1, pin, quantity));
            var thread2 = new Thread(() => vendingMachine.ProcessOrder(cashCard2, pin, quantity));

            thread1.Start();
            thread2.Start();

            var expectedResult = 50;
            var result = account.Balance;

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Should_Not_Process_Second_Order_When_Account_Accessed_At_The_Same_Time_By_2_Cash_Cards_And_There_Is_No_Can_Left_After_First_Order()
        {
            var init = new Initialization("Jack");
            var cashCard1 = init.CashCard1;
            var cashCard2 = init.CashCard2;

            var vendingMachine = init.VendingMachine;
            const int pin = 010;
            const int quantity = 25;
            const int quantity2 = 5;

            InvalidOrderRequestException exception = null;
            var thread1 = new Thread(() => vendingMachine.ProcessOrder(cashCard1, pin, quantity));
            var thread2 = new Thread(() => Execute(() => vendingMachine.ProcessOrder(cashCard2, pin, quantity2), out exception));

            thread1.Start();
            thread2.Start();
            thread2.Join();

            Assert.IsInstanceOfType(typeof(InvalidOrderRequestException), exception);
        }

        private static void Execute(Action test, out InvalidOrderRequestException exception)
        {
            exception = null;

            try
            {
                test.Invoke();
            }
            catch (InvalidOrderRequestException ex)
            {
                exception = ex;
            }
        }

    }
}
