using System;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Web.Default;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DUR.Api.Web.Controllers
{
    public class ItemsController : DefaultController
    {
        private readonly IItemPresenter _itemPresenter;

        public ItemsController(IItemPresenter itemPresenter)
        {
            _itemPresenter = itemPresenter;
        }

        [Authorize("Scouting")]
        [HttpGet]
        public JsonResult GetList()
        {
            var res = _itemPresenter.GetAll();
            return Json(new DataJsonResult<ItemListRM>(200, "items successfully returned", res));
        }

        [Authorize("Scouting")]
        [HttpPost]
        public JsonResult AddItem(ItemRM item)
        {
            var success = _itemPresenter.Add(item);
            if (success)
            {
                return Json(new InfoJsonResult(200, "successfully added item"));
            }
            else
            {
                return Json(new InfoJsonResult(500, "Error on adding item"));
            }
        }

        [Authorize("Scouting")]
        [HttpDelete("{item}")]
        public JsonResult DeleteItem(Guid item)
        {
            var success = _itemPresenter.DeleteById(item);
            if (success)
            {
                return Json(new InfoJsonResult(200, "successfully deleted item"));
            }
            else
            {
                return Json(new InfoJsonResult(500, "Error on deleting item"));
            }
        }

        [Authorize("Scouting")]
        [HttpPatch("{IdItem}")]
        public JsonResult UpdateItem(ItemRM item)
        {
            var success = _itemPresenter.Update(item);
            if (success)
            {
                return Json(new InfoJsonResult(200, "successfully updated item"));
            }
            else
            {
                return Json(new InfoJsonResult(500, "Error on updating item"));
            }
        }

        [HttpGet("{item}")]
        public JsonResult GetBox(Guid item)
        {
            var res = _itemPresenter.GetById(item);
            return Json(new SingleDataJsonResult<ItemRM>(200, "item successfully returned", res));
        }
    }
}
