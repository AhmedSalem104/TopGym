using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Windows.Input;

namespace TopGym_System.Models
{
    public class Members
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string MemberName { get; set; }
        [Required]

        public string Height { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsDelete { get; set; }

   
        

        [Required]


        public string MemberWeight { get; set; }

        public string QrCodemember { get; set; }
        public decimal SubscriptionPrice { get; set; }
        public decimal SubscriptionPriceDiscount { get; set; }
        public decimal Paid { get; set; }



        [Required]
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }

        [Required]
        public string Notes { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual  Category Category { get; set; }


        [ForeignKey("Subscription")]
        public int SubscriptionId { get; set; }

        public virtual Subscription Subscription { get; set; }

      
        public int GenderTypeId { get; set; }

        public virtual GenderType GenderType { get; set; }
    }
}