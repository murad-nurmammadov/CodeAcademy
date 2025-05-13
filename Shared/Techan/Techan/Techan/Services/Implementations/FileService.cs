using Techan.Services.Interfaces;

namespace Techan.Services.Implementations;

public class FileService(IWebHostEnvironment _env) : IFileService
{
    // TODO
    public async Task<string> SaveFileAsync(IFormFile file, string subfolder = "uploads")
    {
        if (file == null || file.Length == 0)
            throw new ArgumentNullException(nameof(file));

        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        string folderPath = Path.Combine(_env.WebRootPath, subfolder);
        
        Directory.CreateDirectory(folderPath);

        string fullPath = Path.Combine(folderPath, fileName);

        using var fs = new FileStream(fullPath, FileMode.Create);
        await file.CopyToAsync(fs);

        string webPath = $"{subfolder}/{fileName}";

        return webPath;
    }

    public void DeleteFile(string webPath)
    {
        if (string.IsNullOrWhiteSpace(webPath))
            return;

        string fullPath = GetPhysicalPath(webPath);

        throw new NotImplementedException();
    }

    public string GetPhysicalPath(string webPath)
    {
        return Path.Combine(_env.WebRootPath, webPath.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString()));
    }
}
