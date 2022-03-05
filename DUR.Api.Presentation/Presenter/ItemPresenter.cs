using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DUR.Api.Entities.Stuff;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Services.Interfaces;

namespace DUR.Api.Presentation.Presenter;

public class ItemPresenter : BasePresenter<ItemRM, Item>, IItemPresenter
{
    private readonly IBoxService _boxService;
    private readonly IItemService _itemService;
    private readonly IMapper _mapper;
    private readonly IStorageLocationService _storageLocationService;

    public ItemPresenter(IMapper mapper, IItemService itemService, IBoxService boxService,
        IStorageLocationService storageLocationService) : base(itemService, mapper)
    {
        _itemService = itemService;
        _mapper = mapper;
        _boxService = boxService;
        _storageLocationService = storageLocationService;
    }

    public bool Add(ItemRM entity)
    {
        var model = _mapper.Map<Item>(entity);
        if (!string.IsNullOrEmpty(entity.Location.IdStorageLocation.ToString()))
            model.Location = _storageLocationService.GetById(entity.Location.IdStorageLocation);
        if (!string.IsNullOrEmpty(entity.Location.IdStorageLocation.ToString()))
            model.Box = _boxService.GetById(entity.Box.IdBox);
        var result = _itemService.Add(model);
        var success = result != null;
        return success;
    }

    public bool DeleteById(Guid id)
    {
        return _itemService.DeleteById(id);
    }

    public override ItemRM GetBlank()
    {
        return new ItemRM();
    }

    public bool Update(ItemRM entity)
    {
        var mappedItem = _mapper.Map<ItemRM, Item>(entity);
        Item db;
        if (mappedItem.Box != null && mappedItem.Box.IdBox == new Guid() ||
            mappedItem.Location != null && mappedItem.Location.IdStorageLocation == new Guid())
        {
            db = _itemService.GetById(entity.IdItem);
            db.Price = mappedItem.Price;
            db.QuantityType = mappedItem.QuantityType;
            db.Description = mappedItem.Description;
            db.Quantity = mappedItem.Quantity;
        }
        else
        {
            db = mappedItem;
        }

        if (mappedItem.Box != null && mappedItem.Box.IdBox == new Guid()) db.Box = null;
        if (mappedItem.Location != null && mappedItem.Location.IdStorageLocation == new Guid()) db.Location = null;
        if (mappedItem.Box != null && mappedItem.Box.IdBox != new Guid())
            db.Box = _boxService.GetById(mappedItem.Box.IdBox);
        if (mappedItem.Location != null && mappedItem.Location.IdStorageLocation != new Guid())
            db.Location = _storageLocationService.GetById(mappedItem.Location.IdStorageLocation);
        var elem = _itemService.Update(db);
        return elem != null;
    }

    public override void UpdateBlank(ItemRM entity)
    {
        // NOTHING TO DO HERE
    }

    public new List<ItemListRM> GetAll()
    {
        var all = _itemService.GetAll().ToList();
        var returnMap = _mapper.Map<IEnumerable<Item>, List<ItemListRM>>(all);
        return returnMap;
    }
}