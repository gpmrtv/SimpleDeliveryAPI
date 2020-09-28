using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDelivery.DAL.Models
{
    public class StateEntity : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual IList<OrderEntity> Orders { get; set; }
    }
}
