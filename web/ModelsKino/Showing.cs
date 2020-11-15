using System;
using System.Collections.Generic;

namespace web.ModelsKino
{
    public class Showing
    {
        public int ShowingID {get; set;}
        public Movie MovieID { get; set; }
        public Room RoomID { get; set; }
        public string Name { get; set; }
        public string Rating { get; set; }
        public string Length { get; set; }
        public DateTime StartTime { get; set; }
    }
}
