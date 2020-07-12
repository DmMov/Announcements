using Announcements.Server.Models;
using Announcements.Server.ViewModels;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Announcements.Server.Queries.GetAnnouncementById
{
    public sealed class GetAnnouncementByIdQuery : IRequest<AnnouncementVm>
    {
        public string AnnouncementId { get; set; }

        public sealed class Handler : IRequestHandler<GetAnnouncementByIdQuery, AnnouncementVm>
        {
            private readonly IMapper _mapper;

            public Handler(IMapper mapper)
            {
                _mapper = mapper;
            }

            public async Task<AnnouncementVm> Handle(GetAnnouncementByIdQuery request, CancellationToken cancellationToken)
            {
                Announcement announcement =  Data.announcements
                    .FirstOrDefault(x => x.Id == request.AnnouncementId);

                List<string> announcementKeyWords = announcement.Title
                    .Split(" ")
                    .Select(x => x.Trim(new char[] { ',', '.' }))
                    .Union(announcement.Description.Split(" ").Select(x => x.Trim(new char[] { ',', '.' })))
                    .ToList();

                List<AnnouncementItemVm> announcementItems = new List<AnnouncementItemVm>();

                foreach (Announcement item in Data.announcements.Where(x => x.Id != announcement.Id))
                {
                    List<string> itemKeyWords = item.Title
                        .Split(" ")
                        .Select(x => x.Trim(new char[] { ',', '.' }))
                        .Union(item.Description.Split(" ").Select(x => x.Trim(new char[] { ',', '.' })))
                        .ToList();

                    AnnouncementItemVm announcementItemVm = _mapper.Map<AnnouncementItemVm>(item);

                    announcementItemVm.SimilarPartsNumber = itemKeyWords.Intersect(announcementKeyWords).Count();

                    announcementItems.Add(announcementItemVm);
                }

                AnnouncementVm announcementVm = _mapper.Map<AnnouncementVm>(announcement);

                announcementVm.SimilarAnnouncements = announcementItems
                    .OrderBy(x => x.SimilarPartsNumber)
                    .Take(3)
                    .ToList();

                return await Task.FromResult(announcementVm);
            }
        }

    }
}