using OOPEksamensprojekt.Core;
using Xunit;

namespace OOPEksamensprojekt.test.Core.test
{
    public class Stregsystem_test
    {
        [Fact]
        public void StregsystemReturnsBuyTransaction()
        {
            Stregsystem stregsystem = new Stregsystem();
            User user = new User(1, "Arthur", "Osnes Gottlieb", "arthur", "agottl20@student.aau.dk", 100);
            Product product = new Product(1837, "Monster", 12, true); 
            BuyTransaction transaction = stregsystem.BuyProduct(user, product, 5);
            transaction.Execute();
            Assert.Equal(40, user.Balance);
        }

        [Fact]
        public void StregsystemReturnsInsertCashTransaction()
        {
            Stregsystem stregsystem = new Stregsystem();
            User user = new User(1, "Arthur", "Osnes Gottlieb", "arthur", "agottl20@student.aau.dk", 0);
            InsertCashTransaction transaction = stregsystem.AddCreditsToAccount(user, 100);
            transaction.Execute();
            Assert.Equal(100, user.Balance);
        }

        [Fact]
        public void StregsystemRaisesUserBalanceWarning()
        {
            Stregsystem stregsystem = new Stregsystem();
            bool isRaised = false;
            stregsystem.UserBalanceWarning += (eventUser, balance) => { isRaised = true;};
            User user = new User(1, "Arthur", "Osnes Gottlieb", "arthur", "agottl20@student.aau.dk", 100);
            user.BalanceChange += stregsystem.UserOnBalanceChange;
            Product product = new Product(1837, "Monster", 12, true); 
            BuyTransaction transaction = stregsystem.BuyProduct(user, product, 5);
            transaction.Execute();
            
            Assert.True(isRaised);
        }

        [Fact]
        public void StregsystemReturnsUserByUsername()
        {
            User expectedUser = new User(10, "Laura", "Callahan", "lcall", "lcall@sample.stregsystem.dk", 103000);
            Stregsystem stregsystem = new Stregsystem();
            User actualUser = stregsystem.GetUserByUsername("lcall");
            Assert.Equal(expectedUser, actualUser);
        }
    }
}