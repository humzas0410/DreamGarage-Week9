using DreamGarage.Models;
using Microsoft.AspNetCore.Mvc;
using DreamGarage.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using DreamGarage.ViewModels;

namespace DreamGarage.Controllers;

public class GarageController : Controller
{
    private readonly CarContext _context;

    public GarageController(CarContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View(_context.Cars.ToList());
    }
    public IActionResult Cars()
    {
        return View(_context.Cars.ToList());
    }
    public IActionResult Details(int id)
    {
        var car = _context.Cars
            .Include(c => c.Reviews)
            .FirstOrDefault(c => c.Id == id);
        if (car == null)
        {
            return NotFound();
        }
        return View(car);
    }

    [HttpGet]
    public async Task<IActionResult> AddReview(int? id)
    {
        if (id.HasValue && !await _context.Cars.AnyAsync(car => car.Id == id.Value))
        {
            return NotFound();
        }

        var viewModel = new CarReviewFormViewModel
        {
            CarId = id,
            Cars = await GetCarsSelectListAsync(id)
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddReview(CarReviewFormViewModel viewModel)
    {
        var car = viewModel.CarId.HasValue
            ? await _context.Cars.FindAsync(viewModel.CarId.Value)
            : null;

        if (viewModel.CarId.HasValue && car == null)
        {
            ModelState.AddModelError(nameof(viewModel.CarId), "Please select an existing car.");
        }

        if (!ModelState.IsValid || car == null)
        {
            viewModel.Cars = await GetCarsSelectListAsync(viewModel.CarId);
            return View(viewModel);
        }

        var review = new CarReview
        {
            ReviewerName = viewModel.Review.ReviewerName,
            Rating = viewModel.Review.Rating,
            Comment = viewModel.Review.Comment,
            CarId = car.Id
        };
        _context.CarReviews.Add(review);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Details), new { id = car.Id });
    }

    private async Task<SelectList> GetCarsSelectListAsync(int? selectedCarId)
    {
        var cars = await _context.Cars
            .OrderBy(car => car.Make)
            .ThenBy(car => car.Model)
            .Select(car => new { car.Id, Name = car.Make + " " + car.Model })
            .ToListAsync();

        return new SelectList(cars, "Id", "Name", selectedCarId);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Car car)
    {
        if (ModelState.IsValid)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
            
            return RedirectToAction(nameof(Index));
        }
        return View(car);
    }
    // GET: Garage/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var car = await _context.Cars.FindAsync(id);
        if (car == null)
        {
            return NotFound();
        }
        return View(car);
    }

    // POST: Garage/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Make,Model,Trim,Year,Color,Price,Horsepower,IsElectric,IsHybrid,Drivetrain")] Car car)
    {
        if (id != car.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(car);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(car.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(car);
    }
    private bool CarExists(int id)
    {
        return _context.Cars.Any(e => e.Id == id);
    }
    // GET: Garage/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var car = await _context.Cars
            .FirstOrDefaultAsync(m => m.Id == id);
        if (car == null)
        {
            return NotFound();
        }

        return View(car);
    }

    // POST: Garage/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car != null)
        {
            _context.Cars.Remove(car);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}