using System;
using AutoMapper;
using DUR.Api.Entities;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Services.Interfaces;

namespace DUR.Api.Presentation.Presenter
{
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
            throw new NotImplementedException();
        }

        public override GroupRM GetBlank()
        {
            throw new NotImplementedException();
        }

        public bool Update(GroupRM entity)
        {
            throw new NotImplementedException();
        }

        public override void UpdateBlank(GroupRM entity)
        {
            throw new NotImplementedException();
        }
    }
}
