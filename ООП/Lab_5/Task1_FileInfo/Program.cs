// Список одногруппников группы ЭВМ-252
string[] classmates =
{
    "Иванов Алексей",
    "Петров Дмитрий",
    "Сидоров Сергей",
    "Козлов Андрей",
    "Новиков Михаил",
    "Морозов Иван",
};

string groupFileName = "ЭВМ-252.txt";
string backupFileName = "ЭВМ-252_backup.txt";

// Создаём файл и записываем одногруппников
var fileInfo = new FileInfo(groupFileName);
using (var writer = fileInfo.CreateText())
{
    foreach (var name in classmates)
        writer.WriteLine(name);
}
Console.WriteLine($"Файл создан: {fileInfo.FullName}");

// Создаём резервную копию
fileInfo.CopyTo(backupFileName, overwrite: true);
Console.WriteLine($"Резервная копия: {new FileInfo(backupFileName).FullName}");

// Удаляем оригинал
fileInfo.Delete();
Console.WriteLine($"Оригинал удалён. Резервная копия существует: {new FileInfo(backupFileName).Exists}");

// Чистим за собой
new FileInfo(backupFileName).Delete();
