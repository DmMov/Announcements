using Announcements.Server.Models;
using System;
using System.Collections.Generic;

namespace Announcements.Server
{
    public sealed class Data
    {
        public static readonly List<Announcement> announcements;
        static Data()
        {
            announcements = new List<Announcement>
            {
                new Announcement {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Suspendisse eleifend. Cras sed leo. Cras vehicula",
                    Description = "Donec non justo. Proin non massa non ante bibendum ullamcorper. Duis cursus, diam at pretium aliquet, metus urna convallis erat, eget tincidunt dui augue eu tellus. Phasellus elit pede.",
                    CreatedAt = DateTime.UtcNow
                },
                new Announcement {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Turpis non enim. Mauris quis",
                    Description = "At arcu. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae. Donec tincidunt. Donec vitae erat vel pede blandit congue. In scelerisque scelerisque dui.",
                    CreatedAt = DateTime.UtcNow
                },
            };
        }
    }
}
