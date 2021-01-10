using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class GenreMovie
    {
        public int GenreMovieID { get; set; }
        [Required]
        public int MovieID { get; set; }
        [Required]
        public int GenreID {get; set;}

        public Movie Movie { get; set; }
        public Genre Genre { get; set; }
    }
}
