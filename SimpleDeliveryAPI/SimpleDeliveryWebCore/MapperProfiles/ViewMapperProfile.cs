using AutoMapper;
using SimpleDelivery.BLL.Dtos;
using SimpleDeliveryWebCore.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleDeliveryWebCore.MapperProfiles
{
    public class ViewMapperProfile : Profile
    {
        public ViewMapperProfile()
        {
            #region cutomers mapping

            CreateMap<AddCustomerResource, CustomerDTO>().ReverseMap();
            CreateMap<CustomerViewResource, CustomerDTO>().ReverseMap();
            CreateMap<UpdateCustomerResource, CustomerDTO>().ReverseMap();

            #endregion

            #region vehicle types mapping

            CreateMap<AddVehicleTypeResource, VehicleTypeDTO>().ReverseMap();
            CreateMap<VehicleTypeViewResource, VehicleTypeDTO>().ReverseMap();
            CreateMap<UpdateVehicleTypeResource, VehicleTypeDTO>().ReverseMap();

            #endregion

            #region vehicles mapping

            CreateMap<AddVehicleResource, VehicleDTO>().ReverseMap();
            CreateMap<VehicleViewResource, VehicleDTO>().ReverseMap();
            CreateMap<UpdateVehicleResource, VehicleDTO>().ReverseMap();

            #endregion

            #region performers mapping

            CreateMap<AddPerformerResource, PerformerDTO>().ReverseMap();
            CreateMap<PerformerViewResource, PerformerDTO>().ReverseMap();
            CreateMap<UpdatePerformerResource, PerformerDTO>().ReverseMap();

            #endregion

            #region states mapping

            CreateMap<AddStateResource, StateDTO>().ReverseMap();
            CreateMap<StateViewResource, StateDTO>().ReverseMap();
            CreateMap<UpdateStateResource, StateDTO>().ReverseMap();

            #endregion
        }
    }
}
