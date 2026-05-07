using System.Security.Cryptography;

if (args.Length < 2)
{
    Console.WriteLine("Использование: Task3_Backup <источник> <папка_резервных_копий>");
    return;
}

string source = args[0];
string backupRoot = args[1];

var sourceDir = new DirectoryInfo(source);
if (!sourceDir.Exists)
{
    Console.WriteLine("Папка-источник не существует.");
    return;
}

var backupRootDir = new DirectoryInfo(backupRoot);
backupRootDir.Create();

// Определяем следующий номер версии
int nextVersion = 1;
foreach (var d in backupRootDir.GetDirectories("version_*"))
{
    if (int.TryParse(d.Name.Replace("version_", ""), out int v) && v >= nextVersion)
        nextVersion = v + 1;
}

// Если уже есть резервные копии — сравниваем с последней
if (nextVersion > 1)
{
    var lastVersionDir = new DirectoryInfo(Path.Combine(backupRoot, $"version_{nextVersion - 1}"));
    if (!HasChanges(sourceDir, lastVersionDir))
    {
        Console.WriteLine("Изменений не обнаружено. Резервная копия не создана.");
        return;
    }
}

// Копируем содержимое в новую версию
var targetDir = new DirectoryInfo(Path.Combine(backupRoot, $"version_{nextVersion}"));
CopyDirectory(sourceDir, targetDir);
Console.WriteLine($"Создана резервная копия: {targetDir.FullName}");

static bool HasChanges(DirectoryInfo source, DirectoryInfo backup)
{
    var sourceFiles = source.GetFiles().OrderBy(f => f.Name).ToArray();
    var backupFiles = backup.GetFiles().OrderBy(f => f.Name).ToArray();

    if (sourceFiles.Length != backupFiles.Length) return true;

    for (int i = 0; i < sourceFiles.Length; i++)
    {
        if (sourceFiles[i].Name != backupFiles[i].Name) return true;
        if (GetMd5(sourceFiles[i]) != GetMd5(backupFiles[i])) return true;
    }
    return false;
}

static string GetMd5(FileInfo file)
{
    using var stream = file.OpenRead();
    return Convert.ToHexString(MD5.HashData(stream));
}

static void CopyDirectory(DirectoryInfo source, DirectoryInfo target)
{
    target.Create();
    foreach (var file in source.GetFiles())
        file.CopyTo(Path.Combine(target.FullName, file.Name), overwrite: true);
    foreach (var sub in source.GetDirectories())
        CopyDirectory(sub, new DirectoryInfo(Path.Combine(target.FullName, sub.Name)));
}
