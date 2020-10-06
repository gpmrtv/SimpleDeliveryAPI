using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDelivery.BLL.Dtos
{
    public class VehicleDTO
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public PerformerDTO Driver { get; set; }
        public VehicleTypeDTO VehicleType { get; set; }
    }
}
