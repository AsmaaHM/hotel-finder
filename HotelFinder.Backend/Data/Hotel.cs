using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.Backend
{
    public class Hotel : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public float Rate { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Facility> Facilities { get; set; }
        public List<Picture> Pictures { get; set; }
        public List<Rate> Rates { get; set; }

    }
}
