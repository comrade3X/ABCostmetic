using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABCostmeticClient.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public int StaffId { get; set; }
        public string Username { get; set; }
    }
}