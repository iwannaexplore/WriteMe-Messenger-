using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

using WriteMe.Data.Repository.Interface;

namespace WriteMe.SignalR
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IRepository _repository;
        private string CurrentUserEmail => Context.User.Identity.Name;

        private static List<string> UsersOnline { get; set; } = new List<string>();

        public ChatHub(IRepository repository)
        {
            _repository = repository;
        }

        public async Task Send(string message, string from, string to)
        {
            await _repository.AddNewMessageAsync(from, to, message);

            await Clients.Users(from, to).SendAsync("Receive", message, CurrentUserEmail);
        }

        public async Task GetOnlineInfo(string friendEmail)
        {
            _repository.GetCurrentUserEmail();

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