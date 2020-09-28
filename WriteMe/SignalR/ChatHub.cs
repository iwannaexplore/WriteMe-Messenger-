using System;
using System.Collections.Generic;
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
        private string CurrentUserEmail => Context.User.Identity.Name;

        private static List<string> UsersOnline { get; set; } = new List<string>();

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
                ChatId = currentChat.ChatId,
                RelatedUserId = fromUser.Id,
                RelatingUserId = toUser.Id,
                SendingTime = DateTime.Now,
                Text = message
            });
            _context.SaveChanges();

            await Clients.Users(fromUser.Email, to).SendAsync("Receive", message, CurrentUserEmail);
        }

        public async Task GetOnlineInfo(string friendEmail)
        {

            if (UsersOnline.Contains(friendEmail))
            {
                await Clients.User(CurrentUserEmail).SendAsync("ChangeOnline", "Online");
            }
            else
            {
                await Clients.Users(CurrentUserEmail).SendAsync("ChangeOnline", "Offline");
            }


        }

        public override Task OnConnectedAsync()
        {
            UsersOnline.Add(CurrentUserEmail);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            UsersOnline.Remove(CurrentUserEmail);
            return base.OnDisconnectedAsync(exception);
        }
    }
}