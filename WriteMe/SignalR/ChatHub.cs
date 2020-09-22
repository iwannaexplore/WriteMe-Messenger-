using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WriteMe.Data;
using WriteMe.Data.Entities;

namespace WriteMe.SignalR
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext _context;

        public ChatHub(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task Send(string message, string from, string to)
        {
            User toUser = _context.Users.First(u => u.Email == to);
            User fromUser = _context.Users.First(u => u.Email == from);
            Chat currentChat = _context.Chats.Include(c => c.FriendList).ThenInclude(fl => fl.FriendListUsers)
                .Include(c => c.Messages)
                .FirstOrDefault(c =>
                    c.FriendList.FriendListUsers.Any(flu => flu.UserId == toUser.Id) &&
                    c.FriendList.FriendListUsers.Any(flu => flu.UserId == fromUser.Id));


            _context.Messages.Add(new Message()
            {
                ChatId = currentChat.ChatId, RelatedUserId = fromUser.Id, RelatingUserId = toUser.Id,
                SendingTime = DateTime.Now, Text = message
            });
            _context.SaveChanges();

            var currentUser = Context.User.Identity.Name;

            await Clients.Users(fromUser.Email, to).SendAsync("Receive", message, currentUser);
        }
    }
}