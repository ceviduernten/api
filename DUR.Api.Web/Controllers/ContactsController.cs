using System;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Web.Default;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace DUR.Api.Web.Controllers
{
    public class ContactsController : DefaultController
    {
        private readonly IContactPresenter _contactPresenter;
        private readonly IMemoryCache _cache;

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
            return Json(new SingleDataJsonResult<ContactGroupRM>(200, "Events successfully returned", contacts));
        }

        [HttpPost]
        public JsonResult AddContact(ContactRM group)
        {
            _cache.Remove("contacts");
            var success = _contactPresenter.Add(group);
            if (success)
            {
                return Json(new InfoJsonResult(200, "successfully added contact"));
            }
            else
            {
                return Json(new InfoJsonResult(500, "Error on adding contact"));
            }
        }
    }
}
