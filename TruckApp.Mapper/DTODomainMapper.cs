using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TruckApp.Domain.Entities;
using TruckApp.Infra.DTO.Truck;

namespace TruckApp.Mapper
{
    public class DTODomainMapper : Profile
    {
        public DTODomainMapper()
        {
            CreateMap<TruckDTO, Truck>()
                .ForPath(x => x.Model.Name, opt => opt.MapFrom(x => x.Name));

            CreateMap<SaveTruckDTO, Truck>();
        }
    }
}
