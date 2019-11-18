using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CommunityWebsite.Controllers;
using CommunityWebsite.Models;

namespace CommunityWebsiteTests
{
    public class UserRepoTests
    {
        [Fact]
        public void AddRemoveUser()
        {
            // ALSO AN IMPLICIT TEST OF USERLIST GETTER
            // arrange 
            var messageRepo = new FakeMessageRepo();
            var userRepo = new FakeUserRepo();
            //var messagingController = new MessagingController(userRepo, messageRepo);

            // act
            var user = new User("BOB");

            // assert
            Assert.Equal(user,userRepo.ListOfUsers[list])
        }

        [Fact]
        public void AddRemoveMessageHistory()
        {
            // arrange 
            // act
            // assert
        }

        [Fact]
        public void AddRemoveReplies()
        {
            // arrange 
            // act
            // assert
        }

        [Fact]
        public void FindReplaceUser()
        {
            // arrange 
            // act
            // assert
        }


    }
}
