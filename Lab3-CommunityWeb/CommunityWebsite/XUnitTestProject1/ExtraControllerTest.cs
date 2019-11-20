using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CommunityWebsite.Controllers;
using CommunityWebsite.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CommunityWebsiteTests
{
    public class ExtraControllerTest
    {
        [Fact]
        public void DivideTest()
        {
            // ALSO AN IMPLICIT TEST OF USERLIST GETTER
            // arrange 
            const int number1 = 12;
            const int number2 = 4;
            const int expectedResult = 3;
            ExtraController testController = new ExtraController();

            // act
            int result = testController.Divide(number1, number2);

            // assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GetAndReturnPostTitleTest()
        {
            // arrange 
            const string title = "hello world";
            const string content = "this message is a test";
            const string username = "bob";
            const string topic = "aerospace";

            Message message = new Message(title,content,username,topic);
            ExtraController testController = new ExtraController();

            // act
            string result = testController.ReturnPostTitleObject(message);

            // assert
            Assert.Equal(title, result);
        }

        [Fact]
        public void GetNumberOfRepliesTest()
        {
            // arrange 
            const int numberOfReplies = 5;
            const string title = "hello world";
            const string content = "this message is a test";
            const string username = "bob";
            const string topic = "aerospace";

            Message message = new Message(title, content, username, topic);
            for(int i = 0; i< numberOfReplies; i++)
            {
                // generates replies for post
                Reply replyObject = new Reply(i.ToString(), i.ToString());
                message.AddToReplyHistory(replyObject);
            }
            ExtraController testController = new ExtraController();

            // act
            int result = testController.GetNumberOfRepliesOnMessage(message);

            // assert
            Assert.Equal(numberOfReplies, result);
        }

        [Fact]
        public void FindReplaceUser()
        {
            // arrange 
            const bool doesMessageHaveReplies = true;
            const int numberOfReplies = 5;
            const string title = "hello world";
            const string content = "this message is a test";
            const string username = "bob";
            const string topic = "aerospace";

            Message message = new Message(title, content, username, topic);
            for (int i = 0; i < numberOfReplies; i++)
            {
                // generates replies for post
                Reply replyObject = new Reply(i.ToString(), i.ToString());
                message.AddToReplyHistory(replyObject);
            }
            ExtraController testController = new ExtraController();

            // act
            bool result = testController.DoesMessageHaveReplies(message);

            // assert
            Assert.Equal(doesMessageHaveReplies, result);
        }


    }
}
