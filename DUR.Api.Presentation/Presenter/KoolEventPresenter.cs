using AutoMapper;
using DUR.Api.Entities;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Services.Interfaces;
using System.Collections.Generic;

namespace DUR.Api.Presentation.Presenter
{
    public class KoolEventPresenter : IKoolEventPresenter
    {
        private readonly IKoolEventService _koolEventService;
        private readonly IMapper _mapper;

        public KoolEventPresenter(IKoolEventService koolEventService, IMapper mapper)
        {
            _mapper = mapper;
            _koolEventService = koolEventService;
        }

        public List<KoolEventRM> GetReservations()
        {
            var events = _koolEventService.GetReservations();
            return _mapper.Map<List<KoolEvent>, List<KoolEventRM>>(events);
        }

        List<KoolEventRM> IKoolEventPresenter.GetEvents()
        {
            var events = _koolEventService.GetEvents();
            return _mapper.Map<List<KoolEvent>, List<KoolEventRM>>(events);
        }
    }
}
