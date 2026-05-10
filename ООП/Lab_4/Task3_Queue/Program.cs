using Task3_Queue;

string[] names = { "Иванов А.", "Петров Д.", "Сидоров С.", "Козлов А.", "Новиков М." };

Queue<Student> queue = new Queue<Student>();

foreach (string name in names)
{
    queue.Enqueue(Student.GenerateStudent(name));
}

Console.WriteLine("Очередь на проверку:");
foreach (Student student in queue)
{
    Console.WriteLine($"  {student.GetStudentInfo()}");
}

Console.WriteLine("\nРезультаты:");
while (queue.Count > 0)
{
    Student student = queue.Dequeue();
    string result;

    if (student.GetDecision())
    {
        result = "ОТЧИСЛЕН";
    }
    else
    {
        result = "остаётся";
    }

    Console.WriteLine($"  {student.Name}: {result}");
}
