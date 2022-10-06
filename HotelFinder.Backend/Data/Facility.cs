using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.Backend
{
    public class Facility : BaseEntity
    {
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public List<Hotel> Hotels { get; set; }
    }
}
