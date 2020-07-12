using Announcements.Server.Exceptions;
using Announcements.Server.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Announcements.Server.Commands.DeleteAnnouncement
{
    public sealed class DeleteAnnouncementCommand : IRequest<string>
    {
        public string AnnouncementId { get; set; }
        public sealed class Handler : IRequestHandler<DeleteAnnouncementCommand, string>
        {
            public async Task<string> Handle(DeleteAnnouncementCommand request, CancellationToken cancellationToken)
            {
                Announcement announcement = Data.announcements
                    .FirstOrDefault(x => x.Id == request.AnnouncementId);

                if (announcement == null)
                    throw new NotFoundException(nameof(Announcement), request.AnnouncementId);

                Data.announcements.Remove(announcement);

                return await Task.FromResult(announcement.Id);
            }
        }
    }
}
