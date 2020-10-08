using System;

namespace WriteMe.Data.Entities
{
    public class Message
    {
        public int MessageId { get; set; }

        public string Text { get; set; }

        public DateTime SendingTime { get; set; }

        public Chat Chat { get; set; }

        public int ChatId { get; set; }

        public int RelatingUserId { get; set; }

        public User RelatingUser { get; set; }

        public int RelatedUserId { get; set; }

        public User RelatedUser { get; set; }

        public bool IsImage { get; set; }

        public bool IsVideo { get; set; }
    }
}