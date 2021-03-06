﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDelivery.DAL.Models
{
    public class VehicleTypeEntity : BaseEntity
    {
        public virtual decimal MaxCarrying { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<VehicleEntity> Vehicles { get; set; }
    }
}
