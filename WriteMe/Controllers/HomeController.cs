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
        private readonly ApplicationDbContext _context;
        private  User CurrentUser => _context.Users.First(u => u.UserName == User.Identity.Name);


        public HomeController(ApplicationDbContext context)
        {
            _context = context;
            _userRepository = _context.Users;
            _chatRepository = _context.Chats;
            _friendsRelationshipRepository = _context.FriendsRelationships;
            _messageRepository = _context.Messages;
            _friendListRepository = _context.FriendLists;
        }


        public IActionResult Index()
        {
            var friendList = _friendListRepository.Include(fl => fl.FriendListUsers)
                .Where(fl =>
                    fl.FriendListUsers.Any(flu => flu.UserId == CurrentUser.Id) && fl.FriendsRelationshipId == 1)
                .ToList();
            List<User> users = new List<User>();
            foreach (var list in friendList)
            {
                users.AddRange(_userRepository.Include(u => u.FriendListUsers)
                    .Where(u => u.FriendListUsers.Any(flu => flu.FriendListId == list.Id) && u.Id != CurrentUser.Id));
            }


            return View(new Blabla() {Users = users});
        }

        public IActionResult DisplayMessages(string from, int to)
        {
            Chat currentChat = _chatRepository.Include(c => c.FriendList).ThenInclude(fl => fl.FriendListUsers)
                .Include(c => c.Messages)
                .FirstOrDefault(c => c.FriendList.FriendListUsers.Any(flu => flu.UserId == to) && c.FriendList.FriendListUsers.Any(flu => flu.UserId == CurrentUser.Id));

            var messages = _messageRepository.Where(m => m.ChatId == currentChat.ChatId).ToList();

            return PartialView("_ChatRoom",
                new HelpMeGod() {Messages = messages, Friend = _userRepository.First(u=>u.Id == to)});
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
    }
}