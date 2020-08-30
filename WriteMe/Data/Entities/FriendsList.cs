namespace WriteMe.Data.Entities
{
    public class FriendsList
    {
        public int FriendsListId { get; set; }

        public FriendsRelationship FriendsRelationship { get; set; }

        public int FriendRelationshipId { get; set; }

        public Chat Chat { get; set; }

        public int RelatingUserId { get; set; }

        public int RelatedUserId { get; set; }

        public virtual User RelatedUser { get; set; }

        public virtual User RelatingUser { get; set; }
    }
}