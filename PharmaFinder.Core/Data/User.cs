using System;
using System.Collections.Generic;

namespace PharmaFinder.Core.Data
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
            Usertestimonials = new HashSet<Usertestimonial>();
        }

        public decimal Userid { get; set; }
        public decimal? Roleid { get; set; }
        public string? Profileimage { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public DateTime? Registrationdate { get; set; }
        public string? Gender { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public string? Address { get; set; }
        public string? Phonenumber { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Usertestimonial> Usertestimonials { get; set; }
    }
}
