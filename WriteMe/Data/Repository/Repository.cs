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

        public async Task<List<User>> GetCurrentUserFriendsAsync()
        {
            var friendList = await _context.FriendLists.Include(fl => fl.FriendListUsers)
                .Where(fl =>
                    fl.FriendListUsers.Any(flu => flu.UserId == CurrentUserId))
                .ToListAsync();

            List<User> users = new List<User>();
            foreach (var list in friendList)
            {
                users.AddRange(_context.Users.Include(u => u.FriendListUsers)
                    .Where(u => u.FriendListUsers.Any(flu => flu.FriendListId == list.Id) && u.Id != CurrentUserId));
            }

            return users;
        }

        public async Task<Chat> GetChatOfTwoUsersAsync(int firstUserId, int secondUserId)
        {
            return await _context.Chats.Include(c => c.FriendList).ThenInclude(fl => fl.FriendListUsers)
                .Include(c => c.Messages)
                .FirstOrDefaultAsync(c =>
                    c.FriendList.FriendListUsers.Any(flu => flu.UserId == firstUserId) &&
                    c.FriendList.FriendListUsers.Any(flu => flu.UserId == secondUserId));
        }

        public async Task<List<Message>> GetMessagesForChatWithSelectedFriendAsync(int friendId)
        {
            var chat = await GetChatOfTwoUsersAsync(CurrentUserId, friendId);
            return await _context.Messages.Include(m => m.RelatedUser)
                .Where(m => m.ChatId == chat.ChatId)
                .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public User GetUserByEmail(string userEmail)
        {
            return _context.Users.FirstOrDefault(u => u.Email == userEmail);
        }

        public async Task<string> GetFriendRelationshipStringAsync(int friendId)
        {
            var friendList = await _context.FriendLists.Include(flr => flr.FriendsRelationship)
                .Include(flr => flr.FriendListUsers).FirstOrDefaultAsync(fl =>
                    fl.FriendListUsers.Any(flu => flu.UserId == CurrentUserId) &&
                    fl.FriendListUsers.Any(flu => flu.UserId == friendId));
            return friendList.FriendsRelationship.Name;
        }

        public async Task ChangeRelationshipBetweenUserAndFriendAsync(int friendId)
        {
            var friendList = await _context.FriendLists.Include(flr => flr.FriendsRelationship)
                .Include(flr => flr.FriendListUsers).FirstOrDefaultAsync(fl =>
                    fl.FriendListUsers.Any(flu => flu.UserId == CurrentUserId) &&
                    fl.FriendListUsers.Any(flu => flu.UserId == friendId));

            friendList.FriendsRelationshipId = friendList.FriendsRelationshipId == 1 ? 2 : 1;
            _context.SaveChanges();
        }

        public async Task AddNewMessageAsync(string fromUserEmail, string toUserEmail, string message)
        {
            var fromUser =  GetUserByEmail(fromUserEmail);
            var toUser =  GetUserByEmail(toUserEmail);

            Chat currentChat = await GetChatOfTwoUsersAsync(fromUser.Id, toUser.Id);

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
    }
}