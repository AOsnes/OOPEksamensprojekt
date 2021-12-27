namespace OOPEksamensprojekt.StregsystemCore
{
    public class BuyTransaction : Transaction
    {
        public Product BoughtProduct { get; private set; }
        
        public BuyTransaction(Product boughtProduct, User transactionUser) : base(transactionUser, boughtProduct.Price)
        {
            BoughtProduct = boughtProduct;
        }

        public override void Execute()
        {
            if (BoughtProduct.CanBeBoughtOnCredit)
            {
                TransactionUser.Balance -= Amount;
            } 
            else if (TransactionUser.Balance > Amount)
            {
                TransactionUser.Balance -= Amount;
            }
            else
            {
                throw new InsufficientCreditsException(TransactionUser, BoughtProduct,"Your balance is too low to buy this product");
            }
            
            
        }

        public override string ToString()
        {
            return $"Buy transaction: product: {BoughtProduct} {base.ToString()}";
        }
    }
}