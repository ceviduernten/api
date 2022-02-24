using DUR.Api.Presentation.ResourceModel;
using System.Collections.Generic;

namespace DUR.Api.Presentation.Interfaces.Presenter
{
    public interface IKoolEventPresenter
    {
        List<KoolEventRM> GetEvents();
        List<KoolEventRM> GetReservations();
    }
}
