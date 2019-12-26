using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Web.Default;
using Microsoft.AspNetCore.Mvc;

namespace DUR.Api.Web.Controllers
{
    public class EventsController : DefaultController
    {
        private readonly IEventPresenter _eventPresenter;

        public EventsController(IEventPresenter eventPresenter)
        {
            _eventPresenter = eventPresenter;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var res = _eventPresenter.GetEvents();
            return Json(new DataJsonResult<EventRM>(200, "Events successfully returned", res));
        }
    }
}
