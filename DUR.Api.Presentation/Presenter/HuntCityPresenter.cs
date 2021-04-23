using System;
using AutoMapper;
using DUR.Api.Entities.Easter;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace DUR.Api.Presentation.Presenter
{
    public class HuntCityPresenter : BasePresenter<HuntCityRM, HuntCity>, IHuntCityPresenter
    {
        private readonly IHuntCityService _huntCityService;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public HuntCityPresenter(IMapper mapper, IMemoryCache cache, IHuntCityService huntCityService) : base(huntCityService, mapper)
        {
            _huntCityService = huntCityService;
            _mapper = mapper;
            _cache = cache;
        }

        public bool Add(HuntCityRM entity)
        {
            var model = _mapper.Map<HuntCity>(entity);
            var result = _huntCityService.Add(model);
            var success = result != null;
            return success;
        }

        public bool DeleteById(Guid id)
        {
            return _huntCityService.DeleteById(id);
        }

        public override HuntCityRM GetBlank()
        {
            return new HuntCityRM();
        }

        public bool Update(HuntCityRM entity)
        {
            var db = _mapper.Map<HuntCityRM, HuntCity>(entity);
            var elem = _huntCityService.Update(db);
            return (elem != null);
        }

        public override void UpdateBlank(HuntCityRM entity)
        {
            // NOTHING TO DO HERE
        }
    }
}
