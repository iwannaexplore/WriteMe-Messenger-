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
    }
}