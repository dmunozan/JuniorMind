using System;
using System.Collections;

namespace ChatServer
{
    public class ChatServerSide
    {
        private readonly Hashtable users = new Hashtable();

        public bool AddUser(string user)
        {
            if (user == "")
            {
                throw new ArgumentException("Empty string not allowed as user name", nameof(user));
            }

            if (users.ContainsKey(user))
            {
                return false;
            }

            users.Add(user, user);
            return true;
        }
    }
}
