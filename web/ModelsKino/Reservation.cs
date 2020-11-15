using System;
using System.Collections.Generic;

namespace web.ModelsKino
{
    public class Reservation
    {
        public Showing ShowingID {get; set;}
        public int Seats { get; set; }
        public double Price { get; set; }
    }
}
