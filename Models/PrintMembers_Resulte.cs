using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopGym_System.Models
{
    public class PrintMembers_Resulte
    {


        public int Id { get; set; }    
        public string MemberName { get; set; }
        public string Height { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDelete { get; set; }
        public string MemberWeight { get; set; }
        public decimal SubscriptionPrice { get; set; }
        public decimal SubscriptionPriceDiscount { get; set; }
        public decimal Paid { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }    
        public string Notes { get; set; }   
        public int CategoryId { get; set; }
        public int SubscriptionId { get; set; }
        public int GenderTypeId { get; set; }
        public string CategoryName { get; set; }
        public string GenderName { get; set; }
        public string SubscriptionName { get; set; }
        public decimal PricePerGym { get; set; }
        public decimal PricePerGymAndCardio { get; set; }




    }
}