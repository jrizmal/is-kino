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

        public IEnumerable<People> Actors { get; set; }
        public IEnumerable<People> Directors { get; set; }
        public IEnumerable<Actors> ActorConnect { get; set; }
        public IEnumerable<Directors> DirectorConnect { get; set; }
    }
}
