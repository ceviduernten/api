using System;
using System.Collections.Generic;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Web.Default;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace DUR.Api.Web.Controllers
{
    public class GroupsController : DefaultController
    {
        private readonly IGroupPresenter _groupPresenter;
        private readonly IMemoryCache _cache;

        public GroupsController(IGroupPresenter groupPresenter, IMemoryCache cache)
        {
            _groupPresenter = groupPresenter;
            _cache = cache;
        }

        [HttpGet]
        public JsonResult Get()
        {
            if (!_cache.TryGetValue("groups", out List<EventRM> events))
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(15));

                var res = _groupPresenter.GetAll();
                events = res;

                _cache.Set("groups", res, cacheEntryOptions);
            }
            return Json(new DataJsonResult<GroupRM>(200, "Groups successfully returned", events));
        }
    }
}
