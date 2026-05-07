using Task3_Queue;

string[] names = { "Иванов А.", "Петров Д.", "Сидоров С.", "Козлов А.", "Новиков М." };

var queue = new Queue<Student>();
foreach (var name in names)
    queue.Enqueue(Student.GenerateStudent(name));

Console.WriteLine("Очередь на проверку:");
foreach (var s in queue)
    Console.WriteLine($"  {s.GetStudentInfo()}");

Console.WriteLine("\nРезультаты:");
while (queue.Count > 0)
{
    var s = queue.Dequeue();
    string result = s.GetDecision() ? "ОТЧИСЛЕН" : "остаётся";
    Console.WriteLine($"  {s.Name}: {result}");
}
