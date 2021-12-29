using OOPEksamensprojekt.Core;
using OOPEksamensprojekt.Core.Exceptions;
using Xunit;

namespace OOPEksamensprojekt.test.Core.test
{
    public class BuyTransaction_test
    {
        [Fact]
        public void UserBuysOneProductTest()
        {
            User user = new User(1, "Arthur", "Osnes Gottlieb", "arthur", "agottl20@student.aau.dk", 100);
            Product product = new Product(1837, "Monster", 12, true);
            BuyTransaction transaction = new BuyTransaction(product, user, 1);
            transaction.Execute();
            
            Assert.Equal(88, user.Balance);
        }

        [Fact]
        public void UserBuysMultipleProductsTest()
        {
            User user = new User(1, "Arthur", "Osnes Gottlieb", "arthur", "agottl20@student.aau.dk", 100);
            Product product = new Product(1837, "Monster", 12, true);
            BuyTransaction transaction = new BuyTransaction(product, user, 5);
            transaction.Execute();
            
            Assert.Equal(40, user.Balance);
        }
        
        [Fact]
        public void UserHasInsufficientFundsToBuyOneProductTest()
        {
            User user = new User(1, "Arthur", "Osnes Gottlieb", "arthur", "agottl20@student.aau.dk", 100);
            Product product = new Product(1837, "Monster", 120, true);
            BuyTransaction transaction = new BuyTransaction(product, user, 1);

            Assert.Throws<InsufficientCreditsException>(() => transaction.Execute());
        }

        [Fact]
        public void UserHasInsufficientFundsToBuyMultipleProductsTest()
        {
            User user = new User(1, "Arthur", "Osnes Gottlieb", "arthur", "agottl20@student.aau.dk", 100);
            Product product = new Product(1837, "Monster", 12, true);
            BuyTransaction transaction = new BuyTransaction(product, user, 10);

            Assert.Throws<InsufficientCreditsException>(() => transaction.Execute());
        }
    }
}