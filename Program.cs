class MyQueue<T>
{
    //класс элемента очереди
    private class Element
    {
        public readonly T Value;
        public readonly int Priority;

        public Element(T value, int priority)
        {
            Value = value;
            Priority = priority;
        }

        //строгое сравнение приоритетности
        public static bool CheckPriority(Element a, Element b)
        {
            if (a.Priority > b.Priority) return true;
            return false;
        }
    }

    private List<Element> _queue;

    public MyQueue() => _queue = new List<Element>();
    public void Add(T value, int priority) => _queue.Add(new Element(value, priority));

    public T GetAndRemove()
    {
        //блокировка, пока очередь пуста
        while(_queue.Count == 0) { }

        Element best = _queue[0]; //самый первый из самых приоритетных

        // поиск
        for (int i = 1; i < _queue.Count; i++)
        {
            best = Element.CheckPriority(_queue[i], best) ? _queue[i] : best;
        }
        
        //удаление найденного элемента
        _queue.Remove(best);

        return best.Value;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        MyQueue<string> q = new MyQueue<string>();

        //ввод
        q.Add("aa", 1);
        q.Add("bb", 2);
        q.Add("cc", 1);

        //вывод удаленных элементов
        Console.WriteLine(q.GetAndRemove());
        Console.WriteLine(q.GetAndRemove());
        Console.WriteLine(q.GetAndRemove());

        //блокировка
        Console.WriteLine(q.GetAndRemove());
    }
}
