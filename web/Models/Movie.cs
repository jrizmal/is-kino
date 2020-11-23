using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        public string Rating { get; set; }
        [Required]
        public string Length { get; set; }
        [Required]
        [Display(Name = "In theaters from")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "until")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public ICollection<GenreMovie> GenreMovies { get; set; }
        public ICollection<Actors> Actors { get; set; }
        public ICollection<Directors> Directors { get; set; }
    }
}
