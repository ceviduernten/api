using System.Collections.Generic;
using DUR.Api.Presentation.ResourceModel;

namespace DUR.Api.Presentation.Interfaces.Presenter;

public interface IKoolPresenter
{
    List<KoolEventRM> GetEvents();
    List<KoolReservationRM> GetReservations();
    bool Add(ReservationRM entity);
}