using Announcements.Server.Exceptions;
using Announcements.Server.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Announcements.Server.Commands.UpdateAnnouncement
{
    public sealed class UpdateAnnouncementCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public sealed class Handler : IRequestHandler<UpdateAnnouncementCommand, string>
        {
            public async Task<string> Handle(UpdateAnnouncementCommand request, CancellationToken cancellationToken)
            {
                Announcement announcement = Data.announcements
                    .FirstOrDefault(x => x.Id == request.Id);

                if (announcement == null)
                    throw new NotFoundException(nameof(Announcement), request.Id);


                if (announcement.Title != request.Title)
                    announcement.Title = request.Title;

                if (announcement.Description != request.Description)
                    announcement.Description = request.Description;

                return await Task.FromResult(announcement.Id);
            }
        }
    }
}
