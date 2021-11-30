using System;
using System.Runtime.InteropServices;
using Xunit;
using OOPEksamensprojekt;

namespace OOPEksamensprojekt.test
{
    public class UserTest
    {
        [Fact]
        public void TestUsernameValidationWithLegalUsername()
        {
            string username = "arthur_z09";
            string regex = @"([^a-z0-9_]+)";
            Assert.DoesNotMatch(regex, username);
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
            string regex = @"^([a-z0-9_]+)$";
            
            Assert.DoesNotMatch(regex, username);
        }

        [Fact]
        public void TestEmailValidationWithLegalEmail()
        {
            string regex = @"([a-zA-Z0-9_\-\.]+)@[^\-\.]([a-zA-Z0-9_\-\.]+).([a-zA-Z0-9_\-\.]+)[^\-\.$]";
            string email = "Aagottl_-.zZ209@Aa_-.studentzZ09.AauzZ09.dk";
            
            Assert.Matches(regex, email);
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
            string regex = @"^([a-zA-Z0-9_\-\.]+)@[^\-\.]([a-zA-Z0-9_\-\.]+).([a-zA-Z0-9_\-\.]+)[^\-\.]$";

            Assert.DoesNotMatch(regex, email);
        }
        
        
        
    }
}