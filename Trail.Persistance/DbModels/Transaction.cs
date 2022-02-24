namespace Trail.Api.DbModels
{
    public class Transaction:Base
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public decimal Amount { get; set; }
        public string? Currency { get; set; }

        public int AccountNumber { get; set; }
        public virtual Account? Account { get; set; }

        // transaction type enum
        public enum TransactionType
        {
            Deposit = 0,
            Withdraw = 1
        }

        // helpers
        public TransactionType GetTransactionType()
        {
            return (TransactionType)Type;
        }
    }
}
