using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TopGym_System.Models
{
    public class GenderType
    {
        public int Id { get; set; }
        [Required]
        public string GenderName { get; set; }

        public virtual ICollection<Members> Members { get; set; }

    }
}