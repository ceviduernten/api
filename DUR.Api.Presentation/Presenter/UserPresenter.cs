using System;
using AutoMapper;
using DUR.Api.Entities.Admin;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Services.Interfaces;

namespace DUR.Api.Presentation.Presenter;

public class UserPresenter : BasePresenter<UserRM, User>, IUserPresenter
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public UserPresenter(IMapper mapper, IUserService userService) : base(userService, mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public bool Add(UserRM entity)
    {
        var model = _mapper.Map<User>(entity);
        var result = _userService.Add(model);
        var success = result != null;
        return success;
    }

    public bool DeleteById(Guid id)
    {
        return _userService.DeleteById(id);
    }

    public override UserRM GetBlank()
    {
        return new UserRM();
    }

    public new UserRM GetById(Guid id)
    {
        var db = base.GetById(id);
        db.Password = "";
        return db;
    }

    public bool Update(UserRM entity)
    {
        var db = _userService.GetById(entity.IdUser);
        db.LoginName = entity.LoginName;
        db.FullName = entity.FullName;
        db.Vulgo = entity.Vulgo;
        db.Mail = entity.Mail;
        db.Role = entity.Role;
        var elem = _userService.Update(db);
        return elem != null;
    }

    public override void UpdateBlank(UserRM entity)
    {
        // NOTHING TO DO HERE
    }

    public UserRM ValidateUser(UserRM entity)
    {
        var user = _mapper.Map<User>(entity);
        var token = _userService.ValidateUser(user);
        var db = _userService.GetByUsername(entity.LoginName);
        entity.Token = token;
        if (db != null)
        {
            entity.Role = db.Role;
            entity.FullName = db.FullName;
            entity.Vulgo = db.Vulgo;
            entity.IdUser = db.IdUser;
        }

        return entity;
    }
}