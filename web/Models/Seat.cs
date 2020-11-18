using System;
using System.Collections.Generic;

namespace web.Models
{
    public class Seat
    {
        public int SeatId {get; set;}
        public Room Room { get; set; }
        public int Row { get; set; }
        public int Number { get; set; }
    }
}
