using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using NLog;
using WriteMe.Data;
using WriteMe.Data.Entities;
using WriteMe.Data.Repository;
using WriteMe.Data.Repository.Interface;
using WriteMe.Models;

namespace WriteMe.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly DbSet<User> _userRepository;
        private readonly DbSet<Chat> _chatRepository;
        private readonly DbSet<FriendsRelationship> _friendsRelationshipRepository;
        private readonly DbSet<Message> _messageRepository;
        private readonly DbSet<FriendList> _friendListRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private int CurrentUserId =>
            int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));


        public HomeController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = context.Users;
            _chatRepository = context.Chats;
            _friendsRelationshipRepository = context.FriendsRelationships;
            _messageRepository = context.Messages;
            _friendListRepository = context.FriendLists;
            _httpContextAccessor = httpContextAccessor;
        }


        public IActionResult Index()
        {
            var friendList = _friendListRepository.Include(fl => fl.FriendListUsers)
                .Where(fl =>
                    fl.FriendListUsers.Any(flu => flu.UserId == CurrentUserId))
                .ToList();
            List<User> users = new List<User>();
            foreach (var list in friendList)
            {
                users.AddRange(_userRepository.Include(u => u.FriendListUsers)
                    .Where(u => u.FriendListUsers.Any(flu => flu.FriendListId == list.Id) && u.Id != CurrentUserId));
            }

            return View(new Blabla() {Users = users});
        }

        public IActionResult DisplayMessages(int to)
        {
            Chat currentChat = _chatRepository.Include(c => c.FriendList).ThenInclude(fl => fl.FriendListUsers)
                .Include(c => c.Messages)
                .FirstOrDefault(c =>
                    c.FriendList.FriendListUsers.Any(flu => flu.UserId == to) &&
                    c.FriendList.FriendListUsers.Any(flu => flu.UserId == CurrentUserId));

            var messages = _messageRepository.Include(m => m.RelatedUser).Where(m => m.ChatId == currentChat.ChatId)
                .ToList();

            return PartialView("_ChatRoom",
                new HelpMeGod() {Messages = messages, Friend = _userRepository.First(u => u.Id == to), FriendRelationship = _friendListRepository.Include(flr=>flr.FriendsRelationship).Include(flr=>flr.FriendListUsers).First(fl=>fl.FriendListUsers.Any(flu=>flu.UserId == CurrentUserId) && fl.FriendListUsers.Any(flu => flu.UserId == to)).FriendsRelationship.Name});
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }

    public class Blabla
    {
        public List<User> Users { get; set; }
    }

    public class HelpMeGod
    {
        public List<Message> Messages { get; set; }
        public User Friend { get; set; }

        public string FriendRelationship { get; set; }
    }
}