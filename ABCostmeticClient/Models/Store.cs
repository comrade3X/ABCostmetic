using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABCostmeticClient.Models
{
    public class Store
    {
        public int Id { get; set; }
        public int Nationality { get; set; }
        public string Address { get; set; }

        public virtual National Nationality1 { get; set; }
    }
}