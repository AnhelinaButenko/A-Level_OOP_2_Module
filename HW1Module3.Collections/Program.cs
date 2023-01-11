using System.Collections;

namespace HW1Module3.Collections;

public class Program
{
    static void Main(string[] args)
    {
        var myCollection = new MyCollection<int>
        {
            11,
            23,
            17,
        };


        myCollection.Add(1);
        myCollection.AddRange(new List<int> { 7, 8, 6 });

        Console.WriteLine("Show All");
        Show(myCollection);

        myCollection.Remove(23);
        Console.WriteLine("Show All After item 23 removed");
        Show(myCollection);

        Console.WriteLine("Show All After item at index 1 removed");

        myCollection.RemoveAt(1);
        Show(myCollection);

        Console.WriteLine("Show All sorted");
        myCollection.Sort();
        Show(myCollection);
    }

    private static void Show(MyCollection<int> myCollection)
    {
        foreach (var item in myCollection)
        {
            Console.WriteLine(item);
        }
    }
}

public class MyCollection<T> : IEnumerable<T>
{
    private T[] _arr = new T[0];

    public int Length => _arr.Length;

    public T this[int i] => _arr[i];

    public void Add(T item)
    {
        Resize();

        _arr[_arr.Length - 1] = item;
    }

    public void AddRange(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            Add(item);
        }
    }

    public bool Remove(T item)
    {
        int index = Array.IndexOf(_arr, item);

        return RemoveAt(index);
    }

    public bool RemoveAt(int index)
    {
        _arr = _arr.Where((val, idx) => idx != index).ToArray();
        return true;
    }

    public T[] Sort()
    {
        Array.Sort<T>(_arr);

        return _arr;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new MyCollectionEnumerator<T>(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private void Resize()
    {
        Array.Resize(ref _arr, _arr.Length + 1);
    }
}

public class MyCollectionEnumerator<T> : IEnumerator<T>
{
    private MyCollection<T> _collection;
    private int _index = -1;

    public T Current
    {
        get
        {
            if (_index < 0 || _index >= _collection.Length) throw new IndexOutOfRangeException();

            return _collection[_index];
        }
    }
    object IEnumerator.Current => Current;

    public MyCollectionEnumerator(MyCollection<T> collection)
    {
        _collection = collection;
    }

    public void Dispose() { }

    public bool MoveNext()
    {
        if (_index < _collection.Length - 1)
        {
            _index++;
            return true;
        }

        return false;
    }

    public void Reset() => _index = -1;
}