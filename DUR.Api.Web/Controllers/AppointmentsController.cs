using System;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Web.Default;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("{group}/list")]
        public JsonResult GetByGroup(Guid group)
        {
            var res = _appointmentPresenter.GetByGroup(group);
            return Json(new DataJsonResult<AppointmentRM>(200, "appointments successfully returned", res));
        }

        [HttpGet("{appointment}/Responses")]
        public JsonResult GetResponsesByAppointment(Guid appointment)
        {
            var res = _appointmentPresenter.GetResponsesByAppointment(appointment);
            return Json(new DataJsonResult<AppointmentResponseListRM>(200, "responses successfully returned", res));
        }

        [HttpGet("{group}/next")]
        public JsonResult GetNext(Guid group)
        {
            var res = _appointmentPresenter.GetNextAppointment(group);
            return Json(new SingleDataJsonResult<AppointmentRM>(200, "appointment successfully returned", res));
        }

        [Authorize("Scouting")]
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

        [Authorize("Scouting")]
        [HttpDelete("{appointment}")]
        public JsonResult DeleteAppointment(Guid appointment)
        {
            var success = _appointmentPresenter.DeleteById(appointment);
            if (success)
            {
                return Json(new InfoJsonResult(200, "successfully deleted appointment"));
            }
            else
            {
                return Json(new InfoJsonResult(500, "Error on deleting appointment"));
            }
        }

        [Authorize("Scouting")]
        [HttpPatch("{IdAppointment}")]
        public JsonResult UpdateAppointment(AppointmentRM appointment)
        {
            var success = _appointmentPresenter.Update(appointment);
            if (success)
            {
                return Json(new InfoJsonResult(200, "successfully updated appointment"));
            }
            else
            {
                return Json(new InfoJsonResult(500, "Error on updating appointment"));
            }
        }

        [Authorize("Scouting")]
        [HttpGet("{appointment}")]
        public JsonResult GetAppointment(Guid appointment)
        {
            var res = _appointmentPresenter.GetById(appointment);
            return Json(new SingleDataJsonResult<AppointmentRM>(200, "appointment successfully returned", res));
        }

        [HttpPost("Signon")]
        public JsonResult SignOnForAppointment(AppointmentResponseRM appointment)
        {
            var success = _appointmentPresenter.SignOnForAppointment(appointment);
            if (success)
            {
                return Json(new InfoJsonResult(200, "successfully added signon for appointment"));
            }
            else
            {
                return Json(new InfoJsonResult(500, "Error on signon for appointment"));
            }
        }

        [HttpPost("Signoff")]
        public JsonResult SignOffForAppointment(AppointmentResponseRM appointment)
        {
            var success = _appointmentPresenter.SignOffForAppointment(appointment);
            if (success)
            {
                return Json(new InfoJsonResult(200, "successfully added signoff for appointment"));
            }
            else
            {
                return Json(new InfoJsonResult(500, "Error on signoff for appointment"));
            }
        }
    }
}
