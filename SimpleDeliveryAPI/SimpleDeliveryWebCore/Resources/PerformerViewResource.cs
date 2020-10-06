using System;
using System.Collections.Generic;

namespace SimpleDeliveryWebCore.Resources
{
    public class PerformerViewResource
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsVerified { get; set; }
        public List<VehicleViewResource> Vehicles { get; set; }
    }
}