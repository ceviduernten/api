using System.Collections.Generic;
using AutoMapper;
using DUR.Api.Entities;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Services.Interfaces;

namespace DUR.Api.Presentation.Presenter;

public class EventPresenter : IEventPresenter
{
    private readonly IEventService _eventService;
    private readonly IMapper _mapper;

    public EventPresenter(IEventService eventService, IMapper mapper)
    {
        _mapper = mapper;
        _eventService = eventService;
    }

    public List<EventRM> GetEvents()
    {
        var events = _eventService.GetCurrentEvents();
        return _mapper.Map<List<Event>, List<EventRM>>(events);
    }
}