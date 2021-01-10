using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Showing
    {
        public int ShowingID {get; set;}
        [Required]
        [Display(Name = "Title")]
        public int MovieID { get; set; }
        [Required]
        [Display(Name = "Room")]
        public int RoomID { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy - H:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start time")]
        public DateTime StartTime { get; set; }

        public Movie Movie { get; set; }
        public Room Room { get; set; }
    }
}
