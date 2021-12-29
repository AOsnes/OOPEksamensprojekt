using OOPEksamensprojekt.Core.Exceptions;

namespace OOPEksamensprojekt.Core
{
    public class BuyTransaction : Transaction
    {
        public Product BoughtProduct { get; private set; }
        private int _amount;
        
        public BuyTransaction(Product boughtProduct, User transactionUser, int amount) : base(transactionUser, boughtProduct.Price)
        {
            BoughtProduct = boughtProduct;
            _amount = amount;
        }

        public override void Execute()
        {
            if (BoughtProduct.CanBeBoughtOnCredit)
            {
                TransactionUser.Balance -= (Value * _amount);
            } 
            else if (TransactionUser.Balance > (Value * _amount))
            {
                TransactionUser.Balance -= (Value * _amount);
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