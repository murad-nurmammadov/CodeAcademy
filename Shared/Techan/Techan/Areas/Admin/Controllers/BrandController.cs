using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Techan.Contexts;
using Techan.Extensions;
using Techan.Models;
using Techan.ViewModels.BrandVMs;
using Techan.ViewModels.CategoryVMs;

namespace Techan.Areas.Admin.Controllers;

public class BrandController : AdminBaseController
{
    private readonly TechanDbContext _context;
    private readonly IWebHostEnvironment _env;
    private readonly string _rootPath;

    public BrandController(TechanDbContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
        _rootPath = Path.Combine(_env.WebRootPath, "uploads", "brands");
        Directory.CreateDirectory(_rootPath);
    }

    public async Task<IActionResult> Index()
    {
        List<BrandGetVM> vms = await _context.Brands.Select(b => new BrandGetVM
        {
            Id = b.Id,
            Name = b.Name,
            ImagePath = b.ImagePath,
        }).ToListAsync();

        await FillViewBagAsync();

        return View(vms);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost, AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Create(BrandCreateVM model)
    {
        if (!ModelState.IsValid)
            return View(model);

        string? imagePath = null;
        if (model.Image != null)
        {
            try
            {
                imagePath = await model.Image.HandleUploadAsync(_rootPath);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Image", ex.Message);
                await FillViewBagAsync();
                return View(model);
            }
        }

        var entity = new Brand()
        {
            Name = model.Name,
            ImagePath = imagePath,
        };

        await _context.Brands.AddAsync(entity);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        Brand? entity = await _context.Brands.FindAsync(id);
        if (entity == null)
            return NotFound();

        var model = new BrandUpdateVM
        {
            Id = entity.Id,
            Name = entity.Name,
            ImagePath = entity.ImagePath,
        };

        return View(model);
    }

    [HttpPost, AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Update(BrandUpdateVM model)
    {
        if (!ModelState.IsValid)
            return View(model);

        Brand? entity = await _context.Brands.FindAsync(model.Id);
        if (entity == null)
            return NotFound();

        string? imagePath = entity.ImagePath;
        if (model.Image != null)
        {
            try
            {
                imagePath = await model.Image.HandleUploadAsync(_rootPath, entity.ImagePath);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Image", ex.Message);
                await FillViewBagAsync();
                return View(model);
            }
        }


        entity.Name = model.Name;
        entity.ImagePath = imagePath;

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        Brand? entity = await _context.Brands.FindAsync(id);
        if (entity == null)
            return NotFound();

        if (entity.ImagePath != null)
            System.IO.File.Delete(Path.Combine(_rootPath, entity.ImagePath));

        _context.Remove(entity);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    #region helper methods
    public async Task FillViewBagAsync()
    {
        ViewBag.Categories = await _context.Categories.Select(c => new CategoryGetVM()
        {
            Id = c.Id,
            Name = c.Name,
        }).ToListAsync();
    }
    #endregion
}
