string[] names = { "Сергей", "Алексей", "Михаил", "Дмитрий", "Андрей", "Иван" };

Console.WriteLine("До сортировки: " + string.Join(", ", names));

// Сортировка вставками
for (int i = 1; i < names.Length; i++)
{
    string key = names[i];
    int j = i - 1;
    while (j >= 0 && string.Compare(names[j], key, StringComparison.OrdinalIgnoreCase) > 0)
    {
        names[j + 1] = names[j];
        j--;
    }
    names[j + 1] = key;
}

Console.WriteLine("После сортировки: " + string.Join(", ", names));
