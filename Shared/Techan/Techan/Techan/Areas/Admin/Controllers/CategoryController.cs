using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Techan.Contexts;
using Techan.Models;

namespace Techan.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController(TechanDbContext _context) : Controller
{
    public async Task<IActionResult> Index()
    {
        List<Category> categories = await _context.Categories.ToListAsync();
        return View(categories);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost, AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Create(Category category)
    {
        if (!ModelState.IsValid)
            return View(category);

        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        Category? category = await _context.Categories.FindAsync(id);

        if (category == null)
            return NotFound();

        return View(category);
    }

    [HttpPost, AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Update(Category category)
    {
        if (!ModelState.IsValid)
            return View(category);

        Category? existingCategory = await _context.Categories.FindAsync(category.Id);

        if (existingCategory == null)
            return NotFound();

        //_context.Categories.Update(category);
        existingCategory.Name = category.Name;
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpPost, AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        Category? category= await _context.Categories.FindAsync(id);

        if (category == null)
            return NotFound();

        _context.Remove(category);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
