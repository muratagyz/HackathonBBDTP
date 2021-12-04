using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBDTP.Models
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public string CategoryName { get; set; }
        public string CityName { get; set; }
        public string FarmName { get; set; }
        public string RegionName { get; set; }

    }
}