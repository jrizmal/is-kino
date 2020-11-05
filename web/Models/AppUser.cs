using System;
using Microsoft.AspNetCore.Identity;

namespace web.Models
{
    public class AppUser : IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string city { get; set; }

    }
}