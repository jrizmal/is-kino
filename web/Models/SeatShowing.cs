using System;
using System.Collections.Generic;

namespace web.Models
{
    public class SeatShowing
    {
        public int SeatShowingId { get; set; }
        public int SeatID { get; set; } 
        public int ShowingID { get; set; }
        public bool taken { get; set; }
        public Seat Seat {get; set;}
        public Showing Showing { get; set; }
        
    }
}
