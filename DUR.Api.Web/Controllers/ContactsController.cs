﻿using System;
using System.Linq;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Web.Default;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace DUR.Api.Web.Controllers;

public class ContactsController : DefaultController
{
    private readonly IMemoryCache _cache;
    private readonly IContactPresenter _contactPresenter;

    public ContactsController(IContactPresenter contactPresenter, IMemoryCache cache)
    {
        _contactPresenter = contactPresenter;
        _cache = cache;
    }

    [HttpGet]
    public JsonResult Get()
    {
        if (!_cache.TryGetValue("contacts", out ContactGroupRM contacts))
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30));

            var res = _contactPresenter.GetContacts();
            contacts = res;

            _cache.Set("contacts", res, cacheEntryOptions);
        }

        return Json(new SingleDataJsonResult<ContactGroupRM>(200, "contacts successfully returned", contacts));
    }

    [Authorize("Admin")]
    [HttpGet("List")]
    public JsonResult GetList()
    {
        var res = _contactPresenter.GetAll().OrderBy(x => x.Type).ToList();
        return Json(new DataJsonResult<ContactRM>(200, "contacts successfully returned", res));
    }

    [Authorize("Admin")]
    [HttpPost]
    public JsonResult AddContact(ContactRM group)
    {
        _cache.Remove("contacts");
        var success = _contactPresenter.Add(group);
        if (success)
            return Json(new InfoJsonResult(200, "successfully added contact"));
        return Json(new InfoJsonResult(500, "Error on adding contact"));
    }

    [Authorize("Admin")]
    [HttpDelete("{contact}")]
    public JsonResult DeleteContact(Guid contact)
    {
        _cache.Remove("contacts");
        var success = _contactPresenter.DeleteById(contact);
        if (success)
            return Json(new InfoJsonResult(200, "successfully deleted contact"));
        return Json(new InfoJsonResult(500, "Error on deleting contact"));
    }

    [Authorize("Admin")]
    [HttpPatch("{IdContact}")]
    public JsonResult UpdateContact(ContactRM contact)
    {
        _cache.Remove("contacts");
        var success = _contactPresenter.Update(contact);
        if (success)
            return Json(new InfoJsonResult(200, "successfully updated contact"));
        return Json(new InfoJsonResult(500, "Error on updating contact"));
    }

    [Authorize("Admin")]
    [HttpGet("{contact}")]
    public JsonResult GetContact(Guid contact)
    {
        var res = _contactPresenter.GetById(contact);
        return Json(new SingleDataJsonResult<ContactRM>(200, "contacts successfully returned", res));
    }
}