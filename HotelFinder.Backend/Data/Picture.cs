using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.Backend
{
    public class Picture : BaseEntity
    {
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public Hotel Hotel { get; set; }
    }
}
