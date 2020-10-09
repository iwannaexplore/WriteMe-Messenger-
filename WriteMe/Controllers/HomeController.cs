using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NLog;
using WriteMe.Data.Repository.Interface;
using WriteMe.Data.ViewModels;
using WriteMe.Models;
using WriteMe.SignalR;

namespace WriteMe.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IRepository _repository;
        private readonly IHubContext<ChatHub> _hubContext;

        public HomeController(IRepository repository, IHubContext<ChatHub> hubContext)
        {
            _repository = repository;
            _hubContext = hubContext;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetCurrentUserFriendsAsync());
        }

        public async Task<IActionResult> DisplayMessages(string friendEmail)
        {
            var messages = await _repository.GetMessagesForChatWithSelectedFriendAsync(friendEmail);
            var friend = await _repository.GetUserByEmailAsync(friendEmail);
            var friendRelationship = await _repository.GetFriendRelationshipStringAsync(friendEmail);
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

        public async Task<IActionResult> ChangeUserRelationship(string friendEmail)
        {
            await _repository.ChangeRelationshipBetweenUserAndFriendAsync(friendEmail);

            await _hubContext.Clients.Users(await _repository.GetCurrentUserEmailAsync(), friendEmail)
                .SendAsync("ChangeUserRelationship");

            return RedirectToAction("DisplayMessages", new {friendEmail = friendEmail});
        }


        [HttpPost]
        public async Task UploadFile([FromForm] UploadFileViewModel model)
        {
            if (model.File.ContentType.Contains("image/"))
            {
                string uniqueFileName = Guid.NewGuid() + "_" + model.File.FileName;

                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot", "messageImages",
                    uniqueFileName);

                await using (var stream = new FileStream(path, FileMode.Create))
                {
                    model.File.CopyTo(stream);
                }

                await _repository.AddNewMessageWithFileAsync(model.FromUserEmail, model.ToUserEmail, uniqueFileName, "Image");
                Thread.Sleep(2000);
                await _hubContext.Clients.Users(model.FromUserEmail, model.ToUserEmail)
                    .SendAsync("UploadFile", uniqueFileName, await _repository.GetCurrentUserEmailAsync(),
                        uniqueFileName, "image");
                return;
            }

            if (model.File.ContentType.Contains("video/"))
            {
                string uniqueFileName = Guid.NewGuid() + "_" + model.File.FileName;

                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot", "messageVideos",
                    uniqueFileName);

                await using (var stream = new FileStream(path, FileMode.Create))
                {
                    model.File.CopyTo(stream);
                }

                await _repository.AddNewMessageWithFileAsync(model.FromUserEmail, model.ToUserEmail, uniqueFileName, "Video");
                Thread.Sleep(2000);
                await _hubContext.Clients.Users(model.FromUserEmail, model.ToUserEmail)
                    .SendAsync("UploadFile", uniqueFileName, await _repository.GetCurrentUserEmailAsync(),
                        uniqueFileName, "video");
                return;
            }
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
    }
}