using System;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Web.Default;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DUR.Api.Web.Controllers
{
    [Authorize("Scouting")]
    public class ExportsController : DefaultController
    {
        private readonly IExportPresenter _exportPresenter;

        public ExportsController(IExportPresenter exportPresenter)
        {
            _exportPresenter = exportPresenter;
        }

        [HttpGet("All")]
        public JsonResult GetWholeInventory()
        {
            var export = _exportPresenter.GetWholeInventory();
            return Json(new SingleDataJsonResult<ExportRM<ItemExportRM>>(200, "inventory list successfully returned", export));
        }

        [HttpGet("Boxes")]
        public JsonResult GetAllBoxes()
        {
            var export = _exportPresenter.GetAllBoxes();
            return Json(new SingleDataJsonResult<ExportRM<BoxRM>>(200, "inventory list successfully returned", export));
        }

        [HttpGet("{location}")]
        public JsonResult Get(Guid location)
        {
            var export = _exportPresenter.GetInventoryByLocation(location);
            return Json(new SingleDataJsonResult<ExportRM<ItemExportRM>>(200, "inventory list successfully returned", export));
        }
    }
}
