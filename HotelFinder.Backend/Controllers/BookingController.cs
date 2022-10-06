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
    public class BookingController : ControllerBase
    {
        #region Properties
        private readonly IRepository<Booking> _bookingRepo;
        #endregion

        #region CTOR
        public BookingController(IRepository<Booking> bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }
        #endregion

        #region Public methods 

        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> Get(int id)
        {
            var booking = await _bookingRepo.Get(id);

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> Post(AddBookingInput input)
        {
            var bookingId = 0; 
            try
            {
                bookingId = await _bookingRepo.Insert(new Booking() { HotelId = input.HotelId, Nights = input.Nights, CheckInDate = input.CheckInDate, CheckOutDate = input.CheckOutDate, UserId = input.UserId, TotalPrice = input.TotalPrice});
            }
            catch (DbUpdateException)
            {
                if (await _bookingRepo.Exists(bookingId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Get", new { id = bookingId }, bookingId);
        }

        #endregion




    }
}