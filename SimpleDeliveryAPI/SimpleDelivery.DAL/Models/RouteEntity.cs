using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDelivery.DAL.Models
{
    public class RouteEntity : BaseEntity
    {
        public virtual string StartPoint { get; set; }
        public virtual string FinishPoint { get; set; }
        public virtual RouteEntity ParentRoute { get; set; }
        public virtual OrderEntity Order { get; set; }
    }
}
