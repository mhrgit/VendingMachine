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
    public class VendingMachineInventoryTests
    {
        [Test]
        public void Should_Update_Inventory_After_Successful_Purchase()
        {
            // Adam has 250 in the account - please refer to AccountsService
            var init = new Initialization("Adam");
            var cashCard = init.CashCard1;

            var vendingMachine = init.VendingMachine;
            const int pin = 123;
            const int quantity = 2;

            vendingMachine.ProcessOrder(cashCard, pin, quantity);

            var expectedResult = 23;
            var result = vendingMachine.Inventory;

            Assert.AreEqual(expectedResult, result);

        }

        [Test]
        public void Should_Update_Inventory_To_Zero_If_All_Cans_Purchased()
        {
            // George has 2000 in the account - please refer to AccountsService
            var init = new Initialization("George");
            var cashCard = init.CashCard1;

            var vendingMachine = init.VendingMachine;
            const int pin = 023;
            const int quantity = 25;

            vendingMachine.ProcessOrder(cashCard, pin, quantity);

            var expectedResult = 0;
            var result = vendingMachine.Inventory;

            Assert.AreEqual(expectedResult, result);

        }

        [Test]
        public void Should_Not_Process_Order_When_Number_Of_Requested_Cans_Is_More_Than_Inventory()
        {
            // George has 2000 in the account - please refer to AccountsService
            var init = new Initialization("George");
            var cashCard = init.CashCard1;

            var vendingMachine = init.VendingMachine;
            const int pin = 023;
            const int quantity = 30;

            Assert.Throws(typeof(InvalidOrderRequestException),
                delegate { vendingMachine.ProcessOrder(cashCard, pin, quantity); });

        }

        [Test]
        public void Should_Not_Process_Order_When_Number_Of_Requested_Cans_Is_In_Minus()
        {
            // George has 2000 in the account - please refer to AccountsService
            var init = new Initialization("George");
            var cashCard = init.CashCard1;

            var vendingMachine = init.VendingMachine;
            const int pin = 023;
            const int quantity = -3;

            Assert.Throws(typeof(InvalidOrderRequestException),
                delegate { vendingMachine.ProcessOrder(cashCard, pin, quantity); });

        }
    }
}
