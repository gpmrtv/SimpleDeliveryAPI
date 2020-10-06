using AutoMapper;
using SimpleDelivery.BLL.Dtos;
using SimpleDelivery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDelivery.BLL.MapperProfiles
{
    public class BusinessMapperProfile : Profile
    {
        public BusinessMapperProfile()
        {
            #region domain to business

            CreateMap<CustomerEntity, CustomerDTO>();
            CreateMap<VehicleTypeEntity, VehicleTypeDTO>();
            CreateMap<StateEntity, StateDTO>();
            CreateMap<PerformerEntity, PerformerDTO>();
            CreateMap<VehicleEntity, VehicleDTO>();

            #endregion

            #region business to domain

            CreateMap<CustomerDTO, CustomerEntity>();
            CreateMap<VehicleTypeDTO, VehicleTypeEntity>();
            CreateMap<StateDTO, StateEntity>();
            CreateMap<PerformerDTO, PerformerEntity>();
            CreateMap<VehicleDTO, VehicleEntity>();

            #endregion
        }
    }
}
