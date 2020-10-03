using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;
using WriteMe.Data.Entities;
using WriteMe.Data.Repository.Interface;
using WriteMe.Models;

namespace WriteMe.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }
        
        public IActionResult Index()
        {
            return View(new Blabla() {Users = _repository.GetCurrentUserFriends() });
        }

        public IActionResult DisplayMessages(int friendId)
        {
            return PartialView("_ChatRoom",
                new HelpMeGod()
                {
                    Messages = _repository.GetMessagesForChatWithSelectedFriend(friendId), Friend = _repository.GetUserById(friendId),
                    FriendRelationship = _repository.GetFriendRelationshipString(friendId)
                });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        public IActionResult ChangeUserRelationship(int friendId)
        {
            _repository.ChangeRelationshipBetweenUserAndFriend(friendId);
            return RedirectToAction("DisplayMessages", new { friendId = friendId});
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