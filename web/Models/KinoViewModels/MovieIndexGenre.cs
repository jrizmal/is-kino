using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models.KinoViewModels
{
    public class MovieIndexGenre
    {
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<GenreMovie> GenreMovies { get; set; }
    }
}
