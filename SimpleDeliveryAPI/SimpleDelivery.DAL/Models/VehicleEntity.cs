using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDelivery.DAL.Models
{
    public class VehicleEntity : BaseEntity
    {
        public virtual string Number { get; set; }
        public virtual string Brand { get; set; }
        public virtual string Model { get; set; }
        public virtual string Color { get; set; }
        public virtual Guid VehicleTypeId { get; set; }
        public virtual Guid? DriverId { get; set; }
        public virtual PerformerEntity Driver { get; set; }
        public virtual VehicleTypeEntity VehicleType { get; set; }
    }
}
