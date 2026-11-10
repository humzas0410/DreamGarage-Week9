using System.ComponentModel.DataAnnotations;

namespace DreamGarage.Models;

public class Car
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Make is required.")]
    [StringLength(20, MinimumLength = 2)]
    public string Make { get; set; } = "";
    [Required(ErrorMessage = "Model is required.")]
    [StringLength(20, MinimumLength = 2)]
    public string Model { get; set; } = "";
    public string Trim { get; set; } = "";
    [Required(ErrorMessage = "Year is required.")]
    [Range(1900, 2026, ErrorMessage = "Year must be between 1900 and 2026.")]
    public int Year { get; set; }
    public string Color { get; set; } = "";
    [Range(1000, 10000000, ErrorMessage = "Price must be between 1,000 and 10,000,000.")]
    public int Price { get; set; }
    [Range(50, 5000, ErrorMessage = "Horsepower must be between 50 and 5,000.")]
    public int Horsepower { get; set; }
    [Display(Name = "Electric?")]
    public bool IsElectric { get; set; }
    [Display(Name = "Hybrid?")]
    public bool IsHybrid { get; set; }
    [Display(Name = "Drivetrain:")]
    public string? Drivetrain { get; set; }
}