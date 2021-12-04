using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BBDTP.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }

        public int RegionId { get; set; }
        public virtual Region Region { get; set; }
    }
}