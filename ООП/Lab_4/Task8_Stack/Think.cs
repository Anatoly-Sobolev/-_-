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
    {
        return new Think(type, text);
    }

    public static Think GenerateThink()
    {
        TypeThink type = (TypeThink)_rnd.Next(0, 3);
        string text;

        if (type == TypeThink.Study)
        {
            int index = _rnd.Next(_studyThoughts.Length);
            text = _studyThoughts[index];
        }
        else if (type == TypeThink.Food)
        {
            int index = _rnd.Next(_foodThoughts.Length);
            text = _foodThoughts[index];
        }
        else
        {
            int index = _rnd.Next(_gameThoughts.Length);
            text = _gameThoughts[index];
        }

        return new Think(type, text);
    }

    public string GetThinkInfo()
    {
        return $"[{Type}] {Text}";
    }

    // Мысль хорошая, если это мысль об учёбе
    public bool GetDecision()
    {
        if (Type == TypeThink.Study)
        {
            return true;
        }

        return false;
    }
}
