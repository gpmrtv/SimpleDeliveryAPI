using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDelivery.DAL.Models
{
    public class PerformerEntity : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Email { get; set; }
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }
        public virtual bool IsVerified { get; set; }
        public virtual IList<VehicleEntity> Vehicle { get; set; }
        public virtual IList<OrderEntity> Orders { get; set; }
    }
}
