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
            CreateMap<AddCustomerResource, CustomerDTO>();
            CreateMap<CustomerDTO, AddCustomerResource>();
            CreateMap<CustomerViewResource, CustomerDTO>();
            CreateMap<CustomerDTO, CustomerViewResource>();
        }
    }
}
