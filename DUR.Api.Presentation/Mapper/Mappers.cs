using AutoMapper;
using DUR.Api.Entities;
using DUR.Api.Entities.Admin;
using DUR.Api.Entities.Easter;
using DUR.Api.Entities.Stuff;
using DUR.Api.Presentation.ResourceModel;

namespace DUR.Api.Presentation.Mapper
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Event, EventRM>();
            CreateMap<KoolEvent, KoolEventRM>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(k => k.Summary));
            CreateMap<Group, GroupRM>();
            CreateMap<Group, GroupListRM>();
            CreateMap<GroupRM, Group>();
            CreateMap<Appointment, AppointmentRM>();
            CreateMap<AppointmentRM, Appointment>();
            CreateMap<AppointmentResponse, AppointmentResponseListRM>();
            CreateMap<AppointmentResponseRM, AppointmentResponse>()
                .ForMember(dest => dest.AppointmentId, opt => opt.MapFrom(o => o.IdAppointment));
            CreateMap<Contact, ContactRM>();
            CreateMap<ContactRM, Contact>();

            CreateMap<Box, BoxRM>();
            CreateMap<BoxRM, Box>();

            CreateMap<HuntLocation, HuntLocationRM>();
            CreateMap<HuntLocationRM, HuntLocation>();
            CreateMap<HuntLocation, HuntLocationListRM>();
            CreateMap<HuntCity, HuntCityRM>();
            CreateMap<HuntCityRM, HuntCity>();

            CreateMap<User, UserRM>();
            CreateMap<UserRM, User>();

            CreateMap<Item, ItemRM>();
            CreateMap<ItemRM, Item>();

            CreateMap<StorageLocation, StorageLocationRM>();
            CreateMap<StorageLocationRM, StorageLocation>();

            CreateMap<Item, ItemExportRM>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(o => o.Description))
                .ForMember(dest => dest.IdItem, opt => opt.MapFrom(o => o.IdItem))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(o => o.Quantity))
                .ForMember(dest => dest.QuantityType, opt => opt.MapFrom(o => o.QuantityType.ToString()))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(o => o.Price))
                .ForMember(dest => dest.Box, opt => opt.MapFrom(o => o.Box.Description))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(o => o.Location.ShortName));

            CreateMap<Item, ItemListRM>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(o => o.Description))
                .ForMember(dest => dest.IdItem, opt => opt.MapFrom(o => o.IdItem))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(o => o.Quantity))
                .ForMember(dest => dest.QuantityType, opt => opt.MapFrom(o => o.QuantityType.ToString()))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(o => o.Price))
                .ForMember(dest => dest.Box, opt => opt.MapFrom(o => o.Box.Description))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(o => o.Location.ShortName));

            CreateMap<Box, BoxListRM>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(o => o.Location.ShortName));
        }
    }
}
