// Массив вида: [имя, фамилия, имя, фамилия, ...]
string[] merged = { "Алексей", "Иванов", "Дмитрий", "Петров", "Сергей", "Сидоров", "Андрей", "Козлов" };

int half = merged.Length / 2;
string[] names    = new string[half];
string[] surnames = new string[half];

for (int i = 0; i < half; i++)
{
    names[i]    = merged[i * 2];
    surnames[i] = merged[i * 2 + 1];
}

Console.WriteLine("Имена:    " + string.Join(", ", names));
Console.WriteLine("Фамилии:  " + string.Join(", ", surnames));
