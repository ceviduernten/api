using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Web.Default;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;

namespace DUR.Api.Web.Controllers
{
    [Authorize("Scouting")]
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
        
        [HttpPost("reservations")]
        public JsonResult AddReservation(ReservationRM reservation)
        {
            var success = _koolPresenter.Add(reservation);
            if (success)
            {
                return Json(new InfoJsonResult(200, "successfully added reservation"));
            }
            else
            {
                return Json(new InfoJsonResult(500, "Error on adding reservation"));
            }
        }
    }
}
