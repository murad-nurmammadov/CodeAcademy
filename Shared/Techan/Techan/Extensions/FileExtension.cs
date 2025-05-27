namespace Techan.Extensions;

public static class FileExtension
{
    public static bool hasValidType(this IFormFile file, string type)
    {
        return file.ContentType.StartsWith(type);
    }

    public static bool hasValidSize(this IFormFile file, int kb = 2048)  // 2 MB by default
    {
        return file.Length <= kb * 1024;
    }

    public static async Task<string> UploadAsync(this IFormFile file, string rootPath)
    {
        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        string fullPath = Path.Combine(rootPath, fileName);

        using var fs = new FileStream(fullPath, FileMode.Create);
        await file.CopyToAsync(fs);

        return fullPath;
    }

    public static async Task UploadAsync(this IFormFile file, string rootPath, string fileName)
    {
        string fullPath = Path.Combine(rootPath, fileName);
        using var fs = new FileStream(fullPath, FileMode.Create);
        await file.CopyToAsync(fs);
    }
}
