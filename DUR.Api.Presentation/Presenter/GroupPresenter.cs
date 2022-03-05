using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DUR.Api.Entities;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Services.Interfaces;

namespace DUR.Api.Presentation.Presenter;

public class GroupPresenter : BasePresenter<GroupRM, Group>, IGroupPresenter
{
    private readonly IGroupService _groupService;
    private readonly IMapper _mapper;

    public GroupPresenter(IMapper mapper, IGroupService groupService) : base(groupService, mapper)
    {
        _groupService = groupService;
        _mapper = mapper;
    }

    public bool Add(GroupRM entity)
    {
        var model = _mapper.Map<Group>(entity);
        var result = _groupService.Add(model);
        var success = result != null;
        return success;
    }

    public bool DeleteById(Guid id)
    {
        return _groupService.DeleteById(id);
    }

    public override GroupRM GetBlank()
    {
        return new GroupRM();
    }

    public bool Update(GroupRM entity)
    {
        var db = _mapper.Map<GroupRM, Group>(entity);
        var elem = _groupService.Update(db);
        return elem != null;
    }

    public override void UpdateBlank(GroupRM entity)
    {
        // NOTHING TO DO HERE
    }

    public override GroupRM GetById(Guid id)
    {
        var entity = _groupService.GetById(id);
        var model = _mapper.Map<Group, GroupRM>(entity);
        UpdateBlank(model);
        if (model != null) model.Mail = entity.Mail;
        return model;
    }

    List<GroupListRM> IGroupPresenter.GetAll()
    {
        var all = _groupService.GetAll().ToList();
        var returnMap = _mapper.Map<IEnumerable<Group>, List<GroupListRM>>(all);
        return returnMap;
    }
}