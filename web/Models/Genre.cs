using System;
using System.Collections.Generic;

namespace web.Models
{
    public class Genre
    {
        public int GenreID {get; set;}
        public String GenreName { get; set; }
        public ICollection<GenreMovie> Movies { get; set; }
    }
}
