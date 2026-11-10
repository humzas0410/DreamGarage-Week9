using Microsoft.EntityFrameworkCore;
using DreamGarage.Models;

namespace DreamGarage.Data;

public class CarContext : DbContext
{
    public CarContext(DbContextOptions<CarContext> options) : base(options)
    {
    }

    public DbSet<Car> Cars => Set<Car>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>().HasData(
        new Car { Id = 1, Make = "McLaren", Model = "720S", Trim = "Performance", Year = 2020, Color = "Orange", Price = 275000, Horsepower = 710, IsElectric = false, IsHybrid = false, Drivetrain = "RWD" },
        new Car { Id = 2, Make = "Porsche", Model = "911", Trim = "Turbo S", Year = 2018, Color = "Black", Price = 200000, Horsepower = 580, IsElectric = false, IsHybrid = false, Drivetrain = "AWD" },
        new Car { Id = 3, Make = "Lamborghini", Model = "Aventador", Trim = "SVJ", Year = 2022, Color = "Lime", Price = 550000, Horsepower = 759, IsElectric = false, IsHybrid = false, Drivetrain = "AWD" },
        new Car { Id = 4, Make = "BMW", Model = "M5", Trim = "CS", Year = 2021, Color = "Blue", Price = 145000, Horsepower = 627, IsElectric = false, IsHybrid = false, Drivetrain = "AWD" },
        new Car { Id = 5, Make = "Audi", Model = "RS Q8", Trim = "Performance", Year = 2025, Color = "Red", Price = 135000, Horsepower = 631, IsElectric = false, IsHybrid = true, Drivetrain = "AWD" },
        new Car { Id = 6, Make = "Rimac", Model = "Nevera", Trim = "R", Year = 2024, Color = "Silver", Price = 2500000, Horsepower = 2107, IsElectric = true, IsHybrid = false, Drivetrain = "AWD" }
        );
    }
}