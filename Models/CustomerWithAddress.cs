﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class CustomerWithAddress
    {
        public Customer Customer { get; set; }
        public Address Address { get; set; }
    }
}
