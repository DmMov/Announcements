using Announcements.Server.Mappings;
using Announcements.Server.Models;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Announcements.Server.Commands.CreateAnnouncement
{
    public sealed class CreateAnnouncementCommand : IRequest<string>, IMapTo<Announcement>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public sealed class Handler : IRequestHandler<CreateAnnouncementCommand, string>
        {
            private readonly IMapper _mapper;

            public Handler(IMapper mapper)
            {
                _mapper = mapper;
            }

            public async Task<string> Handle(CreateAnnouncementCommand request, CancellationToken cancellationToken)
            {
                Announcement announcement = _mapper.Map<Announcement>(request);
                announcement.Id = Guid.NewGuid().ToString();
                announcement.CreatedAt = DateTime.UtcNow;

                Data.announcements.Add(announcement);

                return await Task.FromResult(announcement.Id);
            }
        }
    }
}
