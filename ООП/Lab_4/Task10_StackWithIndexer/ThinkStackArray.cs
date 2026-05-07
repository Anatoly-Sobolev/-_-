using Task8_Stack;

namespace Task10_StackWithIndexer;

public class ThinkStackArray
{
    private Think[] _items;
    private int _count;

    public ThinkStackArray(int capacity = 16)
    {
        _items = new Think[capacity];
    }

    public int Count => _count;

    public void Push(Think think)
    {
        if (_count == _items.Length)
            Array.Resize(ref _items, _items.Length * 2);
        _items[_count++] = think;
    }

    public Think Pop()
    {
        if (_count == 0) throw new InvalidOperationException("Стек пуст.");
        return _items[--_count];
    }

    // Индексатор: [0] — самый нижний элемент стека
    public Think this[int index]
    {
        get
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException();
            return _items[index];
        }
    }
}
