using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DUR.Api.Entities;
using DUR.Api.Entities.Stuff;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Services.Interfaces;

namespace DUR.Api.Presentation.Presenter
{
    public class ExportPresenter : IExportPresenter
    {
        private readonly IBoxPresenter _boxPresenter;
        private readonly IStorageLocationPresenter _storageLocationPresenter;
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public ExportPresenter(IBoxPresenter boxPresenter, IItemService itemService, IStorageLocationPresenter storageLocationPresenter, IMapper mapper)
        {
            _mapper = mapper;
            _boxPresenter = boxPresenter;
            _itemService = itemService;
            _storageLocationPresenter = storageLocationPresenter;
        }

        public ExportRM<BoxRM> GetAllBoxes()
        {
            var boxes = _boxPresenter.GetAll();
            var export = new ExportRM<BoxRM>
            {
                Description = "Alle Kisten im Besitz vom Cevi Dürnten",
                Title = "Kisteninventar",
                Data = boxes,
                Type = "Boxes"
            };
            return export;

        }

        public ExportRM<ItemExportRM> GetInventoryByLocation(Guid location)
        {
            var loc = _storageLocationPresenter.GetById(location);
            var items = _itemService.GetAll().Where(elem => elem.Location != null && elem.Location.IdStorageLocation == location).ToList();
            var itemsInBoxes = _itemService.GetAll().Where(elem => elem.Box != null && elem.Box.Location.IdStorageLocation == location).ToList();
            List<Item> allItems = new List<Item>();
            allItems.AddRange(items);
            allItems.AddRange(itemsInBoxes);
            var mappedData = _mapper.Map<List<Item>, List<ItemExportRM>>(allItems);
            var export = new ExportRM<ItemExportRM>
            {
                Description = "Inventarliste vom Lagerort " + loc.ShortName + ", an der Adresse " + loc.Address + ", " + loc.Zip + " " + loc.City,
                Title = "Inventar " + loc.ShortName,
                Data = mappedData,
                Type = "Inventory"
            };
            return export;
        }

        public ExportRM<ItemExportRM> GetWholeInventory()
        {
            var items = _itemService.GetAll();
            var mappedData = _mapper.Map<List<Item>, List<ItemExportRM>>(items);
            var export = new ExportRM<ItemExportRM>
            {
                Description = "Gesamteinventarliste vom Cevi Dürnten",
                Title = "Gesamtinventar",
                Data = mappedData,
                Type = "Inventory"
            };
            return export;
        }
    }
}
