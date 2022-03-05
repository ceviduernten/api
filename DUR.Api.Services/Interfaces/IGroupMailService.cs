using DUR.Api.Entities;

namespace DUR.Api.Services.Interfaces;

public interface IGroupMailService
{
    bool InformGroup(Appointment appointment);
    bool InformLeaders(Appointment appointment);
    bool SignOn(AppointmentResponse response);
    bool SignOff(AppointmentResponse response);
}