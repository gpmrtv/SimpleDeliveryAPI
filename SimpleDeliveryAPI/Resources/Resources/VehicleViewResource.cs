using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleDeliveryWebCore.Resources
{
    public class VehicleViewResource
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public PerformerViewResource Driver { get; set; }
        public VehicleTypeViewResource VehicleType { get; set; }
    }
}
