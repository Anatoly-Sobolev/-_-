using Task8_Stack;

var stack = new Stack<Think>();
for (int i = 0; i < 5; i++)
    stack.Push(Think.GenerateThink());

Console.WriteLine("Мысли (последняя — первой):");
foreach (var t in stack)
    Console.WriteLine($"  {t.GetThinkInfo()}  → {(t.GetDecision() ? "хорошая" : "плохая")}");
