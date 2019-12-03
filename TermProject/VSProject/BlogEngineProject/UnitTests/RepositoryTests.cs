using System;
using Xunit;
using BlogEngineProject.Models;
using BlogEngineProject.Repositories;
using BlogEngineProject;
using System.Collections.Generic;
using BlogEngineProject.Models;
using BlogEngineProject.Repositories;

namespace UnitTests
{
    public class RepositoryTests
    {
        // THREAD REPO TESTS
        [Fact]
        public void AddThreads()
        {
            // arrange
            FakeThreadRepo threadRepo = new FakeThreadRepo();

            const string bio = "hello there friends";
            const string name = "testThread";
            const string creatorName = "bob";
            const string category = "games and music";
            int id = ObjectIDBuilder.GetThreadID();
            Thread thread1 = new Thread()
            {
                ThreadID = id,
                Name = name,
                CreatorName = creatorName,
                Bio = bio,
                Category = category
            };

            // act
            threadRepo.AddThreadtoRepo(thread1); // add thread
            List<Thread> threads = threadRepo.GetThreads(); // get thread
            Thread foundThread = null; // found thread
            foreach(Thread t in threads)
            {
                if (t == thread1)
                    foundThread = t;
            }

            // Assert
            Assert.Equal(thread1.Name, foundThread.Name);
            Assert.Equal(thread1.Category, foundThread.Category);
            Assert.Equal(thread1.CreatorName, foundThread.CreatorName);
        }

        [Fact]
        public void RemoveThreads()
        {
            // arrange
            FakeThreadRepo threadRepo = new FakeThreadRepo();

            const string bio = "hello there friends";
            const string name = "testThread";
            const string creatorName = "bob";
            const string category = "games and music";
            int id = ObjectIDBuilder.GetThreadID();
            Thread thread1 = new Thread()
            {
                ThreadID = id,
                Name = name,
                CreatorName = creatorName,
                Bio = bio,
                Category = category
            };
            threadRepo.AddThreadtoRepo(thread1); // add thread

            // act 
            Thread removedThread = threadRepo.RemoveThreadfromRepo(id); // remove thread

            // assert
            Assert.Equal(thread1.Name, removedThread.Name);
            Assert.Equal(thread1.Category, removedThread.Category);
            Assert.Equal(thread1.CreatorName, removedThread.CreatorName);
        }

        [Fact]
        public void GetThreads()
        {
            // arrange
            FakeThreadRepo threadRepo = new FakeThreadRepo();

            const string bio = "hello there friends";
            const string name = "testThread";
            const string creatorName = "bob";
            const string category = "games and music";
            int id = ObjectIDBuilder.GetThreadID();
            Thread thread1 = new Thread()
            {
                ThreadID = id,
                Name = name,
                CreatorName = creatorName,
                Bio = bio,
                Category = category
            };
            threadRepo.AddThreadtoRepo(thread1); // add thread

            // act 
            Thread foundThread = threadRepo.GetThreadById(id); // found thread with id
            Thread foundThread2 = threadRepo.GetThreadByName(name); // found thread with name

            // assert (test if the thread was found with id)
            Assert.Equal(thread1.Name, foundThread.Name);
            Assert.Equal(thread1.Category, foundThread.Category);
            Assert.Equal(thread1.CreatorName, foundThread.CreatorName);

            // assert (test if the thread was found with name)
            Assert.Equal(thread1.Name, foundThread2.Name);
            Assert.Equal(thread1.Category, foundThread2.Category);
            Assert.Equal(thread1.CreatorName, foundThread2.CreatorName);
        }

        // USER REPO TESTS

    }
}
