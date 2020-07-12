using Announcements.Server.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Announcements.Server.Queries.GetAllAnnoucements
{
    public sealed class GetAllAnnoucementsQuery : IRequest<ICollection<AnnouncementItemVm>>
    {
        public sealed class Handler : IRequestHandler<GetAllAnnoucementsQuery, ICollection<AnnouncementItemVm>>
        {
            private readonly IMapper _mapper;

            public Handler(IMapper mapper)
            {
                _mapper = mapper;
            }

            public async Task<ICollection<AnnouncementItemVm>> Handle(GetAllAnnoucementsQuery request, CancellationToken cancellationToken)
            {
                List<AnnouncementItemVm> announcementItems = Data.announcements
                    .OrderByDescending(x => x.CreatedAt)
                    .AsQueryable()
                    .ProjectTo<AnnouncementItemVm>(_mapper.ConfigurationProvider)
                    .ToList();

                return await Task.FromResult(announcementItems);
            }
        }

    }
}
