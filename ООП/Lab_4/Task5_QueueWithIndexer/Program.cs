using Task3_Queue;
using Task5_QueueWithIndexer;

string[] names = { "Иванов А.", "Петров Д.", "Сидоров С." };

StudentQueueArray queue = new StudentQueueArray();

foreach (string name in names)
{
    queue.Enqueue(Student.GenerateStudent(name));
}

Console.WriteLine("Доступ по индексу:");
    
for (int i = 0; i < queue.Count; i++)
{
    Console.WriteLine($"  [{i}] {queue[i].GetStudentInfo()}");
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
