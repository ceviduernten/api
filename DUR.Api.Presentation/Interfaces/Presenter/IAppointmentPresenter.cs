using System;
using System.Collections.Generic;
using DUR.Api.Presentation.ResourceModel;

namespace DUR.Api.Presentation.Interfaces.Presenter;

public interface IAppointmentPresenter : IPresenter<AppointmentRM>
{
    bool DeleteById(Guid id);
    bool Update(AppointmentRM entity);
    bool Add(AppointmentRM entity);
    List<AppointmentRM> GetByGroup(Guid group);
    AppointmentRM GetNextAppointment(Guid group);
    bool SignOffForAppointment(AppointmentResponseRM response);
    bool SignOnForAppointment(AppointmentResponseRM response);
    List<AppointmentResponseListRM> GetResponsesByAppointment(Guid appointment);
}