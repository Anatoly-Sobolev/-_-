using Task3_Queue;

namespace Task5_QueueWithIndexer;

public class StudentQueueArray
{
    private Student[] _items;
    private int _count;

    public StudentQueueArray(int capacity = 16)
    {
        _items = new Student[capacity];
    }

    public int Count => _count;

    public void Enqueue(Student student)
    {
        if (_count == _items.Length)
            Array.Resize(ref _items, _items.Length * 2);
        _items[_count++] = student;
    }

    public Student Dequeue()
    {
        if (_count == 0) throw new InvalidOperationException("Очередь пуста.");
        var item = _items[0];
        Array.Copy(_items, 1, _items, 0, _count - 1);
        _count--;
        return item;
    }

    // Индексатор позволяет обращаться к элементам по индексу
    public Student this[int index]
    {
        get
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException();
            return _items[index];
        }
    }
}
