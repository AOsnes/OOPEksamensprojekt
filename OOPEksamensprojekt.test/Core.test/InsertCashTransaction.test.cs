using OOPEksamensprojekt.Core;
using Xunit;

namespace OOPEksamensprojekt.test.Core.test
{
    public class InsertCashTransaction_test
    {
        [Fact]
        public void AddCreditsToUserTest()
        {
            User user = new User(1, "Arthur", "Osnes Gottlieb", "arthur", "agottl20@student.aau.dk", 0);
            InsertCashTransaction transaction = new InsertCashTransaction(user, 1000);
            transaction.Execute();
            
            Assert.Equal(1000, user.Balance);
        }
    }
}