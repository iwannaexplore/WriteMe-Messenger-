using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WriteMe.Data.Entities;

namespace WriteMe.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 2, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole<int> { Id = 1, Name = "User", NormalizedName = "USER" });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                UserName = "jylie@mail.com",
                NormalizedUserName = "jylie@mail.com".ToUpper(),
                Email = "jylie@mail.com",
                EmailConfirmed = true,
                NormalizedEmail = "jylie@gmail.com".ToUpper(),
                LastActivityTime = DateTime.Now.AddDays(-1),
                ProfilePicture = ""
            });
           modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
               UserName = "vika@mail.com",
               NormalizedUserName = "vika@mail.com".ToUpper(),
               Email = "vika@mail.com",
                EmailConfirmed = true,
                NormalizedEmail = "vika@gmail.com".ToUpper(),
                LastActivityTime = DateTime.Now.AddDays(-1),
                ProfilePicture = ""
            });
            modelBuilder.Entity<FriendsRelationship>().HasData(new FriendsRelationship(){FriendsRelationshipId = 1, Name = "Friend"});
            modelBuilder.Entity<FriendsRelationship>().HasData(new FriendsRelationship(){FriendsRelationshipId = 2, Name = "Blocked"});
            modelBuilder.Entity<FriendsList>().HasData(new FriendsList() { FriendsListId = 1, FriendRelationshipId = 1,  });
            modelBuilder.Entity<FriendsList>().HasData(new FriendsList() { FriendsListId = 2, FriendRelationshipId = 1,  });
            modelBuilder.Entity<Chat>().HasData(new Chat() { ChatId = 1, FriendListId = 1 });
            modelBuilder.Entity<Chat>().HasData(new Chat() { ChatId = 2, FriendListId = 2 });
            modelBuilder.Entity<Message>().HasData(new Message(){ MessageId = 1, ChatId = 1, SendingTime = DateTime.Today.AddHours(-2), Text = "Hello, Vika",  RelatingUserId = 2});
            modelBuilder.Entity<Message>().HasData(new Message(){ MessageId = 2, ChatId = 1, SendingTime = DateTime.Today.AddHours(-2).AddMinutes(10), Text = "Hello, Julie",  RelatingUserId = 1 });
            modelBuilder.Entity<Message>().HasData(new Message(){ MessageId = 3, ChatId = 1, SendingTime = DateTime.Today.AddHours(-2).AddMinutes(15), Text = "How are you?",  RelatingUserId = 2 });
            modelBuilder.Entity<Message>().HasData(new Message(){ MessageId = 4, ChatId = 1, SendingTime = DateTime.Today.AddHours(-2).AddMinutes(20), Text = "Good", RelatingUserId = 1 });
            modelBuilder.Entity<Message>().HasData(new Message(){ MessageId = 5, ChatId = 1, SendingTime = DateTime.Today.AddHours(-2).AddMinutes(25), Text = "Me too",  RelatingUserId = 2 });
            modelBuilder.Entity<Message>().HasData(new Message(){ MessageId = 6, ChatId = 1, SendingTime = DateTime.Today.AddHours(-2).AddMinutes(30), Text = "Flexim? Vika",  RelatingUserId = 2 });
            modelBuilder.Entity<Message>().HasData(new Message(){ MessageId = 7, ChatId = 2, SendingTime = DateTime.Today.AddDays(-1).AddHours(-2), Text = "Hello, Vika",  RelatingUserId = 2});
            modelBuilder.Entity<Message>().HasData(new Message(){ MessageId = 8, ChatId = 2, SendingTime = DateTime.Today.AddDays(-1).AddHours(-2).AddMinutes(10), Text = "Hello, Julie",  RelatingUserId = 1 });
            modelBuilder.Entity<Message>().HasData(new Message(){ MessageId = 9, ChatId = 2, SendingTime = DateTime.Today.AddDays(-1).AddHours(-2).AddMinutes(15), Text = "How are you?",  RelatingUserId = 2 });
            modelBuilder.Entity<Message>().HasData(new Message(){ MessageId = 10, ChatId = 2, SendingTime = DateTime.Today.AddDays(-1).AddHours(-2).AddMinutes(20), Text = "Good",  RelatingUserId = 1 });
            modelBuilder.Entity<Message>().HasData(new Message(){ MessageId = 11, ChatId = 2, SendingTime = DateTime.Today.AddDays(-1).AddHours(-2).AddMinutes(25), Text = "Me too",  RelatingUserId = 2 });
            modelBuilder.Entity<Message>().HasData(new Message(){ MessageId = 12, ChatId = 2, SendingTime = DateTime.Today.AddDays(-1).AddHours(-2).AddMinutes(30), Text = "Flexim? Vika",  RelatingUserId = 2 });

        }
    }
}