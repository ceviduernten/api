using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Settings;
using DUR.Api.Web.Default;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DUR.Api.Web.Controllers
{
    public class ServicesController : DefaultController
    {
        private readonly IHuntLocationPresenter _huntLocationPresenter;
        private readonly GeneralSettings _generalSettings;

        public ServicesController(IHuntLocationPresenter huntLocationPresenter, IOptions<GeneralSettings> settings)
        {
            _huntLocationPresenter = huntLocationPresenter;
            _generalSettings = settings.Value;
        }

        [HttpPost("Locations")]
        public JsonResult ActivateLocations(string password)
        {
            if (string.IsNullOrEmpty(password)) return Json(new InfoJsonResult(401, "Forbidden"));
            string seucreHash = ComputeSha256Hash(password);
            if (seucreHash != _generalSettings.ServiceHash) return Json(new InfoJsonResult(401, "Forbidden"));
            var success = _huntLocationPresenter.ActivateAllLocations();
            if (success)
            {
                return Json(new InfoJsonResult(200, "successfully activated all locations"));
            }
            else
            {
                return Json(new InfoJsonResult(500, "Error on activating all locations"));
            }
        }
    }
}
