using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaTemplate.Contexts;
using ProniaTemplate.Models;
using ProniaTemplate.ViewModels.ServiceVMs;

namespace ProniaTemplate.Areas.Admin.Controllers;

[Area("Admin")]
public class ServiceController(ProniaDbContext _context) : Controller
{
    // CHECK everything

    public async Task<IActionResult> Index()
    {
        List<Service> services= await _context.Services.ToListAsync();
        List<ServiceGetVM> vms = services.Select(s => new ServiceGetVM()
        {
            Id = s.Id,
            Title = s.Title,
            Description = s.Description,
            ImagePath = s.ImagePath,
        }).ToList();

        return View(vms);
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ServiceCreateVM model)
    {
        if (!ModelState.IsValid)
            return View(model);

        string? filePath = null;

        if (model.Image != null)
        {
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.Image.FileName);
            string fullPath = Path.Combine("wwwroot", "uploads", fileName);

            using var fs = new FileStream(fullPath, FileMode.Create);
            await model.Image.CopyToAsync(fs);

            filePath = "/uploads/" + fileName;
        }

        var service = new Service()
        {
            Title = model.Title,
            Description = model.Description,
            ImagePath = filePath,
        };

        await _context.Services.AddAsync(service);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        if (id <= 0)
            return BadRequest();

        Service? service = await _context.Services.FindAsync(id);

        if (service == null)
            return NotFound();

        var vm = new ServiceUpdateVM()
        {
            Title = service.Title,
            Description = service.Description,
            ImagePath = service.ImagePath,
        };

        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Update(ServiceUpdateVM model)
    {
        Service? service = await _context.Services.FindAsync(model.Id);

        if (service == null)
            return NotFound();

        string? filePath = model.ImagePath;

        if (model.Image == null)
        {
            // TODO
            // Delete previous file
        }
        else
        {
            string? fileName = model.ImagePath;
            if (model.ImagePath == null)
                fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.Image.FileName);

            string fullPath = Path.Combine("wwwroot", "uploads", fileName);

            using var fs = new FileStream(fullPath, FileMode.Create);
            await model.Image.CopyToAsync(fs);

            filePath = "/uploads/" + fileName;
            service.ImagePath = filePath;
        }

        service.Title = model.Title;
        service.Description = model.Description;

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0)
            return BadRequest();

        var service = await _context.Services.FirstOrDefaultAsync(x => x.Id == id);

        if (service == null)
            return NotFound();

        _context.Services.Remove(service);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
