using DUR.Api.Entities;
using System.Collections.Generic;

namespace DUR.Api.Repo.Nextcloud.Interfaces
{
    public interface IEventsRepo
    {
        List<Event> GetEvents();
    }
}
