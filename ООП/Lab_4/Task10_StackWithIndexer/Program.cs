using Task8_Stack;
using Task10_StackWithIndexer;

ThinkStackArray stack = new ThinkStackArray();

for (int i = 0; i < 4; i++)
{
    stack.Push(Think.GenerateThink());
}

Console.WriteLine("Доступ по индексу (0 — нижний):");

for (int i = 0; i < stack.Count; i++)
{
    Console.WriteLine($"  [{i}] {stack[i].GetThinkInfo()}");
}

Console.WriteLine("\nИзвлечение (LIFO):");

while (stack.Count > 0)
{
    Think think = stack.Pop();
    string result;

    if (think.GetDecision())
    {
        result = "хорошая";
    }
    else
    {
        result = "плохая";
    }

    Console.WriteLine($"  {think.GetThinkInfo()} → {result}");
}
