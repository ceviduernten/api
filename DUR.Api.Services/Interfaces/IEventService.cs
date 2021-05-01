using DUR.Api.Entities;
using System.Collections.Generic;

namespace DUR.Api.Services.Interfaces
{
    public interface IEventService
    {
        List<Event> GetCurrentEvents();
    }
}
