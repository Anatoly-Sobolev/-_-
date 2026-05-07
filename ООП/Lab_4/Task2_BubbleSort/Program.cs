string[] surnames = { "Сидоров", "Иванов", "Петров", "Морозов", "Козлов", "Новиков" };

Console.WriteLine("До сортировки: " + string.Join(", ", surnames));

// Сортировка пузырьком
for (int i = 0; i < surnames.Length - 1; i++)
{
    for (int j = 0; j < surnames.Length - 1 - i; j++)
    {
        if (string.Compare(surnames[j], surnames[j + 1], StringComparison.OrdinalIgnoreCase) > 0)
        {
            (surnames[j], surnames[j + 1]) = (surnames[j + 1], surnames[j]);
        }
    }
}

Console.WriteLine("После сортировки: " + string.Join(", ", surnames));
