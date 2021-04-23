using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DUR.Api.Entities;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Services.Interfaces;

namespace DUR.Api.Presentation.Presenter
{
    public class AppointmentPresenter : BasePresenter<AppointmentRM, Appointment>, IAppointmentPresenter
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IAppointmentResponseService _appointmentResponseService;
        private readonly IMapper _mapper;
        private readonly IGroupMailService _groupMailService;

        public AppointmentPresenter(IMapper mapper, IAppointmentService appointmentService, IGroupMailService groupMailService, IAppointmentResponseService appointmentResponseService) : base(appointmentService, mapper)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
            _groupMailService = groupMailService;
            _appointmentResponseService = appointmentResponseService;
        }

        public bool Add(AppointmentRM entity)
        {
            var model = _mapper.Map<Appointment>(entity);
            var result = _appointmentService.Add(model);
            var success = result != null;
            if (success)
            {
                _groupMailService.InformGroup(result);
                _groupMailService.InformLeaders(result);
            }
            return success;
        }

        public bool DeleteById(Guid id)
        {
            return _appointmentService.DeleteById(id);
        }

        public override AppointmentRM GetBlank()
        {
            return new AppointmentRM();
        }

        public List<AppointmentRM> GetByGroup(Guid group)
        {
            if (group == Guid.Empty) return new List<AppointmentRM>();
            var all = _appointmentService.GetAppointmentsByGroup(group);
            var returnMap = _mapper.Map<List<Appointment>, List<AppointmentRM>>(all);
            return returnMap;
        }

        public AppointmentRM GetNextAppointment(Guid group)
        {
            return GetByGroup(group).OrderBy(x => x.Date).FirstOrDefault();
        }

        public List<AppointmentResponseListRM> GetResponsesByAppointment(Guid appointment)
        {
            var list = _appointmentResponseService.GetAll().Where(x => x.AppointmentId == appointment).ToList();
            var returnMap = _mapper.Map<List<AppointmentResponse>, List<AppointmentResponseListRM>>(list);
            return returnMap;
        }

        public bool SignOffForAppointment(AppointmentResponseRM response)
        {
            var res = _mapper.Map<AppointmentResponse>(response);
            return _appointmentResponseService.SignOffForAppointment(res);
        }

        public bool SignOnForAppointment(AppointmentResponseRM response)
        {
            var res = _mapper.Map<AppointmentResponse>(response);
            return _appointmentResponseService.SignOnForAppointment(res);
        }

        public bool Update(AppointmentRM entity)
        {
            var db = _mapper.Map<AppointmentRM, Appointment>(entity);
            var elem = _appointmentService.Update(db);
            return (elem != null);
        }

        public override void UpdateBlank(AppointmentRM entity)
        {
            // NOTHING TO DO HERE
        }
    }
}
