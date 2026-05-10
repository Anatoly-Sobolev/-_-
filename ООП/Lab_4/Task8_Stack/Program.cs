using Task8_Stack;

Stack<Think> stack = new Stack<Think>();

for (int i = 0; i < 5; i++)
{
    stack.Push(Think.GenerateThink());
}

Console.WriteLine("Мысли (последняя — первой):");

foreach (Think think in stack)
{
    string result;

    if (think.GetDecision())
    {
        result = "хорошая";
    }
    else
    {
        result = "плохая";
    }

    Console.WriteLine($"  {think.GetThinkInfo()}  → {result}");
}
