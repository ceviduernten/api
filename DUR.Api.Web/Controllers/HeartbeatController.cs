using DUR.Api.Web.Default;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

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

        [HttpGet("Test")]
        public JsonResult Test()
        {
            string url = "https://***REMOVED***/remote.php/dav/public-calendars/***REMOVED***?export&accept=jcal";
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(url).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            var s = JsonConvert.DeserializeObject(result);
            return null;
        }
    }
}
