using System.Collections.Generic;
using System.Threading.Tasks;
using WriteMe.Data.Entities;

namespace WriteMe.Data.Repository.Interface
{
    public interface IRepository
    {
        public Task<string> GetCurrentUserEmailAsync();

        public Task<List<User>> GetCurrentUserFriendsAsync();

        public Task<Chat> GetChatOfTwoUsersAsync(string firstUserEmail, string secondUserEmail);

        public Task<List<Message>> GetMessagesForChatWithSelectedFriendAsync(string friendEmail);

        public Task<User> GetUserByEmailAsync(string userEmail);

        public Task<string> GetFriendRelationshipStringAsync(string friendEmail);

        public Task ChangeRelationshipBetweenUserAndFriendAsync(string friendEmail);

        public Task AddNewMessageAsync(string fromUserEmail, string toUserEmail, string message);

        public Task AddNewMessageWithImageAsync(string fromUserEmail, string toUserEmail, string imagePath);
    }
}