using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BBDTP.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }

        public int FarmId { get; set; }
        public virtual Farm Farm { get; set; }
    }
}