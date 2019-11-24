using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogEngineProject.Models
{
    public static class ThreadRepo
    {
        // CLASS FIELDS
        private static List<Thread> activeThreads = new List<Thread>();

        // METHODS
        public static List<Thread> GetThreads() => activeThreads;
        public static Thread GetThreadById(int threadId) => FindThreadById(threadId);
        public static Thread GetThreadByName(string threadname) => FindThreadByName(threadname);
        public static bool GetThreadnameEligibility(string username) => !(IsThreadnameTaken(username));

        public static List<Thread> GetCategoryOfThreads(int categoryIndex)
        {
            string CATEGORY = ThreadCategories.GetCategory(categoryIndex);
            List<Thread> categorySpecificThreads = new List<Thread>();
            // iterate through activeThreads list
            // add a reference to the thread in categorySEpcificThread list
            foreach (Thread t in activeThreads)
            {
                if (t.Category == CATEGORY)
                    categorySpecificThreads.Add(t);
            }
            return categorySpecificThreads;
        }

        public static void AddThreadtoRepo(Thread thread)
        {
            if (IsThreadnameTaken(thread.Name) == false)
            {
                activeThreads.Add(thread);
            }
            else
            {
                throw new ArgumentException("Please make sure that the thread name is unique!");
            }
        }

        public static Thread RemoveThreadfromRepo(int threadID)
        {
            // find thread
            // then remove it
            Thread removedThread = null;
            foreach (Thread t in activeThreads)
            {
                if (t.ThreadID == threadID)
                {
                    removedThread = t;
                    activeThreads.Remove(t);
                }
            }
            return removedThread;
        }
        
        private static bool IsThreadnameTaken(String threadName)
        {
            // looks through the thread list for an identical threadname string
            // if the threadname is taken, return true
            foreach (Thread t in activeThreads)
            {
                if (t.Name == threadName)
                    return true;
            }
            return false;
        }

        private static Thread FindThreadById(int threadId)
        {
            // run foreach loop on userlist
            // return true if current thread's ID matches the parameter
            foreach (Thread t in activeThreads)
            {
                if (t.ThreadID == threadId)
                    return t;
            }
            return null;
        }

        private static Thread FindThreadByName(string threadname)
        {
            // determine if threadName exists
            // run foreach loop on userlist
            // return true if current user's ID matches the parameter
            bool doesThreadExist = IsThreadnameTaken(threadname);
            if (doesThreadExist == true)
            {
                foreach (Thread t in activeThreads)
                {
                    if (t.Name == threadname)
                        return t;
                }
            }
            return null;
        }
    }
}
