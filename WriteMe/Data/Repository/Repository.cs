using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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

        private string CurrentUserEmail => _context.Users.First(u =>
            u.Id == int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))).Email;


        public Repository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task<string> GetCurrentUserEmailAsync()
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == CurrentUserEmail);
            return user.Email;
        }

        public async Task<List<User>> GetCurrentUserFriendsAsync()
        {
            var friendList = await _context.FriendLists.Include(fl => fl.FriendListUsers).ThenInclude(flu => flu.User)
                .Where(fl =>
                    fl.FriendListUsers.Any(flu => flu.User.Email == CurrentUserEmail))
                .ToListAsync();

            List<User> users = new List<User>();
            foreach (var list in friendList)
            {
                users.AddRange(_context.Users.Include(u => u.FriendListUsers).ThenInclude(flu => flu.User)
                    .Where(u => u.FriendListUsers.Any(flu => flu.FriendListId == list.Id) &&
                                u.Email != CurrentUserEmail));
            }

            return users;
        }

        public async Task<Chat> GetChatOfTwoUsersAsync(string firstUserEmail, string secondUserEmail)
        {
            return await _context.Chats.Include(c => c.FriendList).ThenInclude(fl => fl.FriendListUsers)
                .ThenInclude(flu => flu.User)
                .Include(c => c.Messages)
                .FirstOrDefaultAsync(c =>
                    c.FriendList.FriendListUsers.Any(flu => flu.User.Email == firstUserEmail) &&
                    c.FriendList.FriendListUsers.Any(flu => flu.User.Email == secondUserEmail));
        }

        public async Task<List<Message>> GetMessagesForChatWithSelectedFriendAsync(string friendEmail)
        {
            var chat = await GetChatOfTwoUsersAsync(CurrentUserEmail, friendEmail);
            return await _context.Messages.Include(m => m.RelatedUser)
                .Where(m => m.ChatId == chat.ChatId)
                .ToListAsync();
        }


        public async Task<User> GetUserByEmailAsync(string userEmail)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
            return user;
        }

        public async Task<string> GetFriendRelationshipStringAsync(string friendEmail)
        {
            var friendList = await _context.FriendLists.Include(flr => flr.FriendsRelationship)
                .Include(flr => flr.FriendListUsers).ThenInclude(flu => flu.User).FirstOrDefaultAsync(fl =>
                    fl.FriendListUsers.Any(flu => flu.User.Email == CurrentUserEmail) &&
                    fl.FriendListUsers.Any(flu => flu.User.Email == friendEmail));
            return friendList.FriendsRelationship.Name;
        }

        public async Task ChangeRelationshipBetweenUserAndFriendAsync(string friendEmail)
        {
            var friendList = await _context.FriendLists.Include(flr => flr.FriendsRelationship)
                .Include(flr => flr.FriendListUsers).ThenInclude(flu => flu.User).FirstOrDefaultAsync(fl =>
                    fl.FriendListUsers.Any(flu => flu.User.Email == CurrentUserEmail) &&
                    fl.FriendListUsers.Any(flu => flu.User.Email == friendEmail));

            friendList.FriendsRelationshipId = friendList.FriendsRelationshipId == 1 ? 2 : 1;
            _context.SaveChanges();
        }

        public async Task AddNewMessageAsync(string fromUserEmail, string toUserEmail, string message)
        {
            var relationship = await GetFriendRelationshipStringAsync(toUserEmail);
            if (relationship == "Block") return;

            var fromUser = await GetUserByEmailAsync(fromUserEmail);
            var toUser = await GetUserByEmailAsync(toUserEmail);

            Chat currentChat = await GetChatOfTwoUsersAsync(fromUserEmail, toUserEmail);

            await _context.Messages.AddAsync(new Message()
            {
                ChatId = currentChat.ChatId,
                RelatedUserId = fromUser.Id,
                RelatingUserId = toUser.Id,
                SendingTime = DateTime.Now,
                Text = message
            });

            await _context.SaveChangesAsync();
        }

        public async Task AddNewMessageWithImageAsync(string fromUserEmail, string toUserEmail, string imagePath)
        {
            var relationship = await GetFriendRelationshipStringAsync(toUserEmail);
            if (relationship == "Block") return;

            var fromUser = await GetUserByEmailAsync(fromUserEmail);
            var toUser = await GetUserByEmailAsync(toUserEmail);

            Chat currentChat = await GetChatOfTwoUsersAsync(fromUserEmail, toUserEmail);

            await _context.Messages.AddAsync(new Message()
            {
                ChatId = currentChat.ChatId,
                RelatedUserId = fromUser.Id,
                RelatingUserId = toUser.Id,
                SendingTime = DateTime.Now,
                Text = imagePath,
                IsImage = true
            });
            await _context.SaveChangesAsync();
        }
    }
}