using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace web.Models
{
    public class Seat
    {
        public int SeatID {get; set;}
        [Required]
        public Room Room { get; set; }
        [Required]
        public int Row { get; set; }
        [Required]
        public int Number { get; set; }
    }
}
