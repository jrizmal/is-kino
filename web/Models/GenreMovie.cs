using System;
using System.Collections.Generic;

namespace web.Models
{
    public class GenreMovie
    {
        public int GenreMovieID { get; set; }
        public int MovieId { get; set; }
        public int GenreID {get; set;}

        public Movie Movie { get; set; }
        public Genre Genre { get; set; }
    }
}
