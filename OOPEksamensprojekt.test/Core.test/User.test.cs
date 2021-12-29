using System;
using OOPEksamensprojekt.Core;
using Xunit;

namespace OOPEksamensprojekt.test.Core.test
{
    public class UserTest
    {
        [Fact]
        public void TestUsernameValidationWithLegalUsername()
        {
            string username = "arthur_z09";
                
            User user = new User(1,"arthur", "osnes", username, "agottl20@student.aau.dk", 1000);

            Assert.NotNull(user);
            
        }

        [Theory]
        [InlineData("Arthur")]
        [InlineData("FedtMule")]
        [InlineData("fedtMule")]
        [InlineData("arthur!")]
        [InlineData("arthurZ#%")]
        [InlineData("!arthur")]
        public void TestUsernameValidationWithIllegalUsername(string username)
        {
            Assert.Throws<ArgumentException>(() => { new User(1, "arthur", "osnes", username, "agottl20@student.aau.dk", 1000);});
        }

        [Fact]
        public void TestEmailValidationWithLegalEmail()
        {
            // string regex = @"([a-zA-Z0-9_\-\.]+)@[^\-\.]([a-zA-Z0-9_\-\.]+).([a-zA-Z0-9_\-\.]+)[^\-\.$]";
            string email = "Aagottl_-.zZ209@Aa_-.studentzZ09.AauzZ09.dk";
            //
            // Assert.Matches(regex, email);
            
            User user = new User(1, "arthur", "osnes", "arthur", email, 1000);

            Assert.NotNull(user);
            
        }

        [Theory]
        [InlineData("eksempel(2)@mit_domain.dk")]
        [InlineData("eksempel2@-mit_domain.dk")]
        [InlineData("eksempel2@mit_domain.dk-")]
        [InlineData("eksempel2@.mit_domain.dk")]
        [InlineData("eksempel2@mit_domain.dk.")]
        [InlineData("$arthur@gmail.com")]
        public void TestEmailValidationWithIllegalEmail(string email)
        {

            Assert.Throws<ArgumentException>(() => { new User(1, "arthur", "osnes", "arthur", email, 1000);});
        }

        [Fact]
        public void BalanceNotificationEventRaisedTest()
        {
            User user = new User(1, "Arthur", "Osnes Gottlieb", "arthur", "agottl20@student.aau.dk", 100);
            bool isRaised = false;
            user.BalanceChange += (user1, balance) => { isRaised = true;};
            user.Balance += 10;
            
            Assert.True(isRaised);
        }
        
        
        
    }
}