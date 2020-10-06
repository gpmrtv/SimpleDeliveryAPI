using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDelivery.BLL.Dtos
{
    public class VehicleTypeDTO
    {
        public Guid Id { get; set; }
        public decimal MaxCarrying { get; set; }
        public string Name { get; set; }
    }
}
