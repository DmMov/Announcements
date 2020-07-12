using System.Collections.Generic;
using System.Threading.Tasks;
using Announcements.Server.Commands.CreateAnnouncement;
using Announcements.Server.Commands.DeleteAnnouncement;
using Announcements.Server.Commands.UpdateAnnouncement;
using Announcements.Server.Queries.GetAllAnnoucements;
using Announcements.Server.Queries.GetAnnouncementById;
using Announcements.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Announcements.Server.Controllers
{
    public sealed class AnnouncementsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ICollection<AnnouncementItemVm>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllAnnoucementsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnnouncementVm>> GetById(string id)
        {
            return Ok(await Mediator.Send(new GetAnnouncementByIdQuery { AnnouncementId = id }));
        }

        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody] CreateAnnouncementCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<ActionResult<string>> Update([FromBody] UpdateAnnouncementCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(string id)
        {
            await Mediator.Send(new DeleteAnnouncementCommand { AnnouncementId = id });

            return NoContent();
        }
    }
}
