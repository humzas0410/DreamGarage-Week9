using DreamGarage.Models;
using Microsoft.AspNetCore.Mvc;
using DreamGarage.Data;
using Microsoft.EntityFrameworkCore;

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
        var car = _context.Cars.FirstOrDefault(c => c.Id == id);
        if (car == null)
        {
            return NotFound();
        }
        return View(car);
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