using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WM2_C1
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
        }

        [Display(Name ="ID")]
        public int UserId { get; set; }

        [Display(Name = "Ім'я")]
        public string? UserName { get; set; }

        [Display(Name = "Прізвище")]
        public string? UserSurname { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress]
        public string? UserEmail { get; set; }

        [Display(Name = "Телефон")]
        [Phone]
        public string? UserPhone { get; set; }

        
        public int? UserRole { get; set; }

        [Display(Name = "Роль")]
        public virtual Role? UserRoleNavigation { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
