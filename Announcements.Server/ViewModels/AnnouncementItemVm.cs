using Announcements.Server.Mappings;
using Announcements.Server.Models;

namespace Announcements.Server.ViewModels
{
    public sealed class AnnouncementItemVm : IMapFrom<Announcement>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SimilarPartsNumber { get; set; }
    }
}