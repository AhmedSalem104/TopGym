using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TopGym_System.Models
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SubscriptionName { get; set; }
        public decimal PricePerGym { get; set; }
        public decimal PricePerGymAndCardio { get; set; }



        public virtual ICollection<Members> Members { get; set; }    
    }
}