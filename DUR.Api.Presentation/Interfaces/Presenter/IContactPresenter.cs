﻿using System;
using DUR.Api.Presentation.ResourceModel;

namespace DUR.Api.Presentation.Interfaces.Presenter;

public interface IContactPresenter : IPresenter<ContactRM>
{
    bool DeleteById(Guid id);
    bool Update(ContactRM entity);
    bool Add(ContactRM entity);
    ContactGroupRM GetContacts();
}