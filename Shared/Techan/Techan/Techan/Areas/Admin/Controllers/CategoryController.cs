using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Techan.Contexts;
using Techan.Models;
using Techan.ViewModels.CategoryVMs;

namespace Techan.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController(TechanDbContext _context) : Controller
{
    // CHECK everything below
    // TODO everything below
    public async Task<IActionResult> Index()
    {
        List<Category> categories = await _context.Categories.ToListAsync();
        List<CategoryGetVM> vms = categories.Select(c => new CategoryGetVM()
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            Slug = c.Slug,
        }).ToList();

        return View(vms);
    }

    public async Task<IActionResult> Create()
    {
        List<Category> parentCategories = await _context.Categories.ToListAsync();

        var vm = new CategoryCreateVM()
        {
            ParentCategories = parentCategories.Select(c => new CategoryGetVM()
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList(),
        };

        return View(vm);
    }

    [HttpPost, AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Create(CategoryCreateVM model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var category = new Category()
        {
            Name = model.Name,
            Description = model.Description,
            Slug = model.Slug,
            ParentCategoryId = model.ParentCategoryId,
        };

        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        List<Category> categories = await _context.Categories.ToListAsync();

        Category? category = await _context.Categories.FindAsync(id);

        if (category == null)
            return NotFound();

        var vm = new CategoryUpdateVM()
        {
            Id = category.Id,
            Name = category.Name,
            ParentCategories = categories.Select(c => new CategoryGetVM()
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList(),
        };

        return View(vm);
    }

    [HttpPost, AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Update(CategoryUpdateVM model)
    {
        if (!ModelState.IsValid)
            return View(model);

        Category? category = await _context.Categories.FindAsync(model.Id);

        if (category == null)
            return NotFound();

        category.Name = model.Name;
        category.Description = model.Description;
        category.Slug = model.Slug;
        category.ParentCategoryId = model.ParentCategoryId;

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        Category? category = await _context.Categories.FindAsync(id);

        if (category == null)
            return NotFound();

        _context.Remove(category);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
