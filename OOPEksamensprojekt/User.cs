using System;

namespace OOPEksamensprojekt
{
    public class User
    {
        public int ID { get; private set; }
        public static int IdCount { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public double Balance { get; private set; }


        public User()
        {
            
        }

        
        
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Firstname} {Lastname} {Email}";
        }
    }
}