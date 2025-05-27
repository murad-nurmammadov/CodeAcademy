using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Techan.Contexts;
using Techan.Models;
using Techan.ViewModels.CategoryVMs;

namespace Techan.Areas.Admin.Controllers;

public class CategoryController(TechanDbContext _context) : AdminBaseController
{
    public async Task<IActionResult> Index()
    {
        List<CategoryGetVM> vms = await _context.Categories.Select(c => new CategoryGetVM()
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            Slug = c.Slug,
        }).ToListAsync();

        return View(vms);
    }

    public async Task<IActionResult> Create()
    {
        await FillViewBagAsync();

        return View();
    }

    [HttpPost, AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Create(CategoryCreateVM model)
    {
        if (!ModelState.IsValid)
        {
            await FillViewBagAsync();
            return View(model);
        }

        if (model.ParentCategoryId != null && await _context.Categories.FindAsync(model.ParentCategoryId) == null)
        {
            ModelState.AddModelError("ParentCategoryId", "Invalid parent category id!");
            await FillViewBagAsync();
            return View(model);
        }

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
        Category? entity = await _context.Categories.FindAsync(id);
        if (entity == null)
            return NotFound();

        var model = new CategoryUpdateVM()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Slug = entity.Slug,
            ParentCategoryId = entity.ParentCategoryId,
        };

        await FillViewBagAsync();
        
        return View(model);
    }

    [HttpPost, AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Update(CategoryUpdateVM model)
    {
        if (!ModelState.IsValid)
        {
            await FillViewBagAsync();
            return View(model);
        }

        if (model.ParentCategoryId != null && await _context.Categories.FindAsync(model.ParentCategoryId) == null)
        {
            ModelState.AddModelError("ParentCategoryId", "Invalid parent category id!");
            await FillViewBagAsync();
            return View(model);
        }

        Category? entity = await _context.Categories.FindAsync(model.Id);
        if (entity == null)
            return NotFound();

        entity.Name = model.Name;
        entity.Description = model.Description;
        entity.Slug = model.Slug;
        entity.ParentCategoryId = model.ParentCategoryId;

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        Category? entity = await _context.Categories.FindAsync(id);
        if (entity == null)
            return NotFound();

        _context.Remove(entity);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }


    #region helper methods
    public async Task FillViewBagAsync()
    {
        ViewBag.ParentCategories = await _context.Categories.Select(c => new CategoryGetVM()
        {
            Id = c.Id,
            Name = c.Name,
        }).ToListAsync();
    }
    #endregion
}
