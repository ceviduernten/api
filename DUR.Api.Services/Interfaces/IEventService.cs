using System;
using System.Collections.Generic;
using DUR.Api.Entities;

namespace DUR.Api.Services.Interfaces
{
    public interface IEventService
    {
        List<Event> GetCurrentEvents();
    }
}
