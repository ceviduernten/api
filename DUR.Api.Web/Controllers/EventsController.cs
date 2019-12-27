using System;
using System.Collections.Generic;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Web.Default;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace DUR.Api.Web.Controllers
{
    public class EventsController : DefaultController
    {
        private readonly IEventPresenter _eventPresenter;
        private readonly IMemoryCache _cache;

        public EventsController(IEventPresenter eventPresenter, IMemoryCache cache)
        {
            _eventPresenter = eventPresenter;
            _cache = cache;
        }

        [HttpGet]
        public JsonResult Get()
        {
            if (!_cache.TryGetValue("events", out List<EventRM> events))
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(15));

                var res = _eventPresenter.GetEvents();
                events = res;

                _cache.Set("events", res, cacheEntryOptions);
            }
            return Json(new DataJsonResult<EventRM>(200, "Events successfully returned", events));
        }
    }
}
