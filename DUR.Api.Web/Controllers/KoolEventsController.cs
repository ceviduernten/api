using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Web.Default;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace DUR.Api.Web.Controllers
{
    public class KoolEventsController : DefaultController
    {
        private readonly IKoolEventPresenter _koolEventPresenter;
        private readonly IMemoryCache _cache;

        public KoolEventsController(IKoolEventPresenter koolEventPresenter, IMemoryCache cache)
        {
            _koolEventPresenter = koolEventPresenter;
            _cache = cache;
        }

        [HttpGet("events")]
        public JsonResult GetEvents()
        {
            if (!_cache.TryGetValue("koolevents", out List<KoolEventRM> events))
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(4));

                var res = _koolEventPresenter.GetEvents();
                events = res;

                _cache.Set("events", res, cacheEntryOptions);
            }
            return Json(new DataJsonResult<KoolEventRM>(200, "Events successfully returned", events));
        }

        [HttpGet("reservations")]
        public JsonResult GetReservations()
        {
            if (!_cache.TryGetValue("koolreservations", out List<KoolEventRM> events))
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(4));

                var res = _koolEventPresenter.GetReservations();
                events = res;

                _cache.Set("events", res, cacheEntryOptions);
            }
            return Json(new DataJsonResult<KoolEventRM>(200, "Events successfully returned", events));
        }
    }
}
