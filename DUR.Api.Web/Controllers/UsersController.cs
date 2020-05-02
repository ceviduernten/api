using System;
using System.Linq;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Web.Default;
using Microsoft.AspNetCore.Mvc;

namespace DUR.Api.Web.Controllers
{
    public class UsersController : DefaultController
    {
        private readonly IUserPresenter _userPresenter;

        public UsersController(IUserPresenter userPresenter)
        {
            _userPresenter = userPresenter;
        }

        [HttpGet]
        public JsonResult GetList()
        {
            var res = _userPresenter.GetAll();
            return Json(new DataJsonResult<UserRM>(200, "boxes successfully returned", res));
        }

        [HttpPost]
        public JsonResult AddUser(UserRM user)
        {
            var success = _userPresenter.Add(user);
            if (success)
            {
                return Json(new InfoJsonResult(200, "successfully added user"));
            }
            else
            {
                return Json(new InfoJsonResult(500, "Error on adding user"));
            }
        }

        [HttpDelete("{user}")]
        public JsonResult DeleteUser(Guid user)
        {
            var success = _userPresenter.DeleteById(user);
            if (success)
            {
                return Json(new InfoJsonResult(200, "successfully deleted user"));
            }
            else
            {
                return Json(new InfoJsonResult(500, "Error on deleting user"));
            }
        }

        [HttpPatch("{IdUser}")]
        public JsonResult UpdateUser(UserRM user)
        {
            var success = _userPresenter.Update(user);
            if (success)
            {
                return Json(new InfoJsonResult(200, "successfully updated user"));
            }
            else
            {
                return Json(new InfoJsonResult(500, "Error on updating user"));
            }
        }

        [HttpGet("{user}")]
        public JsonResult GetUser(Guid user)
        {
            var res = _userPresenter.GetById(user);
            return Json(new SingleDataJsonResult<UserRM>(200, "user successfully returned", res));
        }
    }
}
