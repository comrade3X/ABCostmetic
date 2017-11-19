using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }

    public class OrderViewModel
    {
        public int Id { get; set; }
        public string OrderCode { get; set; }
        public int Seller { get; set; }
        public int Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual Customer Customer1 { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual SelectList ProductSelectList { get; set; }

        [Display(Name = "Product Id")]
        public virtual int ProductId { get; set; }

        [Display(Name = "Seller Name")]
        public virtual string SellerName { get; set; }

        public int Quanlity { get; set; }
    }
}