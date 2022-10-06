using HotelFinder.Backend;
using HotelFinder.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HotelFinder.Backend.Tests
{
    public class BookingControllerTests
    {

     
        [Fact]
        public async Task AddsBooking()
        {
            // Arrange
            var booking = GetBooking();
            var mockRepo = new Mock<IRepository<Booking>>();
            mockRepo.Setup(repo => repo.Insert(It.IsAny<Booking>()))
                .ReturnsAsync(GetBooking());
          
            var controller = new BookingController(mockRepo.Object);
        
            // Act
            var result = await controller.Post(new AddBookingInput() 
            { UserId = booking.UserId, HotelId = booking.HotelId, TotalPrice = booking.TotalPrice, 
                CheckInDate = booking.CheckInDate, CheckOutDate = booking.CheckOutDate, Nights = booking.Nights });

            // Assert
            var viewResult = Assert.IsType<ActionResult<Booking>> (result);
            var createdAtActionResult = Assert.IsAssignableFrom<CreatedAtActionResult>(
               viewResult.Result);
            var model = Assert.IsAssignableFrom<Booking>(
                createdAtActionResult.Value);
            Assert.NotNull(model);
            Assert.NotEqual(0, model.Id);
        }


        #region Helper methods
        private Booking GetBooking()
        {
            return new Booking() { 
            TotalPrice = 4000, 
            Nights = 5, 
            CheckInDate = System.DateTime.Now, 
            CheckOutDate = System.DateTime.Now, 
            HotelId = 3, 
            UserId = 1, 
            Id = 1
            };
        }
        #endregion 
    }
}
