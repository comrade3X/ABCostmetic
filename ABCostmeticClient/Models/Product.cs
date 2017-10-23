using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABCostmeticClient.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Descriptions { get; set; }
        //public virtual CategoryDto Category { get; set; }
        //public virtual ICollection<OrderDetailDto> OrderDetails { get; set; }
    }
}