using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.Backend
{
    public class Booking : BaseEntity
    {
        public int Nights { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalPrice { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public User User { get; set; }
    }
}
