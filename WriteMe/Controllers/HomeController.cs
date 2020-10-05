using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;
using WriteMe.Data.Repository.Interface;
using WriteMe.Data.ViewModels;
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
        
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetCurrentUserFriendsAsync());
        }

        public async Task<IActionResult> DisplayMessages(int friendId)
        {
            var messages = await _repository.GetMessagesForChatWithSelectedFriendAsync(friendId);
            var friend = await _repository.GetUserByIdAsync(friendId);
            var friendRelationship = await _repository.GetFriendRelationshipStringAsync(friendId);
            return PartialView("_ChatRoom",
                new ChatRoomViewModel()
                {
                    Messages = messages, Friend = friend,
                    FriendRelationship = friendRelationship
                });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        public async Task<IActionResult> ChangeUserRelationship(int friendId)
        {
            await _repository.ChangeRelationshipBetweenUserAndFriendAsync(friendId);
            return RedirectToAction("DisplayMessages", new { friendId = friendId});
        }
    }

}