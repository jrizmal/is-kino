using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class People
    {
        public int PeopleID {get; set;}
        [Required]
        public String Name { get; set; }
    }
}
