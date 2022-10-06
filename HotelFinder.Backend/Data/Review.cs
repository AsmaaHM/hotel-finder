using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.Backend
{
    public class Review : BaseEntity
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public Hotel Hotel { get; set; }
        public User User { get; set; }

    }
}
