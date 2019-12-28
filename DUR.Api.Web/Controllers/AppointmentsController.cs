using System;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Web.Default;
using Microsoft.AspNetCore.Mvc;

namespace DUR.Api.Web.Controllers
{
    public class AppointmentsController : DefaultController
    {
        private readonly IAppointmentPresenter _appointmentPresenter;

        public AppointmentsController(IAppointmentPresenter appointmentPresenter)
        {
            _appointmentPresenter = appointmentPresenter;
        }

        [HttpGet("{group}")]
        public JsonResult GetByGroup(Guid group)
        {
            var res = _appointmentPresenter.GetByGroup(group);
            return Json(new DataJsonResult<AppointmentRM>(200, "appointments successfully returned", res));
        }

        [HttpPost]
        public JsonResult AddAppointment(AppointmentRM appointment)
        {
            var success = _appointmentPresenter.Add(appointment);
            if (success)
            {
                return Json(new InfoJsonResult(200, "successfully added appointment"));
            }
            else
            {
                return Json(new InfoJsonResult(500, "Error on adding appointment"));
            }
        }
    }
}
