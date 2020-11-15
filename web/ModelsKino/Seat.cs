using System;
using System.Collections.Generic;

namespace web.ModelsKino
{
    public class Seat
    {
        public int SeatID {get; set;}
        public Room RoomID { get; set; }
        public int Row { get; set; }
        public int Number { get; set; }
    }
}
