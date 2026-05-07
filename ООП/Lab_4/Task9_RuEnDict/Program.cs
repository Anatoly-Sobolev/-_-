var dictionary = new Dictionary<string, string>
{
    { "класс",               "class" },
    { "объект",              "object" },
    { "интерфейс",           "interface" },
    { "наследование",        "inheritance" },
    { "метод",               "method" },
    { "свойство",            "property" },
    { "конструктор",         "constructor" },
    { "пространство имён",   "namespace" },
    { "массив",              "array" },
    { "коллекция",           "collection" },
};

Console.WriteLine("Русско-английский словарь:");
foreach (var pair in dictionary)
    Console.WriteLine($"  {pair.Key} — {pair.Value}");

Console.Write("\nВведите русское слово: ");
string? word = Console.ReadLine()?.ToLower();
if (word != null && dictionary.TryGetValue(word, out string? translation))
    Console.WriteLine($"Translation: {translation}");
else
    Console.WriteLine("Слово не найдено.");
