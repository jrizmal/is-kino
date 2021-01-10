using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class SeatShowing
    {
        public int SeatShowingID { get; set; }
        [Required]
        public int SeatNumber { get; set; }
        [Required]
        public Showing Showing { get; set; }
        
    }
}
