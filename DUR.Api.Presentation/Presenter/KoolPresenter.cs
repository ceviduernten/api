using AutoMapper;
using DUR.Api.Entities;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Services.Interfaces;
using System.Collections.Generic;
using DUR.Api.Entities.Kool;

namespace DUR.Api.Presentation.Presenter
{
    public class KoolPresenter : IKoolPresenter
    {
        private readonly IKoolService _koolEventService;
        private readonly IMapper _mapper;
        private readonly IApplicationMailService _applicationMailService;

        public KoolPresenter(IKoolService koolEventService, IMapper mapper, IApplicationMailService applicationMailService)
        {
            _mapper = mapper;
            _koolEventService = koolEventService;
            _applicationMailService = applicationMailService;
        }

        public List<KoolReservationRM> GetReservations()
        {
            var events = _koolEventService.GetReservations();
            return _mapper.Map<List<KoolReservation>, List<KoolReservationRM>>(events);
        }

        public bool Add(ReservationRM entity)
        {
            var model = _mapper.Map<Reservation>(entity);
            var success = _applicationMailService.InformAboutReservation(model);
            return success;
        }

        public List<KoolEventRM> GetEvents()
        {
            var events = _koolEventService.GetEvents();
            return _mapper.Map<List<KoolEvent>, List<KoolEventRM>>(events);
        }
    }
}
