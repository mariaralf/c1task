using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace WM2_C1
{
    public partial class Booking
    {
        [Display(Name = "ID")]
        public int BookingId { get; set; }

       
        public int? BookingUserId { get; set; }

       
        public int? BookingHotelId { get; set; }

        [Display(Name = "Дата")]
        public DateTime? BookingDate { get; set; }


        [Display(Name = "Готель")]
        public virtual Hotel? BookingHotel { get; set; }

        [Display(Name = "Юзер")]
        public virtual User? BookingUser { get; set; }
    }
}
