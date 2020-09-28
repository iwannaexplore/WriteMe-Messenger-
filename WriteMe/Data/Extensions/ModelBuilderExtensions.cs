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
            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> {Id = 2, Name = "Admin", NormalizedName = "ADMIN"},
                new IdentityRole<int> {Id = 1, Name = "User", NormalizedName = "USER"});


            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                UserName = "jylie@mail.com",
                NormalizedUserName = "jylie@mail.com".ToUpper(),
                Email = "jylie@mail.com",
                EmailConfirmed = true,
                NormalizedEmail = "jylie@gmail.com".ToUpper(),
                ProfilePicture = "304042a2-29bd-410c-8097-1744461b6c88_I2ff7ApwdMAM.jpg",
                PasswordHash = hasher.HashPassword(null, "_Hum45678"),
                SecurityStamp = string.Empty
            }, new User
            {
                Id = 2,
                UserName = "vika@mail.com",
                NormalizedUserName = "vika@mail.com".ToUpper(),
                Email = "vika@mail.com",
                EmailConfirmed = true,
                NormalizedEmail = "vika@gmail.com".ToUpper(),
                ProfilePicture = "304042a2-29bd-410c-8097-1744461b6c88_photo_2019-01-26_19-32-55.jpg",
                PasswordHash = hasher.HashPassword(null, "_Hum45678"),
                SecurityStamp = string.Empty
            }, new User
            {
                Id = 3,
                UserName = "admin@gmail.com",
                NormalizedUserName = "admin@gmail.com".ToUpper(),
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                NormalizedEmail = "admin@gmail.com".ToUpper(),
                ProfilePicture = "304042a2-29bd-410c-8097-1744461b6c88_photo_2020-03-28_22-57-55.jpg",
                PasswordHash = hasher.HashPassword(null, "_Hum45678"),
                SecurityStamp = string.Empty
            }, new User
            {
                Id = 4,
                UserName = "iwannaexplore@gmail.com",
                NormalizedUserName = "iwannaexplore@gmail.com".ToUpper(),
                Email = "iwannaexplore@gmail.com",
                EmailConfirmed = true,
                NormalizedEmail = "iwannaexplore@gmail.com".ToUpper(),
                ProfilePicture = "304042a2-29bd-410c-8097-1744461b6c88_photo_2020-04-24_17-05-28.jpg",
                PasswordHash = hasher.HashPassword(null, "_Hum45678"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = 2,
                UserId = 1,
            }, new IdentityUserRole<int>
            {
                RoleId = 2,
                UserId = 2,
            }, new IdentityUserRole<int>
            {
                RoleId = 1,
                UserId = 3,
            }, new IdentityUserRole<int>
            {
                RoleId = 2,
                UserId = 4,
            });

            modelBuilder.Entity<FriendsRelationship>().HasData(new FriendsRelationship()
                {FriendsRelationshipId = 1, Name = "Friend"});
            modelBuilder.Entity<FriendsRelationship>().HasData(new FriendsRelationship()
                {FriendsRelationshipId = 2, Name = "Blocked"});
            modelBuilder.Entity<FriendList>().HasData(new FriendList() {Id = 1, FriendsRelationshipId = 1});
            modelBuilder.Entity<FriendList>().HasData(new FriendList() {Id = 2, FriendsRelationshipId = 1});
            modelBuilder.Entity<FriendList>().HasData(new FriendList() {Id = 3, FriendsRelationshipId = 1});
            modelBuilder.Entity<FriendList>().HasData(new FriendList() {Id = 4, FriendsRelationshipId = 2});
            modelBuilder.Entity<FriendListUser>().HasData(
                new FriendListUser() {FriendListId = 1, UserId = 1},
                new FriendListUser() {FriendListId = 1, UserId = 2},
                new FriendListUser() {FriendListId = 2, UserId = 3},
                new FriendListUser() {FriendListId = 2, UserId = 4},
                new FriendListUser() {FriendListId = 3, UserId = 3},
                new FriendListUser() {FriendListId = 3, UserId = 2},
                new FriendListUser() {FriendListId = 4, UserId = 3},
                new FriendListUser() {FriendListId = 4, UserId = 1}
            );


            modelBuilder.Entity<Chat>().HasData(new Chat() {ChatId = 1, FriendListId = 1});
            modelBuilder.Entity<Message>().HasData(new Message()
            {
                MessageId = 1, ChatId = 1, SendingTime = DateTime.Today.AddHours(-2), Text = "Hello, Vika",
                RelatingUserId = 2, RelatedUserId = 1
            });
            modelBuilder.Entity<Message>().HasData(new Message()
            {
                MessageId = 2, ChatId = 1, SendingTime = DateTime.Today.AddHours(-2).AddMinutes(10),
                Text = "Hello, Julie", RelatingUserId = 1, RelatedUserId = 2
            });


            modelBuilder.Entity<Chat>().HasData(new Chat() { ChatId = 2, FriendListId = 2 });
            modelBuilder.Entity<Message>().HasData(new Message()
            {
                MessageId = 3,
                ChatId = 2,
                SendingTime = DateTime.Today.AddHours(-2),
                Text = "Hello, dimon",
                RelatingUserId = 4,
                RelatedUserId = 3
            });
            modelBuilder.Entity<Message>().HasData(new Message()
            {
                MessageId = 4,
                ChatId = 2,
                SendingTime = DateTime.Today.AddHours(-2).AddMinutes(10),
                Text = "Hello, admin",
                RelatingUserId = 3,
                RelatedUserId = 4
            });
            


            modelBuilder.Entity<Chat>().HasData(new Chat() { ChatId = 3, FriendListId = 3 });
            modelBuilder.Entity<Message>().HasData(new Message()
            {
                MessageId = 5,
                ChatId = 3,
                SendingTime = DateTime.Today.AddHours(-2),
                Text = "Hello, admin",
                RelatingUserId = 3,
                RelatedUserId = 2
            });
            modelBuilder.Entity<Message>().HasData(new Message()
            {
                MessageId = 6,
                ChatId = 3,
                SendingTime = DateTime.Today.AddHours(-2).AddMinutes(10),
                Text = "Hello, Vika",
                RelatingUserId = 2,
                RelatedUserId = 3
            });


            modelBuilder.Entity<Chat>().HasData(new Chat() { ChatId = 4, FriendListId = 4 });
            modelBuilder.Entity<Message>().HasData(new Message()
            {
                MessageId = 7,
                ChatId = 4,
                SendingTime = DateTime.Today.AddHours(-2),
                Text = "Hello, admin",
                RelatingUserId = 3,
                RelatedUserId = 1
            });
            modelBuilder.Entity<Message>().HasData(new Message()
            {
                MessageId = 8,
                ChatId = 4,
                SendingTime = DateTime.Today.AddHours(-2).AddMinutes(10),
                Text = "Hello, julie. Idi v ban",
                RelatingUserId = 1,
                RelatedUserId = 3
            });
            
        }
    }
}