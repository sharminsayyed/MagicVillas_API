using MagicVillaAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace MagicVillaAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {}
        public DbSet<Villa> Villas { get; set; } // table name in the database

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Name = "Azure Haven Villa",
                    Details="A luxurious villa with stunning ocean views, private pool, and modern amenities.",
                    ImageUrl= "https://unsplash.com/photos/white-and-grey-concrete-building-near-swimming-pool-under-clear-sky-during-daytime-2d4lAQAlbDA",
                    Occupancy=8,
                    Rate =5000,
                    Amenity="Pool, Wi-Fi, Air Conditioning",
                    CreatedDate= DateTime.Now
                },
                new Villa()
                {
                    Id = 2,
                    Name = "Sunset Shores Villa",
                    Details = "A luxurious villa with stunning sunset views, private pool, and modern amenities.",
                    ImageUrl = "https://unsplash.com/photos/white-and-brown-concrete-building-near-swimming-pool-during-daytime-GSL3IuuwJv8",
                    Occupancy = 12,
                    Rate = 50000,
                    Amenity = "Laundry machine, dryer,Smart TV or entertainment system",
                    CreatedDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 3 ,
                    Name = " Mountain Mist Villa",
                    Details = "A luxurious villa with stunning mountain views, private pool, and modern amenities.",
                    ImageUrl = "https://images.unsplash.com/photo-1568605114967-8130f3a36994?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Occupancy = 13,
                    Rate = 67800,
                    Amenity = "Wi-Fi/internet access,Gym or fitness area",
                    CreatedDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 4,
                    Name = " Regal Ridge Villa",
                    Details = "A luxurious villa with stunning sunset views, private pool, and modern amenities.",
                    ImageUrl = "https://unsplash.com/photos/a-large-pink-house-with-a-pond-in-front-of-it-S7bDOVuF4R8",
                    Occupancy =12 ,
                    Rate = 23400,
                    Amenity = "Comfortable beds and sofas,Home theater room",
                    CreatedDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 5,
                    Name = " Urban Escape Villa",
                    Details = "A luxurious villa with private pool, and modern amenities.",
                    ImageUrl = "https://images.unsplash.com/photo-1564013799919-ab600027ffc6?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Occupancy =10 ,
                    Rate =12000 ,
                    Amenity = "Fully equipped kitchen,Jacuzzi or hot tub",
                    CreatedDate = DateTime.Now
                }
                );  
        }

    }
}
