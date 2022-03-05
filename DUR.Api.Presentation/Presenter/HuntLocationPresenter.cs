using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DUR.Api.Entities.Easter;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace DUR.Api.Presentation.Presenter;

public class HuntLocationPresenter : BasePresenter<HuntLocationRM, HuntLocation>, IHuntLocationPresenter
{
    private readonly IMemoryCache _cache;
    private readonly IHuntCityService _huntCityService;
    private readonly IHuntLocationService _huntLocationService;
    private readonly IMapper _mapper;

    public HuntLocationPresenter(IMapper mapper, IMemoryCache cache, IHuntLocationService huntLocationService,
        IHuntCityService huntCityService) : base(huntLocationService, mapper)
    {
        _huntLocationService = huntLocationService;
        _huntCityService = huntCityService;
        _mapper = mapper;
        _cache = cache;
    }

    public bool Add(HuntLocationRM entity)
    {
        var model = _mapper.Map<HuntLocation>(entity);
        if (!string.IsNullOrEmpty(entity.HuntCity.IdHuntCity.ToString()))
            model.HuntCity = _huntCityService.GetById(entity.HuntCity.IdHuntCity);
        var result = _huntLocationService.Add(model);
        var success = result != null;
        return success;
    }

    public bool DeleteById(Guid id)
    {
        return _huntLocationService.DeleteById(id);
    }

    public bool ActivateAllLocations()
    {
        return _huntLocationService.ActivateAllLocations();
    }

    public bool Found(Guid id)
    {
        var location = _huntLocationService.GetById(id);
        if (location != null)
        {
            location.IsFound = true;
            var result = _huntLocationService.Update(location);
            return result != null;
        }

        return false;
    }

    public override HuntLocationRM GetBlank()
    {
        return new HuntLocationRM();
    }

    public List<HuntLocationListRM> GetList()
    {
        var all = _huntLocationService.GetAll().ToList();
        var returnMap = _mapper.Map<IEnumerable<HuntLocation>, List<HuntLocationListRM>>(all);
        return returnMap;
    }

    public List<HuntLocationListRM> GetAllActiveList()
    {
        var all = _huntLocationService.GetAll().Where(x => x.IsActive).ToList();
        var returnMap = _mapper.Map<IEnumerable<HuntLocation>, List<HuntLocationListRM>>(all);
        return returnMap;
    }

    public bool Update(HuntLocationRM entity)
    {
        var db = _mapper.Map<HuntLocationRM, HuntLocation>(entity);
        var elem = _huntLocationService.Update(db);
        return elem != null;
    }

    public override void UpdateBlank(HuntLocationRM entity)
    {
        // NOTHING TO DO HERE
    }
}