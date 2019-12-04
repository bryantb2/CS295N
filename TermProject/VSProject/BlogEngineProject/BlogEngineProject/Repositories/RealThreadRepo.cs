using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogEngineProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogEngineProject.Repositories
{
    public class RealThreadRepo : IThreadRepo
    {
        // CLASS FIELDS
        private AppDbContext context;

        // CONSTRUCTOR
        public RealThreadRepo(AppDbContext appContext)
        {
            this.context = appContext;
        }

        // METHODS
        public List<Thread> GetThreads() => context.Threads.Include("Posts").ToList();
        public Thread GetThreadById(int threadId) => FindThreadById(threadId);
        public Thread GetThreadByName(string threadname) => FindThreadByName(threadname);
        public bool GetThreadnameEligibility(string username) => !(IsThreadnameTaken(username));

        public List<Thread> GetCategoryOfThreads(int categoryIndex)
        {
            string CATEGORY = ThreadCategories.GetCategory(categoryIndex);
            List<Thread> categorySpecificThreads = new List<Thread>();
            // iterate through activeThreads list
            // add a reference to the thread in categorySEpcificThread list
            List<Thread> repoThreads = GetThreads();
            foreach (Thread t in repoThreads)
            {
                if (t.Category == CATEGORY)
                    categorySpecificThreads.Add(t);
            }
            return categorySpecificThreads;
        }

        public void AddThreadtoRepo(Thread thread)
        {
            if (IsThreadnameTaken(thread.Name) == false)
            {
                context.Threads.Add(thread);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Please make sure that the thread name is unique!");
            }
        }

        public Thread RemoveThreadfromRepo(int threadID)
        {
            // find thread
            // then remove it
            Thread removedThread = null;
            List<Thread> repoThreads = GetThreads();
            foreach (Thread t in repoThreads)
            {
                if (t.ThreadID == threadID)
                {
                    removedThread = t;
                    context.Threads.Remove(t);
                    context.SaveChanges();
                    break;
                }
            }
            return removedThread;
        }

        private bool IsThreadnameTaken(String threadName)
        {
            // looks through the thread list for an identical threadname string
            // if the threadname is taken, return true
            List<Thread> repoThreads = GetThreads();
            foreach (Thread t in repoThreads)
            {
                if (t.Name == threadName)
                    return true;
            }
            return false;
        }

        private Thread FindThreadById(int threadId)
        {
            // run foreach loop on userlist
            // return true if current thread's ID matches the parameter
            List<Thread> repoThreads = GetThreads();
            foreach (Thread t in repoThreads)
            {
                if (t.ThreadID == threadId)
                    return t;
            }
            return null;
        }

        private Thread FindThreadByName(string threadname)
        {
            // determine if threadName exists
            // run foreach loop on userlist
            // return true if current user's ID matches the parameter
            bool doesThreadExist = IsThreadnameTaken(threadname);
            if (doesThreadExist == true)
            {
                List<Thread> repoThreads = GetThreads();
                foreach (Thread t in repoThreads)
                {
                    if (t.Name == threadname)
                        return t;
                }
            }
            return null;
        }
    }
}
