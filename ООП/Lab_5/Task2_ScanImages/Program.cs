using System.Security;

string outputFile = "pictures.txt";
var pictures = new List<string>();

string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tiff", ".webp" };

foreach (var drive in DriveInfo.GetDrives().Where(d => d.IsReady))
{
    ScanDirectory(new DirectoryInfo(drive.RootDirectory.FullName), imageExtensions, pictures);
}

// Сохраняем список в файл через FileInfo
var outputInfo = new FileInfo(outputFile);
using var writer = outputInfo.CreateText();
foreach (var path in pictures)
    writer.WriteLine(path);

Console.WriteLine($"Найдено изображений: {pictures.Count}");
Console.WriteLine($"Список сохранён в: {outputInfo.FullName}");

static void ScanDirectory(DirectoryInfo dir, string[] extensions, List<string> result)
{
    try
    {
        foreach (var file in dir.GetFiles())
        {
            if (extensions.Contains(file.Extension.ToLower()))
                result.Add(file.FullName);
        }
        foreach (var sub in dir.GetDirectories())
            ScanDirectory(sub, extensions, result);
    }
    catch (Exception ex) when (ex is UnauthorizedAccessException or SecurityException) { }
}
