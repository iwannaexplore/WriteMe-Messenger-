using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WriteMe.Data.Entities
{
    public class User : IdentityUser<int>
    {
        public DateTime LastActivityTime { get; set; }

        public string ProfilePicture { get; set; }

        public virtual ICollection<FriendsList> RelatedFriendsLists { get; set; }

        public virtual ICollection<FriendsList> RelatingFriendsLists { get; set; }
    }
}