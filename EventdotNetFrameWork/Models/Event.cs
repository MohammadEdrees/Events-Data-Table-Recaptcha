using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventdotNetFrameWork.Models
{
    public class Event
    {
        [Key,Required]
        
        public int EventId { get; set; }
        [Required,MaxLength(40)]

        public string Title { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime StartDate { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime EndDate { get; set; }
        [Required]

        public string Country { get; set; }
        [Required]

        public string City { get; set; }
        [Required(ErrorMessage = "Please choose Image to upload."), MaxLength(256)]
        [Display(Name = "Select Image")]
        public string Img { get; set; }
        [MaxLength(256)]
        public string Description { get; set; }
    }
}