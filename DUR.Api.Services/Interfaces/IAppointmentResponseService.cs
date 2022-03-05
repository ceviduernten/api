using DUR.Api.Entities;

namespace DUR.Api.Services.Interfaces;

public interface IAppointmentResponseService : IDatabaseService<AppointmentResponse>
{
    bool SignOffForAppointment(AppointmentResponse response);
    bool SignOnForAppointment(AppointmentResponse response);
}