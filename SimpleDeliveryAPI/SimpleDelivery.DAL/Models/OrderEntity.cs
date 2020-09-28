using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDelivery.DAL.Models
{
    public class OrderEntity : BaseEntity
    {
        public virtual string Description { get; set; }
        public virtual decimal Cost { get; set; }
        public virtual DateTime? ExecutionDate { get; set; }
        public virtual StateEntity State { get; set; }
        public virtual RouteEntity Route { get; set; }
        public virtual CustomerEntity Customer { get; set; }    
        public virtual PerformerEntity Performer { get; set; }
    }
}
