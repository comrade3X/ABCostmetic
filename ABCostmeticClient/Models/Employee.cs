using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABCostmeticClient.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int StaffTypeId { get; set; }
        public int StoreId { get; set; }
        public string FullName { get; set; }
        public string IdentityCard { get; set; }
        public int Nationality { get; set; }
        public string Address { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual National Nationality1 { get; set; }
        public virtual StaffType StaffType { get; set; }

        public virtual Store Store { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}