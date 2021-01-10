using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        [Required]
        public int ShowingID { get; set; } 
        [Required]
        [Display(Name = "Number of seats")]
        public int Seats { get; set; }
        public double Price { get; set; }
        public Showing Showing {get; set;}
    }
}
