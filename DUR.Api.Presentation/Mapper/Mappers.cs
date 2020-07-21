﻿using AutoMapper;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Entities;
using DUR.Api.Entities.Stuff;
using DUR.Api.Entities.Admin;

namespace DUR.Api.Presentation.Mapper
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Event, EventRM>();
            CreateMap<Group, GroupRM>();
            CreateMap<Group, GroupListRM>();
            CreateMap<GroupRM, Group>();
            CreateMap<Appointment, AppointmentRM>();
            CreateMap<AppointmentRM, Appointment>();
            CreateMap<Contact, ContactRM>();
            CreateMap<ContactRM, Contact>();

            CreateMap<Box, BoxRM>();
            CreateMap<BoxRM, Box>();

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
