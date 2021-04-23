using System;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Web.Default;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DUR.Api.Web.Controllers
{
    public class HuntLocationsController : DefaultController
    {
        private readonly IHuntLocationPresenter _huntLocationPresenter;

        public HuntLocationsController(IHuntLocationPresenter huntLocationPresenter)
        {
            _huntLocationPresenter = huntLocationPresenter;
        }

        [Authorize("Scouting")]
        [HttpGet("All")]
        public JsonResult GetAll()
        {
            var res = _huntLocationPresenter.GetList();
            return Json(new DataJsonResult<HuntLocationListRM>(200, "Hunt locations successfully returned", res));
        }


        [HttpGet]
        public JsonResult GetList()
        {
            var res = _huntLocationPresenter.GetAllActiveList();
            return Json(new DataJsonResult<HuntLocationListRM>(200, "active Hunt locations successfully returned", res));
        }

        [Authorize("Scouting")]
        [HttpPost]
        public JsonResult AddHuntLocation(HuntLocationRM location)
        {
            var success = _huntLocationPresenter.Add(location);
            if (success)
            {
                return Json(new InfoJsonResult(200, "successfully added hunt location"));
            }
            else
            {
                return Json(new InfoJsonResult(500, "Error on adding hunt location"));
            }
        }

        [Authorize("Scouting")]
        [HttpDelete("{location}")]
        public JsonResult DeleteHuntLocation(Guid location)
        {
            var success = _huntLocationPresenter.DeleteById(location);
            if (success)
            {
                return Json(new InfoJsonResult(200, "successfully deleted hunt location"));
            }
            else
            {
                return Json(new InfoJsonResult(500, "Error on deleting hunt location"));
            }
        }

        [HttpPatch("{location}/Found")]
        public JsonResult FoundHuntLocation(Guid location)
        {
            var success = _huntLocationPresenter.Found(location);
            if (success)
            {
                return Json(new InfoJsonResult(200, "successfully founded hunt location"));
            }
            else
            {
                return Json(new InfoJsonResult(500, "Error on founded location"));
            }
        }

        [Authorize("Scouting")]
        [HttpPatch("{IdHuntLocation}")]
        public JsonResult UpdateHuntLocation(HuntLocationRM location)
        {
            var success = _huntLocationPresenter.Update(location);
            if (success)
            {
                return Json(new InfoJsonResult(200, "successfully updated hunt location"));
            }
            else
            {
                return Json(new InfoJsonResult(500, "Error on updating location"));
            }
        }

        [HttpGet("{location}")]
        public JsonResult GetHuntLocation(Guid location)
        {
            var res = _huntLocationPresenter.GetById(location);
            return Json(new SingleDataJsonResult<HuntLocationRM>(200, "box successfully returned", res));
        }
    }
}
