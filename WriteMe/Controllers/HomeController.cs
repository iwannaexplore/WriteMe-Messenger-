using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NLog;
using WriteMe.Data;
using WriteMe.Data.Entities;
using WriteMe.Data.Repository;
using WriteMe.Data.Repository.Interface;
using WriteMe.Models;

namespace WriteMe.Controllers
{
    public class HomeController : Controller
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<Chat> _chatRepository;
        private readonly IGenericRepository<FriendsList> _friendsListRepository;
        private readonly IGenericRepository<FriendsRelationship> _friendsRelationshipRepository;
        private readonly IGenericRepository<Message> _messageRepository;


        public HomeController(ApplicationDbContext context)
        {
            _userRepository = new GenericRepository<User>(context);
            _chatRepository = new GenericRepository<Chat>(context);
            _friendsListRepository = new GenericRepository<FriendsList>(context);
            _friendsRelationshipRepository = new GenericRepository<FriendsRelationship>(context);
            _messageRepository = new GenericRepository<Message>(context);
        }

        public IActionResult Index()
        {
            var z = _userRepository.GetAll();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}