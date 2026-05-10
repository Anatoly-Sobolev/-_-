Dictionary<string, string> dictionary = new Dictionary<string, string>
{
    { "class",       "класс" },
    { "object",      "объект" },
    { "interface",   "интерфейс" },
    { "inheritance", "наследование" },
    { "method",      "метод" },
    { "property",    "свойство" },
    { "constructor", "конструктор" },
    { "namespace",   "пространство имён" },
    { "array",       "массив" },
    { "collection",  "коллекция" },
};

Console.WriteLine("Англо-русский словарь:");

foreach (KeyValuePair<string, string> pair in dictionary)
{
    Console.WriteLine($"  {pair.Key} — {pair.Value}");
}

Console.Write("\nВведите английское слово: ");
string? word = Console.ReadLine();

if (word != null)
{
    word = word.ToLower();
}

string? translation;

if (word != null && dictionary.TryGetValue(word, out translation))
{
    Console.WriteLine($"Перевод: {translation}");
}
else
{
    Console.WriteLine("Слово не найдено.");
}
