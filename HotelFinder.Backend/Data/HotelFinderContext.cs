using Microsoft.EntityFrameworkCore;

namespace HotelFinder.Backend.Data
{
    public class HotelFinderContext : DbContext
    {
        public HotelFinderContext(DbContextOptions<HotelFinderContext> options)
            : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed(); 
            base.OnModelCreating(modelBuilder);
        }

    }

    public static class ContextExtensions {
     public static void Seed(this ModelBuilder modelBuilder)
    {
            modelBuilder.Entity<Facility>().HasData(
                new Facility { Id = 1, Title = "Wifi", ImageURL = "WifiURL" },
                new Facility { Id = 2, Title = "Spa", ImageURL = "SpaURL" },
                new Facility { Id = 3, Title = "Parking", ImageURL = "ParkingURL" },
                new Facility { Id = 4, Title = "Breakfast", ImageURL = "BreakfastURL" }
            );

            var hotel1 = new Hotel { Id= 1, Name = "Dummy Hotel 1", Description = "Lorem ipsum 1", Address = "Address 1", Price = 1000, Rate = 5 };
        var hotel2 = new Hotel { Id= 2, Name = "Dummy Hotel 2", Description = "Lorem ipsum 2", Address = "Address 2", Price = 200, Rate = 3 };
        var hotel3 = new Hotel { Id = 3, Name = "Dummy Hotel 3", Description = "Lorem ipsum 3", Address = "Address 3", Price = 2400, Rate = 4 };

        var user1 = new User { Id= 1, Username = "Dummy user 1", Password = "Pass1", Email = "mail@mail1.com" };
        var user2 = new User { Id= 2, Username = "Dummy user 2", Password = "Pass2", Email = "mail@mail2.com" };
        var user3 = new User { Id = 3, Username = "Dummy user 3", Password = "Pass3", Email = "mail@mail3.com" };

        modelBuilder.Entity<Hotel>().HasData(
            hotel1,
            hotel2,
            hotel3
        );
            modelBuilder.Entity<User>().HasData(
          user1,
          user2,
          user3
      );

            modelBuilder.Entity<Picture>().HasData(
            new Picture { Id = 1, Title = "Hotel1Pict1", URL = "PictUrl", HotelId = hotel1.Id },
            new Picture { Id= 2, Title = "Hotel1Pict2", URL = "PictUrl", HotelId = hotel1.Id },
            new Picture { Id= 3, Title = "Hotel2Pict1", URL = "PictUrl", HotelId = hotel2.Id },
            new Picture { Id = 4, Title = "Hotel2Pict2", URL = "PictUrl", HotelId = hotel2.Id },
            new Picture { Id = 5, Title = "Hotel3Pict1", URL = "PictUrl", HotelId = hotel3.Id },
            new Picture { Id = 6, Title = "Hotel3Pict2", URL = "PictUrl", HotelId = hotel3.Id }
        );


            modelBuilder.Entity<Rate>().HasData(
                new Rate { Id = 1, SelectedRate = 5, HotelId = hotel1.Id, UserId = user1.Id },
                new Rate { Id = 2, SelectedRate = 4, HotelId = hotel2.Id, UserId = user2.Id },
                new Rate { Id = 3, SelectedRate = 3, HotelId = hotel3.Id, UserId = user3.Id }
            );

            modelBuilder.Entity<Review>().HasData(
            new Review { Id= 1,  Title = "Fantastic!", Text = "Great service.", HotelId = hotel1.Id, UserId = user1.Id },
            new Review { Id= 2, Title = "Horrible!", Text = "Low cleanliness standards.", HotelId = hotel2.Id, UserId = user3.Id },
            new Review { Id = 3, Title = "Okay", Text = "Nothing to add", HotelId = hotel3.Id, UserId = user2.Id }
        );
    }
}
}

