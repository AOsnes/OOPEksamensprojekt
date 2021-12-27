using System;
using System.Runtime.InteropServices;
using Xunit;
using OOPEksamensprojekt;
using OOPEksamensprojekt.StregsystemCore;

namespace OOPEksamensprojekt.test
{
    public class UserTest
    {
        [Fact]
        public void TestUsernameValidationWithLegalUsername()
        {
            string username = "arthur_z09";
                
            User user = new User("arthur", "osnes", username, "agottl20@student.aau.dk");

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
            Assert.Throws<ArgumentException>(() => { new User("arthur", "osnes", username, "agottl20@student.aau.dk");});
        }

        [Fact]
        public void TestEmailValidationWithLegalEmail()
        {
            // string regex = @"([a-zA-Z0-9_\-\.]+)@[^\-\.]([a-zA-Z0-9_\-\.]+).([a-zA-Z0-9_\-\.]+)[^\-\.$]";
            string email = "Aagottl_-.zZ209@Aa_-.studentzZ09.AauzZ09.dk";
            //
            // Assert.Matches(regex, email);
            
            User user = new User("arthur", "osnes", "arthur", email);

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

            Assert.Throws<ArgumentException>(() => { new User("arthur", "osnes", "arthur", email);});
        }
        
        
        
    }
}