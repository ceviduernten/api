using AutoMapper;
using DUR.Api.Entities;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Services.Interfaces;
using System.Collections.Generic;

namespace DUR.Api.Presentation.Presenter
{
    public class KoolPresenter : IKoolPresenter
    {
        private readonly IKoolService _koolEventService;
        private readonly IMapper _mapper;

        public KoolPresenter(IKoolService koolEventService, IMapper mapper)
        {
            _mapper = mapper;
            _koolEventService = koolEventService;
        }

        public List<KoolReservationRM> GetReservations()
        {
            var events = _koolEventService.GetReservations();
            return _mapper.Map<List<KoolReservation>, List<KoolReservationRM>>(events);
        }

        public List<KoolEventRM> GetEvents()
        {
            var events = _koolEventService.GetEvents();
            return _mapper.Map<List<KoolEvent>, List<KoolEventRM>>(events);
        }
    }
}
