using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.Backend
{
    public class SearchHotelsInput
    {
        public string Name { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal MaxPrice  { get; set; }
    }
}
