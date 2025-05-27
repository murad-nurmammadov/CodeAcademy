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

        return fileName;
    }

    public static async Task UploadAsync(this IFormFile file, string rootPath, string fileName)
    {
        string fullPath = Path.Combine(rootPath, fileName);
        using var fs = new FileStream(fullPath, FileMode.Create);
        await file.CopyToAsync(fs);
    }

    public static async Task<string?> HandleUploadAsync(this IFormFile file, string rootPath, string? fileName = null, int kb = 2048)
    {
        if (!file.hasValidType("image"))
            throw new Exception("Only image files are accepted!");

        if (!file.hasValidSize(kb))
            throw new Exception("File size cannot exceed 2 MBs!");

        if (string.IsNullOrWhiteSpace(fileName))
            return await file.UploadAsync(rootPath);  // this overload of UploadAsync return string fileName as well

        await file.UploadAsync(rootPath, fileName);
        return fileName;
    }
}
