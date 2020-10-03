using System.Collections.Generic;
using WriteMe.Data.Entities;

namespace WriteMe.Data.Repository.Interface
{
    public interface IRepository
    {
        public string GetCurrentUserEmail();

        public List<User> GetCurrentUserFriends();

        public Chat GetChatOfTwoUsers(int firstUserId, int secondUserId);

        public List<Message> GetMessagesForChatWithSelectedFriend(int friendId);

        public User GetUserById(int userId);

        public User GetUserByEmail(string userEmail);

        public string GetFriendRelationshipString(int friendId);

        public void ChangeRelationshipBetweenUserAndFriend(int friendId);

        public void AddNewMessage(string fromUserEmail, string toUserEmail, string message);
    }
}
