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
FileInfo fileInfo = new FileInfo(groupFileName);

using (StreamWriter writer = fileInfo.CreateText())
{
    foreach (string name in classmates)
    {
        writer.WriteLine(name);
    }
}

Console.WriteLine($"Файл создан: {fileInfo.FullName}");

// Создаём резервную копию
fileInfo.CopyTo(backupFileName, overwrite: true);

FileInfo backupFileInfo = new FileInfo(backupFileName);
Console.WriteLine($"Резервная копия: {backupFileInfo.FullName}");

// Удаляем оригинал
fileInfo.Delete();
Console.WriteLine($"Оригинал удалён. Резервная копия существует: {backupFileInfo.Exists}");

// Чистим за собой
backupFileInfo.Delete();
