namespace Techan.Services.Interfaces;

public interface IFileService
{
    Task<string> SaveFileAsync(IFormFile file, string subfolder = "uploads");
    void DeleteFile(string webPath);
    string GetPhysicalPath(string webPath);
}
