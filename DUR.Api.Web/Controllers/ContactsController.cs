using System;
using System.Linq;
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
            return Json(new SingleDataJsonResult<ContactGroupRM>(200, "contacts successfully returned", contacts));
        }

        [HttpGet("List")]
        public JsonResult GetList()
        {
            var res = _contactPresenter.GetAll().OrderBy(x => x.Type).ToList();
            return Json(new DataJsonResult<ContactRM>(200, "contacts successfully returned", res));
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

        [HttpDelete("{contact}")]
        public JsonResult DeleteContact(Guid contact)
        {
            _cache.Remove("contacts");
            var success = _contactPresenter.DeleteById(contact);
            if (success)
            {
                return Json(new InfoJsonResult(200, "successfully deleted contact"));
            }
            else
            {
                return Json(new InfoJsonResult(500, "Error on deleting contact"));
            }
        }

        [HttpPatch("{IdContact}")]
        public JsonResult UpdateContact(ContactRM contact)
        {
            _cache.Remove("contacts");
            var success = _contactPresenter.Update(contact);
            if (success)
            {
                return Json(new InfoJsonResult(200, "successfully updated contact"));
            }
            else
            {
                return Json(new InfoJsonResult(500, "Error on updating contact"));
            }
        }

        [HttpGet("{contact}")]
        public JsonResult GetContact(Guid contact)
        {
            var res = _contactPresenter.GetById(contact);
            return Json(new SingleDataJsonResult<ContactRM>(200, "contacts successfully returned", res));
        }
    }
}
