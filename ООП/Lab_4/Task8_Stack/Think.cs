namespace Task8_Stack;

public enum TypeThink
{
    Study,
    Food,
    Games
}

public interface IThink
{
    string GetThinkInfo();
    bool GetDecision();
}

public class Think : IThink
{
    private static readonly Random _rnd = new();

    private static readonly string[] _studyThoughts =
        { "Надо бы сделать лабу", "Скоро экзамен", "Надо повторить материал" };
    private static readonly string[] _foodThoughts =
        { "Не пойти ли мне поесть", "Хочу есть", "Хочу в KFC", "Опять потолстел" };
    private static readonly string[] _gameThoughts =
        { "Хочу поиграть в CS2", "Надо пройти ещё один уровень", "Пора стримить" };

    public TypeThink Type { get; }
    public string Text { get; }

    private Think(TypeThink type, string text)
    {
        Type = type;
        Text = text;
    }

    public static Think CreateWithType(TypeThink type, string text)
        => new Think(type, text);

    public static Think GenerateThink()
    {
        var type = (TypeThink)_rnd.Next(0, 3);
        string text = type switch
        {
            TypeThink.Study => _studyThoughts[_rnd.Next(_studyThoughts.Length)],
            TypeThink.Food  => _foodThoughts[_rnd.Next(_foodThoughts.Length)],
            _               => _gameThoughts[_rnd.Next(_gameThoughts.Length)],
        };
        return new Think(type, text);
    }

    public string GetThinkInfo() => $"[{Type}] {Text}";

    // Мысль хорошая, если это мысль об учёбе
    public bool GetDecision() => Type == TypeThink.Study;
}
