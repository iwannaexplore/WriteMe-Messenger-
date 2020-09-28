using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WriteMe.Data.Entities
{
    public class FriendList
    {
        public int Id { get; set; }

        public ICollection<FriendListUser> FriendListUsers { get; set; }

        public FriendsRelationship FriendsRelationship { get; set; }

        public int FriendsRelationshipId { get; set; }
        
        public Chat Chat { get; set; }
    }
}
