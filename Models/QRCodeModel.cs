using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TopGym_System.Models
{
    public class QRCodeModel
    {
        [Key]
        public int QrId { get; set; }
        public string QRCodeText { get; set; }
    }
}