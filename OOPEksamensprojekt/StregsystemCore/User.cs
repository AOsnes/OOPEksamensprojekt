using System;
using System.Text.RegularExpressions;

namespace OOPEksamensprojekt.StregsystemCore
{
    public class User : IComparable
    {
        public int UserId { get; }
        private static int _userIdCount = 0;
        private string _firstname;
        public string Firstname
        {
            get => _firstname;
            private set {
                if (value == null)
                {
                    throw new ArgumentException($"{value} is an invalid firstname");
                }
                _firstname = value;
            } 
        }

        private string _lastname;
        public string Lastname
        {
            get => _lastname;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException($"{value} is an invalid lastname");
                }
                _lastname = value;
            } 
        }

        private string _username;
        public string Username
        {
            get => _username;
            private set
            {
                Regex regex = new Regex("^([a-z0-9_]+)$");
                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException($"{value} is not a valid username");
                }
                _username = value;
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            private set
            {
                Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@[^\-\.]([a-zA-Z0-9_\-\.]+).([a-zA-Z0-9_\-\.]+)[^\-\.]$");
                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException($"{value} is not a valid email");
                }
                _email = value;

            }
        }
        public decimal Balance { get; set; }
        public delegate string UserBalanceNotification(User user, decimal balance);

        public User(string firstname, string lastname, string username, string email)
        {
            Firstname = firstname;
            Lastname = lastname;
            Username = username;
            Email = email;

            UserId = _userIdCount;
            _userIdCount++;
        }

        public User(int userId, string firstname, string lastname, string username, string email, decimal balance)
        {
            Firstname = firstname;
            Lastname = lastname;
            Username = username;
            Email = email;
            UserId = userId;
            Balance = balance;
        }

        
        
        public override bool Equals(object obj)
        {
            User other = obj as User;
            if (other == null)
            {
                return false;
            }
            return UserId == other.UserId && Username.Equals(other.Username);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(UserId.GetHashCode(), Username.GetHashCode());
        }

        public override string ToString()
        {
            return $"Name: {Firstname} {Lastname}, email: {Email}, balance: {Balance}";
        }

        public int CompareTo(object? obj)
        {
            User otherUser = obj as User;
            if (otherUser == null)
            {
                throw new ArgumentException("Object is not a user");
            }

            return UserId.CompareTo(otherUser.UserId);
        }
    }
}
