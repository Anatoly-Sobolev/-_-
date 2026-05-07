string[] surnames = { "Иванов", "Петров", "Сидоров", "Козлов", "Новиков", "Морозов" };
string[] names    = { "Алексей", "Дмитрий", "Сергей", "Андрей", "Михаил", "Иван" };

// Объединяем: нечётные индексы — фамилии, чётные — имена
string[] merged = new string[surnames.Length + names.Length];
for (int i = 0; i < surnames.Length; i++)
{
    merged[i * 2]     = names[i];      // чётный индекс — имя
    merged[i * 2 + 1] = surnames[i];   // нечётный индекс — фамилия
}

Console.WriteLine("Объединённый массив:");
for (int i = 0; i < merged.Length; i++)
    Console.WriteLine($"[{i}] {merged[i]}");
