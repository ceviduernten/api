using DUR.Api.Web.Default;
using Microsoft.AspNetCore.Mvc;

namespace DUR.Api.Web.Controllers
{
    public class HeartbeatController : DefaultController
    {
        public HeartbeatController()
        {

        }

        [HttpGet]
        public JsonResult Current()
        {
            return Json(new InfoJsonResult(200, "System Heartbeat oke"));
        }
    }
}
