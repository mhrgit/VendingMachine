namespace VendingMachine.Core.OrderManager
{
    public class InvalidOrderRequestException : System.Exception
    {
        public InvalidOrderRequestException() : base()
        {

        }

        public InvalidOrderRequestException(string message) : base(message)
        {

        }
    }
}
