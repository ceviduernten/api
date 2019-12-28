using System;
using System.Linq;
using AutoMapper;
using DUR.Api.Entities;
using DUR.Api.Entities.Contacts;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Services.Interfaces;

namespace DUR.Api.Presentation.Presenter
{
    public class ContactPresenter : BasePresenter<ContactRM, Contact>, IContactPresenter
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactPresenter(IMapper mapper, IContactService contactService) : base(contactService, mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public bool Add(ContactRM entity)
        {
            var model = _mapper.Map<Contact>(entity);
            var result = _contactService.Add(model);
            var success = result != null;
            return success;
        }

        public bool DeleteById(Guid id)
        {
            return _contactService.DeleteById(id);
        }

        public override ContactRM GetBlank()
        {
            return new ContactRM();
        }

        public ContactGroupRM GetContacts()
        {
            var allContacts = GetAll();
            ContactGroupRM contactGroup = new ContactGroupRM();
            contactGroup.Jungschar = allContacts.Where(x => x.Type == ContactType.JUNGSCHAR).OrderByDescending(x => x.Phone).ToList();
            contactGroup.Froeschli = allContacts.Where(x => x.Type == ContactType.FROESCHLI).OrderByDescending(x => x.Phone).ToList();
            contactGroup.Verein = allContacts.Where(x => x.Type == ContactType.VEREIN).OrderByDescending(x => x.Phone).ToList();
            return contactGroup;
        }

        public bool Update(ContactRM entity)
        {
            var db = _mapper.Map<ContactRM, Contact>(entity);
            var elem = _contactService.Update(db);
            return (elem != null);
        }

        public override void UpdateBlank(ContactRM entity)
        {
            // NOTHING TO DO HERE
        }
    }
}
