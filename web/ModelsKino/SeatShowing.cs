using System;
using System.Collections.Generic;

namespace web.ModelsKino
{
    public class SeatShowing
    {
        public Seat SeatID {get; set;}
        public Showing ShowingID { get; set; }
        public bool taken { get; set; }
    }
}
