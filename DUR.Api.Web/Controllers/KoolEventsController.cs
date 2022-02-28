using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Web.Default;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace DUR.Api.Web.Controllers
{
    public class KoolController : DefaultController
    {
        private readonly IKoolPresenter _koolPresenter;
        private readonly IMemoryCache _cache;

        public KoolController(IKoolPresenter koolPresenter, IMemoryCache cache)
        {
            _koolPresenter = koolPresenter;
            _cache = cache;
        }

        [HttpGet("events")]
        public JsonResult GetEvents()
        {
            if (!_cache.TryGetValue("koolevents", out List<KoolEventRM> events))
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(4));

                var res = _koolPresenter.GetEvents();
                events = res;

                _cache.Set("koolevents", res, cacheEntryOptions);
            }
            return Json(new DataJsonResult<KoolEventRM>(200, "Events successfully returned", events));
        }

        [HttpGet("reservations")]
        public JsonResult GetReservations()
        {
            if (!_cache.TryGetValue("koolreservations", out List<KoolReservationRM> events))
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(4));

                var res = _koolPresenter.GetReservations();
                events = res;

                _cache.Set("koolreservations", res, cacheEntryOptions);
            }
            return Json(new DataJsonResult<KoolReservationRM>(200, "Events successfully returned", events));
        }
    }
}
