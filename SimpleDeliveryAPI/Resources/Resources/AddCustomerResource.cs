﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleDeliveryWebCore.Resources
{
    public class AddCustomerResource
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}