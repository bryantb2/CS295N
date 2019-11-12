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
        public static void AddThreadtoRepo(Thread thread)
        {
            if (IsThreadnameValid(thread.Name) == true)
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
        
        private static bool IsThreadnameValid(String threadName)
        {
            // looks through the thread list for an identical threadname string
            // if the threadname is unique, return true
            foreach (Thread t in activeThreads)
            {
                if (t.Name == threadName)
                    return false;
            }
            return true;
        }
    }
}
