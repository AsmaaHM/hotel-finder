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
    public class HotelControllerTests
    {

        [Fact]
        public async Task GetsHotelLisitng()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Hotel>>();
            mockRepo.Setup(repo => repo.GetAll())
                .ReturnsAsync(GetTestHotels());
            var controller = new HotelController(mockRepo.Object);

            // Act
            var result = await controller.Get();

            // Assert
            var viewResult = Assert.IsType<ActionResult<IEnumerable<Hotel>>>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Hotel>>(
                viewResult.Value);
            Assert.Equal(3, model.Count());
        }
        [Fact]
        public async Task GetsHotelDetails()
        {
            // Arrange
            var hotelId = 1; 
            var mockRepo = new Mock<IRepository<Hotel>>();
            mockRepo.Setup(repo => repo.Filter(hotel=> hotel.Id == hotelId, hotel => hotel.Pictures, hotel => hotel.Reviews))
                .ReturnsAsync(GetHotel(hotelId));
            var controller = new HotelController(mockRepo.Object);

            // Act
            var result = await controller.Get(hotelId);

            // Assert
            var viewResult = Assert.IsType<ActionResult<Hotel>>(result);
            var model = Assert.IsAssignableFrom<Hotel>(
                viewResult.Value);
            Assert.Equal(hotelId, model.Id);
        }
        [Fact]
        public async Task SearchesHotelsByNameAndMaxPrice()
        {
            // Arrange
            var searchInput = new SearchHotelsInput()
            { Name = "Dummy", MaxPrice = 1000, CheckInDate = System.DateTime.Now, CheckOutDate = System.DateTime.Now };
            var mockRepo = new Mock<IRepository<Hotel>>();
            mockRepo.Setup(repo => repo.Filter(hotel => hotel.Name.Contains(searchInput.Name) && hotel.Price <= searchInput.MaxPrice, null))
                .ReturnsAsync(GetFilteredHotels());
            var controller = new HotelController(mockRepo.Object);

            // Act
            var result = await controller.Search(searchInput);

            // Assert
            var viewResult = Assert.IsType<ActionResult<IEnumerable<Hotel>>>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Hotel>>(
                viewResult.Value);
            Assert.Equal(2, model.Count());
        }

        #region Helper methods
        private List<Hotel> GetTestHotels()
        {
            var sessions = new List<Hotel>();
            var hotel1 = new Hotel { Id = 1, Name = "Dummy Hotel 1", Description = "Lorem ipsum 1", Address = "Address 1", Price = 1000, Rate = 5 };
            var hotel2 = new Hotel { Id = 2, Name = "Dummy Hotel 2", Description = "Lorem ipsum 2", Address = "Address 2", Price = 200, Rate = 3 };
            var hotel3 = new Hotel { Id = 3, Name = "Dummy Hotel 3", Description = "Lorem ipsum 3", Address = "Address 3", Price = 2400, Rate = 4 };

            sessions.Add(hotel1);
            sessions.Add(hotel2);
            sessions.Add(hotel3);
       
            return sessions;
        }
        private List<Hotel> GetFilteredHotels()
        {
            var sessions = new List<Hotel>();
            var hotel1 = new Hotel { Id = 1, Name = "Dummy Hotel 1", Description = "Lorem ipsum 1", Address = "Address 1", Price = 1000, Rate = 5 };
            var hotel2 = new Hotel { Id = 2, Name = "Dummy Hotel 2", Description = "Lorem ipsum 2", Address = "Address 2", Price = 200, Rate = 3 };

            sessions.Add(hotel1);
            sessions.Add(hotel2);
            return sessions;
        }
        private List<Hotel> GetHotel(int id)
        {
            return new List<Hotel>() {
                new Hotel() { Id = id,
                    Name = "Dummy Hotel 1",
                    Description = "Lorem ipsum 1",
                    Address = "Address 1",
                    Price = 1000, Rate = 5 }
                };
        }
        #endregion 
    }
}
