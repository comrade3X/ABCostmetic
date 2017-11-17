using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABCostmeticClient.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderCode { get; set; }
        public int Seller { get; set; }
        public int Customer { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Customer Customer1 { get; set; }
        public virtual Employee Employee { get; set; }
    }
}