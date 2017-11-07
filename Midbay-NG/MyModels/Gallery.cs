using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Midbay_NG.MyModels
{
    public class Gallery
    {
        [Key]
        public int Id { get; set; }
        public string image { get; set; }
        public string filename { get; set; }
        public string name { get; set; }
       
        public DateTime date { get; set; }
    }
}