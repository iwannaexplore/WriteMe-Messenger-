using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WriteMe.Data.Entities
{
    public class FriendListUser
    {
        public int FriendListId { get; set; }

        public FriendList FriendList { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}