using System;
using System.Collections.Generic;

namespace web.ModelsKino
{
    public class SeatShowing
    {
        public int SeatShowingId { get; set; }
        public Seat Seat {get; set;}
        public Showing Showing { get; set; }
        public bool taken { get; set; }
    }
}
