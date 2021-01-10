using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace web.Models
{
    public class SeatShowing
    {
        public int SeatShowingID { get; set; }
        [Required]
        public int SeatNumber { get; set; }

        [Required]
        public int ShowingID { get; set; }


    }
}
