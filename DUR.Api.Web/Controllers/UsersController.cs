using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Web.Default;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DUR.Api.Web.Controllers
{
    public class UsersController : DefaultController
    {
        private readonly IUserPresenter _userPresenter;

        public UsersController(IUserPresenter userPresenter)
        {
            _userPresenter = userPresenter;
        }

        [Authorize("Admin")]
        [HttpGet]
        public JsonResult GetList()
        {
            var res = _userPresenter.GetAll();
            return Json(new DataJsonResult<UserRM>(200, "boxes successfully returned", res));
        }

        [HttpPost("Login")]
        public JsonResult Login(UserRM user)
        {
            var result = _userPresenter.ValidateUser(user);
            if (result != null)
            {
                return Json(new SingleDataJsonResult<UserRM>(200, "successfully added user", result));
            }
            else
            {
                return Json(new InfoJsonResult(500, "Error on adding user"));
            }
        }

        [Authorize("Admin")]
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

        [Authorize("Admin")]
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

        [Authorize("Admin")]
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

        [Authorize("Admin")]
        [HttpGet("{user}")]
        public JsonResult GetUser(Guid user)
        {
            var res = _userPresenter.GetById(user);
            return Json(new SingleDataJsonResult<UserRM>(200, "user successfully returned", res));
        }
    }
}
