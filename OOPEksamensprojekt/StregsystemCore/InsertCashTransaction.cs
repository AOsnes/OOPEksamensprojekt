namespace OOPEksamensprojekt.StregsystemCore
{
    public class InsertCashTransaction : Transaction
    {
        public InsertCashTransaction(User user, decimal amount) : base(user, amount)
        {
            
        }

        public override void Execute()
        {
            TransactionUser.Balance += Amount;
        }

        public override string ToString()
        {
            return  $"Insert transaction: {base.ToString()}";
        }
    }
}