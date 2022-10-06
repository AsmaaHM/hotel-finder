using HotelFinder.Backend;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        #region Properties
        private readonly IRepository<Hotel> _hotelRepo;
        #endregion

        #region CTOR
        public HotelController(IRepository<Hotel> hotelRepo)
        {
            _hotelRepo = hotelRepo;
        }
        #endregion

        #region Public methods 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> Get()
        {
            var hotels = await _hotelRepo.GetAll();
            return hotels.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> Get(int id)
        {
            var hotels = await _hotelRepo.Filter(hotel => hotel.Id == id, hotel => hotel.Pictures, hotel => hotel.Reviews);

            if (hotels == null || hotels.Count() == 0)
            {
                return NotFound();
            }

            return hotels.FirstOrDefault();
        }

        [Route("/Search")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Hotel>>> Search(SearchHotelsInput input)
        {
            var hotels = await SearchHotels(input);
            return hotels.ToList(); 
        }
        #endregion


        #region Helper methods 
        private async Task<IEnumerable<Hotel>> SearchHotels(SearchHotelsInput input)
        {
            return await _hotelRepo.Filter(
                hotel => hotel.Name.Contains(input.Name) && hotel.Price <= input.MaxPrice,
                null 
                );
        }
        #endregion 

    }
}