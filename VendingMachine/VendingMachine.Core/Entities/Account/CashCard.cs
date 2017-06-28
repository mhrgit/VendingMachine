namespace VendingMachine.Core.Entities.Account
{
    public class CashCard : ICashCard
    {
        public IAccount Account { get; set; }

        public CashCard(IAccount account)
        {
            Account = account;
        }
    }
}