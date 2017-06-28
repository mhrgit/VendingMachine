using System.Collections.Generic;

namespace VendingMachine.Core.Entities.Account
{
    public class VendingAccount : IAccount
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public byte Pin { get; set; }
        public AccountState State { get; set; }
        public IList<ICashCard> CashCards { get; set; }

        public VendingAccount()
        {
            CashCards = new List<ICashCard>();
            State = AccountState.SufficientBalance;            
        }
    }
}
