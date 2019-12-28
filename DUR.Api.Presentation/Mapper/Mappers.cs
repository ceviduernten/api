using AutoMapper;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Entities;

namespace DUR.Api.Presentation.Mapper
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Event, EventRM>();
            CreateMap<Group, GroupRM>().ForMember(x => x.Mail, opt => opt.Ignore());
            CreateMap<GroupRM, Group>();
            CreateMap<Appointment, AppointmentRM>();
            CreateMap<AppointmentRM, Appointment>();
        }
    }
}
