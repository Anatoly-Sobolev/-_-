using System.Security.Cryptography;

if (args.Length < 2)
{
    Console.WriteLine("Использование: Task3_Backup <источник> <папка_резервных_копий>");
    return;
}

string source = args[0];
string backupRoot = args[1];

DirectoryInfo sourceDir = new DirectoryInfo(source);

if (!sourceDir.Exists)
{
    Console.WriteLine("Папка-источник не существует.");
    return;
}

DirectoryInfo backupRootDir = new DirectoryInfo(backupRoot);
backupRootDir.Create();

// Определяем следующий номер версии
int nextVersion = 1;

DirectoryInfo[] versionDirectories = backupRootDir.GetDirectories("version_*");

foreach (DirectoryInfo directory in versionDirectories)
{
    string versionText = directory.Name.Replace("version_", "");
    int versionNumber;

    if (int.TryParse(versionText, out versionNumber))
    {
        if (versionNumber >= nextVersion)
        {
            nextVersion = versionNumber + 1;
        }
    }
}

// Если уже есть резервные копии — сравниваем с последней
if (nextVersion > 1)
{
    string lastVersionPath = Path.Combine(backupRoot, $"version_{nextVersion - 1}");
    DirectoryInfo lastVersionDir = new DirectoryInfo(lastVersionPath);

    if (!HasChanges(sourceDir, lastVersionDir))
    {
        Console.WriteLine("Изменений не обнаружено. Резервная копия не создана.");
        return;
    }
}

// Копируем содержимое в новую версию
string targetPath = Path.Combine(backupRoot, $"version_{nextVersion}");
DirectoryInfo targetDir = new DirectoryInfo(targetPath);
CopyDirectory(sourceDir, targetDir);
Console.WriteLine($"Создана резервная копия: {targetDir.FullName}");

static bool HasChanges(DirectoryInfo source, DirectoryInfo backup)
{
    FileInfo[] sourceFiles = source.GetFiles();
    FileInfo[] backupFiles = backup.GetFiles();

    Array.Sort(sourceFiles, CompareFilesByName);
    Array.Sort(backupFiles, CompareFilesByName);

    if (sourceFiles.Length != backupFiles.Length)
    {
        return true;
    }

    for (int i = 0; i < sourceFiles.Length; i++)
    {
        if (sourceFiles[i].Name != backupFiles[i].Name)
        {
            return true;
        }

        string sourceMd5 = GetMd5(sourceFiles[i]);
        string backupMd5 = GetMd5(backupFiles[i]);

        if (sourceMd5 != backupMd5)
        {
            return true;
        }
    }

    return false;
}

static int CompareFilesByName(FileInfo firstFile, FileInfo secondFile)
{
    return string.Compare(firstFile.Name, secondFile.Name, StringComparison.OrdinalIgnoreCase);
}

static string GetMd5(FileInfo file)
{
    using (FileStream stream = file.OpenRead())
    {
        byte[] hashBytes = MD5.HashData(stream);
        string hashText = Convert.ToHexString(hashBytes);
        return hashText;
    }
}

static void CopyDirectory(DirectoryInfo source, DirectoryInfo target)
{
    target.Create();

    FileInfo[] files = source.GetFiles();

    foreach (FileInfo file in files)
    {
        string targetFilePath = Path.Combine(target.FullName, file.Name);
        file.CopyTo(targetFilePath, overwrite: true);
    }

    DirectoryInfo[] subDirectories = source.GetDirectories();

    foreach (DirectoryInfo subDirectory in subDirectories)
    {
        string targetSubDirectoryPath = Path.Combine(target.FullName, subDirectory.Name);
        DirectoryInfo targetSubDirectory = new DirectoryInfo(targetSubDirectoryPath);
        CopyDirectory(subDirectory, targetSubDirectory);
    }
}
