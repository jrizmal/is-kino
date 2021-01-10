using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        [Required]
        [Display(Name = "Room")]
        public string Name { get; set; }
    }
}
