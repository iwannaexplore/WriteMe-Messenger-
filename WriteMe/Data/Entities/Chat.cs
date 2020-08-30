using System.Collections.Generic;

namespace WriteMe.Data.Entities
{
    public class Chat
    {
        public int ChatId { get; set; }

        public List<Message> Messages { get; set; }

        public FriendsList FriendsList { get; set; }

        public int FriendListId { get; set; }
    }
}