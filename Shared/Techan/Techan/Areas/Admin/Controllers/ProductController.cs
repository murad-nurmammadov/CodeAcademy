using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Techan.Contexts;
using Techan.Extensions;
using Techan.Models;
using Techan.ViewModels.BrandVMs;
using Techan.ViewModels.CategoryVMs;
using Techan.ViewModels.ProductVMs;

namespace Techan.Areas.Admin.Controllers;

public class ProductController : AdminBaseController
{
    private readonly TechanDbContext _context;
    private readonly IWebHostEnvironment _env;
    private readonly string _rootPath;

    public ProductController(TechanDbContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
        _rootPath = Path.Combine(env.WebRootPath, "uploads", "products");
        Directory.CreateDirectory(_rootPath);
    }

    public async Task<IActionResult> Index()
    {
        List<ProductGetVM> vms = await _context.Products.Select(p => new ProductGetVM
        {
            Id = p.Id,
            Title = p.Title,
            Description = p.Description,
            Cost = p.Cost,
            DateAdded = p.DateAdded,
            ImagePath = p.ImagePath,
        })
        .ToListAsync();

        await FillViewBagAsync();

        return View(vms);
    }

    public async Task<IActionResult> Create()
    {
        await FillViewBagAsync();
        return View();
    }

    [HttpPost, AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Create(ProductCreateVM model)
    {
        if (!ModelState.IsValid)
        {
            await FillViewBagAsync();
            return View(model);
        }

        Category? category = await _context.Categories.FindAsync(model.CategoryId);
        if (category == null) return NotFound();

        Brand? brand = await _context.Brands.FindAsync(model.CategoryId);
        if (brand == null) return NotFound();

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

        var entity = new Product()
        {
            Title = model.Title,
            Description = model.Description,
            BrandId = model.BrandId,
            Cost = model.Cost,
            CategoryId = model.CategoryId,
            ImagePath = imagePath,
        };

        await _context.Products.AddAsync(entity);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        Product? entity = await _context.Products.FindAsync(id);
        if (entity == null)
            return NotFound();

        var model = new ProductUpdateVM
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            BrandId = entity.BrandId,
            Cost = entity.Cost,
            CategoryId = entity.CategoryId,
            ImagePath = entity.ImagePath,
        };

        await FillViewBagAsync();

        return View(model);
    }

    [HttpPost, AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Update(ProductUpdateVM model)
    {
        if (!ModelState.IsValid)
            return View(model);

        Product? entity = await _context.Products.FindAsync(model.Id);
        if (entity == null)
            return NotFound();

        Category? category = await _context.Categories.FindAsync(model.CategoryId);
        if (category == null) return NotFound();

        Brand? brand = await _context.Brands.FindAsync(model.CategoryId);
        if (brand == null) return NotFound();

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

        entity.Id = model.Id;
        entity.Title = model.Title;
        entity.Description = model.Description;
        entity.BrandId = model.BrandId;
        entity.Cost = model.Cost;
        entity.CategoryId = model.CategoryId;
        entity.ImagePath = imagePath;

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        Product? entity = await _context.Products.FindAsync(id);
        if (entity == null)
            return NotFound();

        if (entity.ImagePath != null)
            System.IO.File.Delete(Path.Combine(_rootPath, entity.ImagePath));

        _context.Remove(entity);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    #region helper methods
    private async Task FillViewBagAsync()
    {
        ViewBag.Categories = await _context.Categories
            .Select(c => new CategoryGetVM { Id = c.Id, Name = c.Name })
            .ToListAsync();

        ViewBag.Brands = await _context.Brands
            .Select(b => new BrandGetVM { Id = b.Id, Name = b.Name })
            .ToListAsync();
    }
    #endregion
}
