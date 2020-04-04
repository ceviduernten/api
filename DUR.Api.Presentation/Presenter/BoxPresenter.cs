using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DUR.Api.Entities.Stuff;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Services.Interfaces;

namespace DUR.Api.Presentation.Presenter
{
    public class BoxPresenter : BasePresenter<BoxRM, Box>, IBoxPresenter
    {
        private readonly IBoxService _boxService;
        private readonly IStorageLocationService _storageLocationService;
        private readonly IMapper _mapper;

        public BoxPresenter(IMapper mapper, IBoxService boxService, IStorageLocationService storageLocationService) : base(boxService, mapper)
        {
            _boxService = boxService;
            _storageLocationService = storageLocationService;
            _mapper = mapper;
        }

        public bool Add(BoxRM entity)
        {
            var model = _mapper.Map<Box>(entity);
            if (!string.IsNullOrEmpty(entity.Location.IdStorageLocation.ToString()))
            {
                model.Location = _storageLocationService.GetById(entity.Location.IdStorageLocation);
            }
            var result = _boxService.Add(model);
            var success = result != null;
            return success;
        }

        public bool DeleteById(Guid id)
        {
            return _boxService.DeleteById(id);
        }

        public override BoxRM GetBlank()
        {
            return new BoxRM();
        }

        public bool Update(BoxRM entity)
        {
            var db = _mapper.Map<BoxRM, Box>(entity);
            var elem = _boxService.Update(db);
            return (elem != null);
        }

        public override void UpdateBlank(BoxRM entity)
        {
            // NOTHING TO DO HERE
        }

        public new List<BoxListRM> GetAll()
        {
            var all = _boxService.GetAll().ToList();
            var returnMap = _mapper.Map<IEnumerable<Box>, List<BoxListRM>>(all);
            return returnMap;
        }
    }
}
