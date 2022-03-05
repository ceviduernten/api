using System.Collections.Generic;
using DUR.Api.Entities;

namespace DUR.Api.Repo.Nextcloud.Interfaces;

public interface IEventsRepo
{
    List<Event> GetEvents();
}