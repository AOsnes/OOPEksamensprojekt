namespace OOPEksamensprojekt.Core
{
    public class InsertCashTransaction : Transaction
    {
        public InsertCashTransaction(User user, decimal value) : base(user, value)
        {
            
        }

        public override void Execute()
        {
            TransactionUser.Balance += Value;
        }

        public override string ToString()
        {
            return  $"Insert transaction: {base.ToString()}";
        }
    }
}