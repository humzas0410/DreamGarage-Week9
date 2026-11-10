using System.ComponentModel.DataAnnotations;
using DreamGarage.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DreamGarage.ViewModels;

public class CarReviewFormViewModel
{
    public CarReview Review { get; set; } = new();

    [Display(Name = "Car")]
    [Required(ErrorMessage = "Please select a car.")]
    public int? CarId { get; set; }

    public SelectList? Cars { get; set; }
}
