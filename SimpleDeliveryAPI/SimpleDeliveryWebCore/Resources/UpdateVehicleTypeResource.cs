﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleDeliveryWebCore.Resources
{
    public class UpdateVehicleTypeResource
    {
        public Guid Id { get; set; }
        public decimal MaxCarrying { get; set; }
        public string Name { get; set; }
    }
}
