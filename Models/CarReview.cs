using System.ComponentModel.DataAnnotations;

namespace DreamGarage.Models;

public class CarReview
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string ReviewerName { get; set; } = "";

    [Range(1, 5)]
    public int Rating { get; set; }

    [Required]
    [StringLength(500)]
    public string Comment { get; set; } = "";

    public int CarId { get; set; }

    public Car? Car { get; set; }
}
