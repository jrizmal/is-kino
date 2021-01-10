using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Directors
    {
        public int DirectorsID { get; set; }
        [Required]
        public int MovieID { get; set; }
        [Required]
        public int PeopleID {get; set;}

        public Movie Movie { get; set; }
        public People People { get; set; }
    }
}
