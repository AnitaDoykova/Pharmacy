﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Models.Responses
{
    public class ClientResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double MoneySpend { get; set; }
    }
}
