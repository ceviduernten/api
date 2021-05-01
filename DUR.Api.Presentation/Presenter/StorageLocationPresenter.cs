using AutoMapper;
using DUR.Api.Entities.Stuff;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Services.Interfaces;
using System;

namespace DUR.Api.Presentation.Presenter
{
    public class StorageLocationPresenter : BasePresenter<StorageLocationRM, StorageLocation>, IStorageLocationPresenter
    {
        private readonly IStorageLocationService _storageLocationService;
        private readonly IMapper _mapper;

        public StorageLocationPresenter(IMapper mapper, IStorageLocationService storageLocationService) : base(storageLocationService, mapper)
        {
            _storageLocationService = storageLocationService;
            _mapper = mapper;
        }

        public bool Add(StorageLocationRM entity)
        {
            var model = _mapper.Map<StorageLocation>(entity);
            var result = _storageLocationService.Add(model);
            var success = result != null;
            return success;
        }

        public bool DeleteById(Guid id)
        {
            return _storageLocationService.DeleteById(id);
        }

        public override StorageLocationRM GetBlank()
        {
            return new StorageLocationRM();
        }

        public bool Update(StorageLocationRM entity)
        {
            var db = _mapper.Map<StorageLocationRM, StorageLocation>(entity);
            var elem = _storageLocationService.Update(db);
            return (elem != null);
        }

        public override void UpdateBlank(StorageLocationRM entity)
        {
            // NOTHING TO DO HERE
        }
    }
}
