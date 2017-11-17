using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABCostmeticClient.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string IdentityCard { get; set; }
        public string Gender { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}