using System;
using AutoMapper;
using DUR.Api.Entities.Admin;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Services.Interfaces;

namespace DUR.Api.Presentation.Presenter
{
    public class UserPresenter : BasePresenter<UserRM, User>, IUserPresenter
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

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

        public bool Update(UserRM entity)
        {
            var db = _mapper.Map<UserRM, User>(entity);
            var elem = _userService.Update(db);
            return (elem != null);
        }

        public override void UpdateBlank(UserRM entity)
        {
            // NOTHING TO DO HERE
        }
    }
}
