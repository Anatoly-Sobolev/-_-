using Task8_Stack;
using Task10_StackWithIndexer;

var stack = new ThinkStackArray();
for (int i = 0; i < 4; i++)
    stack.Push(Think.GenerateThink());

Console.WriteLine("Доступ по индексу (0 — нижний):");
for (int i = 0; i < stack.Count; i++)
    Console.WriteLine($"  [{i}] {stack[i].GetThinkInfo()}");

Console.WriteLine("\nИзвлечение (LIFO):");
while (stack.Count > 0)
{
    var t = stack.Pop();
    Console.WriteLine($"  {t.GetThinkInfo()} → {(t.GetDecision() ? "хорошая" : "плохая")}");
}
