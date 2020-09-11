using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WriteMe.Data.Entities
{
    public class User : IdentityUser<int>
    {
        public DateTime LastActivityTime { get; set; }

        public string ProfilePicture { get; set; }

        public ICollection<Message> RelatingMessages { get; set; }

        public ICollection<Message> RelatedMessage { get; set; }

        public ICollection<FriendListUser> FriendListUsers { get; set; }
    }
}