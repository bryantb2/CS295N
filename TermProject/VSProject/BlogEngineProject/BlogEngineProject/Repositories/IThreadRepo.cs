using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogEngineProject.Models;

namespace BlogEngineProject.Repositories
{
    public interface IThreadRepo
    {
        List<Thread> GetThreads();
        List<Thread> GetCategoryOfThreads(int categoryIndex);
        Thread GetThreadById(int threadId);
        Thread GetThreadByName(string threadname);
        Thread RemoveThreadfromRepo(int threadID);
        bool GetThreadnameEligibility(string username);
        void AddThreadtoRepo(Thread thread);
    }
}
