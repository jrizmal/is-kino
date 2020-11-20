using System;
using System.Collections.Generic;

namespace web.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Rating { get; set; }
        public string Length { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<GenreMovie> Genres { get; set; }
        public ICollection<Actors> Actors { get; set; }
        public ICollection<Directors> Directors { get; set; }
    }
}
