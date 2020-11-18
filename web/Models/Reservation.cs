using System;
using System.Collections.Generic;

namespace web.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public Showing Showing {get; set;}
        public int Seats { get; set; }
        public double Price { get; set; }
    }
}
