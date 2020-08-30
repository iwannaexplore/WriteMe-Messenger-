using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WriteMe.Data.Entities
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public Status Status { get; set; }

        public int StatusId { get; set; }

        public string ProfilePicture { get; set; }

        public virtual ICollection<FriendsList> RelatedFriendsLists { get; set; }

        public virtual ICollection<FriendsList> RelatingFriendsLists { get; set; }
    }
}