using Announcements.Server.Mappings;
using Announcements.Server.Models;
using AutoMapper;
using System.Collections.Generic;

namespace Announcements.Server.ViewModels
{
    public sealed class AnnouncementVm : IMapFrom<Announcement>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatedAt { get; set; }
        public ICollection<AnnouncementItemVm> SimilarAnnouncements { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Announcement, AnnouncementVm>()
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => $"{x.CreatedAt:MMMM dd}"));
        }
    }
}