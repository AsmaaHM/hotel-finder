using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.Backend
{
    public class AddBookingInput
    {
        public int Nights { get; set; }
        public decimal TotalPrice { get; set; }
        public int UserId { get; set; }
        public int HotelId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

    }
}
