using System;

namespace OOPEksamensprojekt.StregsystemCore
{
    public class ProductDoesNotExistException : Exception
    {
        public int Id { get; private set; }
        public ProductDoesNotExistException(int id) : base($"{id} is not a valid product ID")
        {
            Id = id;
        }
    }
}