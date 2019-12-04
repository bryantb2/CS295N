using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityWebsite.Models;

namespace CommunityWebsite.Respositories
{
    public class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices.GetRequiredService<AppDbContext>();
            context.Database.EnsureCreated();

            const string CHAT_ROOM_GENERAL = "general";
            const string CHAT_ROOM_STARWARS = "starwars";

            if (!context.Users.Any())
            {
                RealUserRepo userRepo = new RealUserRepo(context);
                RealMessageRepo messageRepo = new RealMessageRepo(context);
                // Add users
                User user = new User() { Username = "Robert" };
                Message message = new Message
                {
                    MessageTitle = "God I hope this works",
                    MessageContent = "Here is my message!",
                    Topic = CHAT_ROOM_GENERAL,
                    UserNameSignature = user.Username,
                    UnixTimeStamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds
                };
                message.UserNameSignature = user.Username;

                User user2 = new User() { Username = "Bob" };
                Message message2 = new Message
                {
                    MessageTitle = "Hello world!",
                    MessageContent = "Test message content",
                    Topic = CHAT_ROOM_GENERAL,
                    UserNameSignature = user2.Username,
                    UnixTimeStamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds
                };
                message2.UserNameSignature = user2.Username;

                // add users and messages to DB
                /*context.Users.Add(user);
                context.Messages.Add(message);*/
                user.AddMessageToHistory(message);
                userRepo.AddNewUser(user);
                messageRepo.addMessageToBoard("",message);


                /*context.Users.Add(user2);
                context.Messages.Add(message2);*/
                user2.AddMessageToHistory(message2);
                userRepo.AddNewUser(user2);
                messageRepo.addMessageToBoard("", message2);
                context.SaveChanges();

                //context.SaveChanges(); // save all the data
            }
        }
    }
}
