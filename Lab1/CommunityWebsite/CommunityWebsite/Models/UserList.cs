using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite.Models
{
    public static class UserList
    {
        //CLASS FIELDS
        private static List<User> listOfUsers;

        //PROPERTIES
        public static List<User> GetListOfUsers
        {
            get { return listOfUsers; }
        }

        public static int NumberOfUsers
        {
            get { return listOfUsers.Count; }
        }

        //METHODS
        public static void AddNewUser(User user)
        {
            UserList.listOfUsers.Add(user);
        }

        public static void RemoveUser(string userName, string password)
        {
            foreach (User user in listOfUsers)
            {
                if (user.Username == userName && user.Password == password)
                {
                    UserList.listOfUsers.Remove(user);
                }
            }
        }
    }
}
