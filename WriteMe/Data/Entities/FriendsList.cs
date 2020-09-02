namespace WriteMe.Data.Entities
{
    public class FriendsList
    {
        public int FriendsListId { get; set; }

        public FriendsRelationship FriendsRelationship { get; set; }

        public int FriendRelationshipId { get; set; }

        public Chat Chat { get; set; }

    }
}