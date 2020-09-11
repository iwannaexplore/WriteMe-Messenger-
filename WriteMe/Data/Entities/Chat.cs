using System.Collections.Generic;

namespace WriteMe.Data.Entities
{
    public class Chat
    {
        public int ChatId { get; set; }

        public List<Message> Messages { get; set; }
        
        public FriendsRelationship FriendsRelationship { get; set; }

        public int FriendRelationshipId { get; set; }

        public int FriendListId { get; set; }

        public FriendList FriendList { get; set; }

    }
}