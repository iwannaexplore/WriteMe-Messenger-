using System;
using System.Collections.Generic;

namespace WriteMe.Data.Entities
{
    public class Status
    {
        public int StatusId { get; set; }

        public DateTime LastActivityTime { get; set; }

        public bool IsOnline { get; set; }

        public List<User> Users { get; set; }
    }
}