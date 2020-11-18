using System;
using System.Collections.Generic;

namespace web.ModelsKino
{
    public class Showing
    {
        public int ShowingId {get; set;}
        public Movie Movie { get; set; }
        public Room Room { get; set; }
        public string Name { get; set; }
        public string Rating { get; set; }
        public string Length { get; set; }
        public DateTime StartTime { get; set; }
    }
}
