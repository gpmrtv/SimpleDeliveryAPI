using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleDeliveryWebCore.Resources
{
    public class UpdateVehicleResource
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
    }
}
