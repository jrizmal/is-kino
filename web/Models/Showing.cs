using System;
using System.Collections.Generic;

namespace web.Models
{
    public class Showing
    {
        public int ShowingId {get; set;}
        public int MovieID { get; set; }
        public int RoomID { get; set; }
        public DateTime StartTime { get; set; }

        public Movie Movie { get; set; }
        public Room Room { get; set; }
    }
}
