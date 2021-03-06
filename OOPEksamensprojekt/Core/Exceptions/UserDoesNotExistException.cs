using System;

namespace OOPEksamensprojekt.Core.Exceptions
{
    public class UserDoesNotExistException : Exception
    {
        public string Username { get; private set; }
        public UserDoesNotExistException(string username) : base($"{username} does not exist in the system")
        {
            Username = username;
        }
    }
}