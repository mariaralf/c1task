using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WM2_C1
{
    public partial class Hotel
    {
        public Hotel()
        {
            Bookings = new HashSet<Booking>();
        }

        [Display(Name = "ID")]
        public int HotelId { get; set; }

        [Display(Name = "Назва")]
        public string? HotelName { get; set; }

        [Display(Name = "Посилання на фото")]
        public string? HotelImage { get; set; }

        [Display(Name = "Опис")]
        public string? HotelDesc { get; set; }

        [Display(Name = "Ціна за ніч")]
        public int? HotelNightPrice { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
