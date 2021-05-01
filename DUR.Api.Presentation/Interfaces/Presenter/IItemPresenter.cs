﻿using DUR.Api.Presentation.ResourceModel;
using System;
using System.Collections.Generic;

namespace DUR.Api.Presentation.Interfaces.Presenter
{
    public interface IItemPresenter : IPresenter<ItemRM>
    {
        bool DeleteById(Guid id);
        bool Update(ItemRM entity);
        bool Add(ItemRM entity);
        new List<ItemListRM> GetAll();
    }
}
