using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BBDTP.Models
{
    public class Farm
    {
        [Key]
        public int FarmdId { get; set; }
        public string FarmdName { get; set; }
        public string FarmPassword { get; set; }
    }
}