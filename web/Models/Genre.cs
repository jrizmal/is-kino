using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Genre
    {
        public int GenreID {get; set;}
        [Required]
        [Display(Name = "Genre")]
        public String GenreName { get; set; }

        public ICollection<GenreMovie> GenreMovies { get; set; }
    }
}
