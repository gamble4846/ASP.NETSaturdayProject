using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NETSaturdayProject.Models
{
    public class Food
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string cuisine { get; set; }
        [Required]
        public decimal price { get; set; }
        [Required]
        public int Quantity { get; set; } 
    }
}