using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABCostmeticClient.Models
{
    public class Filter
    {
        public  string Daily { get; set; }

        public string Monthly { get; set; }

        public  DateTime From { get; set; }

        public DateTime To { get; set; }
    }
}