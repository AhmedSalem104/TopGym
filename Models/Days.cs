using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TopGym_System.Models
{
    public class Days
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int DayNumber { get; set; }
    }
}