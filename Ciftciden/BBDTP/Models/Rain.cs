using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BBDTP.Models
{
    public class Rain
    {
        [Key]
        public int RainId { get; set; }
        public string RainYear { get; set; }
        public int RainQuantity { get; set; }

        public int RegionId { get; set; }
        public virtual Region Region { get; set; }
    }
}