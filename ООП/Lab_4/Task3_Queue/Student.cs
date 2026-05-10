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
        int programming = _rnd.Next(2, 6);
        int philosophy = _rnd.Next(2, 6);
        int networks = _rnd.Next(2, 6);
        int optimizationMethods = _rnd.Next(2, 6);

        return new Student(name, programming, philosophy, networks, optimizationMethods);
    }

    public static Student CreateWithGrades(string name, int prog, int phil, int net, int opt)
    {
        return new Student(name, prog, phil, net, opt);
    }

    public string GetStudentInfo()
    {
        string info = $"{Name}: Программирование={Programming}, Философия={Philosophy}, ";
        info = info + $"Сети={Networks}, МетодыОптимизации={OptimizationMethods}";
        return info;
    }

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
