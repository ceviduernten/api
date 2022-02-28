using DUR.Api.Presentation.ResourceModel;
using System.Collections.Generic;

namespace DUR.Api.Presentation.Interfaces.Presenter
{
    public interface IKoolPresenter
    {
        List<KoolEventRM> GetEvents();
        List<KoolReservationRM> GetReservations();
    }
}
