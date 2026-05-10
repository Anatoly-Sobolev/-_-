using System.Security;

string outputFile = "pictures.txt";
List<string> pictures = new List<string>();

string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tiff", ".webp" };

DriveInfo[] drives = DriveInfo.GetDrives();

foreach (DriveInfo drive in drives)
{
    if (drive.IsReady)
    {
        DirectoryInfo rootDirectory = new DirectoryInfo(drive.RootDirectory.FullName);
        ScanDirectory(rootDirectory, imageExtensions, pictures);
    }
}

// Сохраняем список в файл через FileInfo
FileInfo outputInfo = new FileInfo(outputFile);

using (StreamWriter writer = outputInfo.CreateText())
{
    foreach (string path in pictures)
    {
        writer.WriteLine(path);
    }
}

Console.WriteLine($"Найдено изображений: {pictures.Count}");
Console.WriteLine($"Список сохранён в: {outputInfo.FullName}");

static void ScanDirectory(DirectoryInfo dir, string[] extensions, List<string> result)
{
    try
    {
        FileInfo[] files = dir.GetFiles();

        foreach (FileInfo file in files)
        {
            string fileExtension = file.Extension.ToLower();

            if (IsImageExtension(fileExtension, extensions))
            {
                result.Add(file.FullName);
            }
        }

        DirectoryInfo[] subDirectories = dir.GetDirectories();

        foreach (DirectoryInfo subDirectory in subDirectories)
        {
            ScanDirectory(subDirectory, extensions, result);
        }
    }
    catch (UnauthorizedAccessException)
    {
    }
    catch (SecurityException)
    {
    }
}

static bool IsImageExtension(string fileExtension, string[] imageExtensions)
{
    foreach (string imageExtension in imageExtensions)
    {
        if (fileExtension == imageExtension)
        {
            return true;
        }
    }

    return false;
}
