using System.Collections.Generic;
using System.Threading.Tasks;
using WriteMe.Data.Entities;

namespace WriteMe.Data.Repository.Interface
{
    public interface IRepository
    {
        public string GetCurrentUserEmail();

        public Task<List<User>> GetCurrentUserFriendsAsync();

        public Task<Chat> GetChatOfTwoUsersAsync(int firstUserId, int secondUserId);

        public Task<List<Message>> GetMessagesForChatWithSelectedFriendAsync(int friendId);

        public Task<User> GetUserByIdAsync(int userId);

        public User GetUserByEmail(string userEmail);

        public Task<string> GetFriendRelationshipStringAsync(int friendId);

        public Task ChangeRelationshipBetweenUserAndFriendAsync(int friendId);

        public Task AddNewMessageAsync(string fromUserEmail, string toUserEmail, string message);
    }
}