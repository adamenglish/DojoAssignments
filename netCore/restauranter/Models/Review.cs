using System.ComponentModel.DataAnnotations;
using System;

namespace restauranter.Models 
{
    public class Review
    {
        public int ReviewID {get; set;}

        [Required]
        [MinLength(2)]
        public string Reviewer {get; set;}
        
        [Required]
        public string Restaurant {get; set;}

        [Required]
        [MinLength(10)]
        public string Reviews {get; set;}

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Stars { get; set; }

        public DateTime created_at {get; set;}
    }


}