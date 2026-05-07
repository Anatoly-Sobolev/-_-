using Task3_Queue;
using Task5_QueueWithIndexer;

string[] names = { "Иванов А.", "Петров Д.", "Сидоров С." };

var queue = new StudentQueueArray();
foreach (var name in names)
    queue.Enqueue(Student.GenerateStudent(name));

Console.WriteLine("Доступ по индексу:");
for (int i = 0; i < queue.Count; i++)
    Console.WriteLine($"  [{i}] {queue[i].GetStudentInfo()}");

Console.WriteLine("\nРезультаты:");
while (queue.Count > 0)
{
    var s = queue.Dequeue();
    Console.WriteLine($"  {s.Name}: {(s.GetDecision() ? "ОТЧИСЛЕН" : "остаётся")}");
}
