using System;

namespace Announcements.Server.Models
{
    public sealed class Announcement
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
