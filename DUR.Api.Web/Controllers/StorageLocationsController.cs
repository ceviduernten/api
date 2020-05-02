using System;
using System.Linq;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Web.Default;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DUR.Api.Web.Controllers
{
    public class StorageLocationsController : DefaultController
    {
        private readonly IStorageLocationPresenter _storageLocationPresenter;

        public StorageLocationsController(IStorageLocationPresenter storageLocationPresenter)
        {
            _storageLocationPresenter = storageLocationPresenter;
        }

        [HttpGet]
        public JsonResult GetList()
        {
            var res = _storageLocationPresenter.GetAll().OrderBy(x => x.ShortName).ToList();
            return Json(new DataJsonResult<StorageLocationRM>(200, "storage locations successfully returned", res));
        }

        [Authorize("Stuff")]
        [HttpPost]
        public JsonResult AddContact(StorageLocationRM group)
        {
            var success = _storageLocationPresenter.Add(group);
            if (success)
            {
                return Json(new InfoJsonResult(200, "successfully added storage location"));
            }
            else
            {
                return Json(new InfoJsonResult(500, "Error on adding storage location"));
            }
        }

        [Authorize("Stuff")]
        [HttpDelete("{storageLocation}")]
        public JsonResult DeleteContact(Guid storageLocation)
        {
            var success = _storageLocationPresenter.DeleteById(storageLocation);
            if (success)
            {
                return Json(new InfoJsonResult(200, "successfully deleted storage location"));
            }
            else
            {
                return Json(new InfoJsonResult(500, "Error on deleting storage location"));
            }
        }

        [Authorize("Stuff")]
        [HttpPatch("{IdStorageLocation}")]
        public JsonResult UpdateStorageLocation(StorageLocationRM contact)
        {
            var success = _storageLocationPresenter.Update(contact);
            if (success)
            {
                return Json(new InfoJsonResult(200, "successfully updated storage location"));
            }
            else
            {
                return Json(new InfoJsonResult(500, "Error on updating storage location"));
            }
        }

        [HttpGet("{storageLocation}")]
        public JsonResult GetContact(Guid storageLocation)
        {
            var res = _storageLocationPresenter.GetById(storageLocation);
            return Json(new SingleDataJsonResult<StorageLocationRM>(200, "storage location successfully returned", res));
        }
    }
}
