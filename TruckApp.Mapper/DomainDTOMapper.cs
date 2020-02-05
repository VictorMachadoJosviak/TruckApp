using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TruckApp.Domain.Entities;
using TruckApp.Infra.DTO.Model;
using TruckApp.Infra.DTO.Truck;

namespace TruckApp.Mapper
{
    public class DomainDTOMapper : Profile
    {
        public DomainDTOMapper()
        {
            CreateMap<Truck, TruckDTO>()
                .ForMember(x => x.Model, opt => opt.MapFrom(x => x.Model.Name));

            CreateMap<Model, ModelDTO>();

            CreateMap<Truck, SaveTruckDTO>();
        }
    }
}
