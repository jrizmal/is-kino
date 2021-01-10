using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class SeatShowing
    {
        public int SeatShowingID { get; set; }
        [Required]
        public int SeatID { get; set; } 
        public int? ShowingID { get; set; }
        [Required]
        public bool Taken { get; set; }
        
        public Seat Seat {get; set;}
        public Showing Showing { get; set; }
        
    }
}
