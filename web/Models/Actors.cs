using System;
using System.Collections.Generic;

namespace web.Models
{
    public class Actors
    {
        public int ActorsID { get; set; }
        public int MovieId { get; set; }
        public int PeopleID {get; set;}

        public Movie Movie { get; set; }
        public People People { get; set; }
    }
}
