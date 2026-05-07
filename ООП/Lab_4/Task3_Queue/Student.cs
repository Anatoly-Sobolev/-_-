namespace Task3_Queue;

public interface IStudent
{
    string GetStudentInfo();
    bool GetDecision();
}

public class Student : IStudent
{
    private static readonly Random _rnd = new();

    public string Name { get; }
    public int Programming { get; }
    public int Philosophy { get; }
    public int Networks { get; }
    public int OptimizationMethods { get; }

    private Student(string name, int prog, int phil, int net, int opt)
    {
        Name = name;
        Programming = prog;
        Philosophy = phil;
        Networks = net;
        OptimizationMethods = opt;
    }

    public static Student GenerateStudent(string name)
    {
        return new Student(name,
            _rnd.Next(2, 6),
            _rnd.Next(2, 6),
            _rnd.Next(2, 6),
            _rnd.Next(2, 6));
    }

    public static Student CreateWithGrades(string name, int prog, int phil, int net, int opt)
        => new Student(name, prog, phil, net, opt);

    public string GetStudentInfo() =>
        $"{Name}: Программирование={Programming}, Философия={Philosophy}, " +
        $"Сети={Networks}, МетодыОптимизации={OptimizationMethods}";

    // Студент отчисляется, если хотя бы 2 двойки
    public bool GetDecision()
    {
        int fails = 0;
        if (Programming == 2) fails++;
        if (Philosophy == 2) fails++;
        if (Networks == 2) fails++;
        if (OptimizationMethods == 2) fails++;
        return fails >= 2;
    }
}
