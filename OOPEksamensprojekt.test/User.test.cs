using System;
using Xunit;
using OOPEksamensprojekt;

namespace OOPEksamensprojekt.test
{
    public class UnitTest1
    {
        [Fact]
        public void ConstructUserObjectWithLegalName()
        {
            User user = new User("Arthur", "Osnes", "arthur_");
        }
    }
}