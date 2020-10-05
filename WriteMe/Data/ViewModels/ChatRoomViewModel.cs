using System.Collections.Generic;
using WriteMe.Data.Entities;

namespace WriteMe.Data.ViewModels
{
    public class ChatRoomViewModel
    {
        public List<Message> Messages { get; set; }
        public User Friend { get; set; }

        public string FriendRelationship { get; set; }
    }
}
