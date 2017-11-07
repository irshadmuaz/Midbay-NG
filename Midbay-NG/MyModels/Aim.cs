using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Midbay_NG.MyModels
{
    public class Aim
    {
        [Key]
        public int Id { get; set; }
        public string title { get; set; }
        [DataType(DataType.MultilineText)]
        public string details { get; set; }
    }
}