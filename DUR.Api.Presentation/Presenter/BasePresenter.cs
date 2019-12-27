﻿using System;
using System.Collections.Generic;
using AutoMapper;
using DUR.Api.Entities;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;

namespace DUR.Api.Presentation.Presenter
{
    public abstract class BasePresenter<entityRM, entity> : IPresenter<entityRM> where entityRM : BaseRM where entity : Base
    {
        // Logger
        private readonly IDatabaseBaseService<entity> _entityService;
        private readonly IMapper _mapper;

        protected BasePresenter(IDatabaseBaseService<entity> entityService, IMapper mapper)
        {
            _entityService = entityService;
            _mapper = mapper;
        }

        public virtual List<entityRM> GetAll()
        {
            var all = _entityService.GetAll().ToList();
            var returnMap = _mapper.Map<IEnumerable<entity>, List<entityRM>>(all);
            return returnMap;
        }

        public abstract entityRM GetBlank();

        public virtual entityRM GetById(int id)
        {
            var entity = _entityService.GetById(id);
            var model = _mapper.Map<entity, entityRM>(entity);
            UpdateBlank(model);
            return model;
        }

        public virtual entityRM GetById(Guid id)
        {
            var entity = _entityService.GetById(id);
            var model = _mapper.Map<entity, entityRM>(entity);
            UpdateBlank(model);
            return model;
        }

        public abstract void UpdateBlank(entityRM entity);

    }
}
