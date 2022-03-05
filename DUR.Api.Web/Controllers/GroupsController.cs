using System;
using System.Collections.Generic;
using System.Linq;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Web.Default;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace DUR.Api.Web.Controllers;

public class GroupsController : DefaultController
{
    private readonly IMemoryCache _cache;
    private readonly IGroupPresenter _groupPresenter;

    public GroupsController(IGroupPresenter groupPresenter, IMemoryCache cache)
    {
        _groupPresenter = groupPresenter;
        _cache = cache;
    }

    [HttpGet]
    public JsonResult Get()
    {
        if (!_cache.TryGetValue("groups", out List<GroupListRM> groups))
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(15));

            var res = _groupPresenter.GetAll().OrderBy(x => x.Name).ToList();
            groups = res;

            _cache.Set("groups", res, cacheEntryOptions);
        }

        return Json(new DataJsonResult<GroupListRM>(200, "Groups successfully returned", groups));
    }

    [Authorize("Admin")]
    [HttpPost]
    public JsonResult AddGroup(GroupRM group)
    {
        _cache.Remove("groups");
        var success = _groupPresenter.Add(group);
        if (success)
            return Json(new InfoJsonResult(200, "successfully added group"));
        return Json(new InfoJsonResult(500, "Error on adding group"));
    }

    [Authorize("Admin")]
    [HttpDelete("{group}")]
    public JsonResult DeleteGroup(Guid group)
    {
        _cache.Remove("groups");
        var success = _groupPresenter.DeleteById(group);
        if (success)
            return Json(new InfoJsonResult(200, "successfully deleted group"));
        return Json(new InfoJsonResult(500, "Error on deleting group"));
    }

    [Authorize("Admin")]
    [HttpPatch("{IdGroup}")]
    public JsonResult UpdateGroup(GroupRM group)
    {
        _cache.Remove("groups");
        var success = _groupPresenter.Update(group);
        if (success)
            return Json(new InfoJsonResult(200, "successfully updated group"));
        return Json(new InfoJsonResult(500, "Error on updating group"));
    }

    [HttpGet("{contact}")]
    public JsonResult GetContact(Guid contact)
    {
        var res = _groupPresenter.GetById(contact);
        return Json(new SingleDataJsonResult<GroupRM>(200, "contacts successfully returned", res));
    }
}