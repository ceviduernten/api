using System;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Web.Default;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DUR.Api.Web.Controllers
{
    public class BoxesController : DefaultController
    {
        private readonly IBoxPresenter _boxPresenter;

        public BoxesController(IBoxPresenter boxPresenter)
        {
            _boxPresenter = boxPresenter;
        }

        [Authorize("Scouting")]
        [HttpGet]
        public JsonResult GetList()
        {
            var res = _boxPresenter.GetList();
            return Json(new DataJsonResult<BoxListRM>(200, "boxes successfully returned", res));
        }

        [Authorize("Scouting")]
        [HttpPost]
        public JsonResult AddBox(BoxRM group)
        {
            var success = _boxPresenter.Add(group);
            if (success)
            {
                return Json(new InfoJsonResult(200, "successfully added box"));
            }
            else
            {
                return Json(new InfoJsonResult(500, "Error on adding box"));
            }
        }

        [Authorize("Scouting")]
        [HttpDelete("{box}")]
        public JsonResult DeleteBox(Guid box)
        {
            var success = _boxPresenter.DeleteById(box);
            if (success)
            {
                return Json(new InfoJsonResult(200, "successfully deleted box"));
            }
            else
            {
                return Json(new InfoJsonResult(500, "Error on deleting box"));
            }
        }

        [Authorize("Scouting")]
        [HttpPatch("{IdBox}")]
        public JsonResult UpdateBox(BoxRM box)
        {
            var success = _boxPresenter.Update(box);
            if (success)
            {
                return Json(new InfoJsonResult(200, "successfully updated box"));
            }
            else
            {
                return Json(new InfoJsonResult(500, "Error on updating box"));
            }
        }

        [HttpGet("{box}")]
        public JsonResult GetBox(Guid box)
        {
            var res = _boxPresenter.GetById(box);
            return Json(new SingleDataJsonResult<BoxRM>(200, "box successfully returned", res));
        }
    }
}
