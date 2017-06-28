using NUnit.Framework;
using VendingMachine.Core.Entities.Account;
using VendingMachine.Core.Services;

namespace VendingMachine.Tests.Tests
{
    [TestFixture]
    public class AccountVerificationTests
    {
        [Test]
        public void Should_Return_True_If_Name_And_Pin_Match()
        {
            var accountVerificationService = new AccountVerificationService(new AccountsService());
            var account = new VendingAccount { Name = "Jack"};
            var pin = 010;

            var expectedResult = true;
            var result = accountVerificationService.VerifyAccount(account, pin);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Should_Return_False_If_Name_And_Pin_Dont_Match()
        {
            var accountVerificationService = new AccountVerificationService(new AccountsService());
            var account = new VendingAccount { Name = "Jack" };
            var pin = 111;

            var expectedResult = false;
            var result = accountVerificationService.VerifyAccount(account, pin);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Should_Return_False_If_Account_Does_Not_Exist()
        {
            var accountVerificationService = new AccountVerificationService(new AccountsService());
            var account = new VendingAccount { Name = "Xyz" };
            var pin = 111;

            var expectedResult = false;
            var result = accountVerificationService.VerifyAccount(account, pin);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
