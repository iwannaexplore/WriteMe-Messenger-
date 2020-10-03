using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WriteMe.Data.Entities;
using WriteMe.Data.Repository.Interface;

namespace WriteMe.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ApplicationDbContext _context;

        private int CurrentUserId =>
            int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        private string CurrentUserEmail =>
            _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);

        public Repository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public string GetCurrentUserEmail()
        {
            return CurrentUserEmail;
        }

        public List<User> GetCurrentUserFriends()
        {
            var friendList = _context.FriendLists.Include(fl => fl.FriendListUsers)
                .Where(fl =>
                    fl.FriendListUsers.Any(flu => flu.UserId == CurrentUserId))
                .ToList();

            List<User> users = new List<User>();
            foreach (var list in friendList)
            {
                users.AddRange(_context.Users.Include(u => u.FriendListUsers)
                    .Where(u => u.FriendListUsers.Any(flu => flu.FriendListId == list.Id) && u.Id != CurrentUserId));
            }

            return users;
        }

        public Chat GetChatOfTwoUsers(int firstUserId, int secondUserId)
        {
            return _context.Chats.Include(c => c.FriendList).ThenInclude(fl => fl.FriendListUsers)
                .Include(c => c.Messages)
                .FirstOrDefault(c =>
                    c.FriendList.FriendListUsers.Any(flu => flu.UserId == firstUserId) &&
                    c.FriendList.FriendListUsers.Any(flu => flu.UserId == secondUserId));
        }

        public List<Message> GetMessagesForChatWithSelectedFriend(int friendId)
        {
            return _context.Messages.Include(m => m.RelatedUser)
                .Where(m => m.ChatId == GetChatOfTwoUsers(CurrentUserId, friendId).ChatId)
                .ToList();
        }

        public User GetUserById(int userId)
        {
            return _context.Users.First(u => u.Id == userId);
        }

        public User GetUserByEmail(string userEmail)
        {
            return _context.Users.First(u => u.Email == userEmail);
        }

        public string GetFriendRelationshipString(int friendId)
        {
            return _context.FriendLists.Include(flr => flr.FriendsRelationship)
                .Include(flr => flr.FriendListUsers).First(fl =>
                    fl.FriendListUsers.Any(flu => flu.UserId == CurrentUserId) &&
                    fl.FriendListUsers.Any(flu => flu.UserId == friendId)).FriendsRelationship.Name;
        }

        public void ChangeRelationshipBetweenUserAndFriend(int friendId)
        {
            var friendList = _context.FriendLists.Include(flr => flr.FriendsRelationship)
                .Include(flr => flr.FriendListUsers).First(fl =>
                    fl.FriendListUsers.Any(flu => flu.UserId == CurrentUserId) &&
                    fl.FriendListUsers.Any(flu => flu.UserId == friendId));

            friendList.FriendsRelationshipId = friendList.FriendsRelationshipId == 1 ? 2 : 1;
            _context.SaveChanges();
        }

        public void AddNewMessage(string fromUserEmail, string toUserEmail, string message)
        {
            Chat currentChat = GetChatOfTwoUsers(GetUserByEmail(fromUserEmail).Id, GetUserByEmail(toUserEmail).Id);

            _context.Messages.Add(new Message()
            {
                ChatId = currentChat.ChatId,
                RelatedUserId = GetUserByEmail(fromUserEmail).Id,
                RelatingUserId = GetUserByEmail(toUserEmail).Id,
                SendingTime = DateTime.Now,
                Text = message
            });
            _context.SaveChanges();
        }
    }
}