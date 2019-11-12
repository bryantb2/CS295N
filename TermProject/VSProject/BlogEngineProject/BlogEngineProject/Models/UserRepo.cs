using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogEngineProject.Models
{
    public static class UserRepo
    {
        // CLASS FIELDS
        private static List<User> userList = new List<User>();

        public static List<User> GetUsers()
        {
            return userList;
        }

        // METHODS
        public static void AddUsertoRepo(User user)
        {
            if(IsUsernameValid(user.Username) == true)
            {
                userList.Add(user);
            }
            else
            {
                throw new ArgumentException("Please make sure that the username is unique!");
            }
        }

        public static User RemoveUserfromRepo(int userID)
        {
            // find user
            // then remove it
            User removedUser = null;
            foreach (User u in userList)
            {
                if (u.UserID == userID)
                {
                    removedUser = u;
                    userList.Remove(u);
                }
            }
            return removedUser;
        }

        private static bool IsUsernameValid(String username)
        {
            // looks through the user list for an identical username string
            // if the username is unique, return true
            foreach(User u in userList)
            {
                if (u.Username == username)
                    return false;
            }
            return true;
        }
    }
}
