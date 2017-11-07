using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Midbay_NG.MyModels
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200,ErrorMessage ="Maximum length exceeded")]
        public string Name { get; set; }
        [MaxLength(500, ErrorMessage = "Maximum length exceeded")]
        [DataType(DataType.MultilineText)]
   
        public string Description { get; set; }
        [MaxLength(200, ErrorMessage = "Maximum length exceeded")]
        public string Client { get; set; }
        [MaxLength(200, ErrorMessage = "Maximum length exceeded")]
        public string Location { get; set; }
        public string Images { get; set; }
        [Required]
        public string category { get; set; }

        
        public DateTime Date { get; set; }
        public bool featured { get; set; }
    }
}