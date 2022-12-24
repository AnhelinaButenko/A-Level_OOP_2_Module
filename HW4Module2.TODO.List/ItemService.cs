namespace HW4Module2.TODO.List;
public interface IItemService
{
    void Add(string name);
    void Add(string name, DateTime timeForFulfillment);
    void Add(string name, DateTime timeForFulfillment, string TaskRepetitionType);
    void Remove(int id);
    List<Item> GetAll();
    Item Update(int id, Item newItem);
    bool Any();
}

public class ItemService : IItemService
{
    private static readonly List<Item> _tasks = new List<Item>();

    public void Add(string name)
    {
        Item newItem = new Item();
        bool hasElement = _tasks.Any();

        if (hasElement == false)
        {
            newItem.Id = 1;
        }
        else
        {
            newItem.Id = _tasks.Max(x => x.Id) + 1;
        }

        newItem.Name = name;

        _tasks.Add(newItem);
    }

    public void Add(string name, DateTime timeForFulfillment)
    {
        Item newItem = new Item();
        bool hasElement = _tasks.Any();

        if (hasElement == false)
        {
            newItem.Id = 1;
        }
        else
        {
            newItem.Id = _tasks.Max(x => x.Id) + 1;
        }

        newItem.Name = name;
        newItem.FulfillmentTime = timeForFulfillment;

        _tasks.Add(newItem);
    }

    public void Add(string name, DateTime timeForFulfillment, string TaskRepetitionType)
    {
        Item newItem = new Item();
        bool hasElement = _tasks.Any();

        if (hasElement == false)
        {
            newItem.Id = 1;
        }
        else
        {
            newItem.Id = _tasks.Max(x => x.Id) + 1;
        }

        newItem.Name = name;
        newItem.FulfillmentTime = timeForFulfillment;
        newItem.TaskRepetitionType = TaskRepetitionType;

        _tasks.Add(newItem);
    }

    public void Remove(int id)
    {
        Item itemFotRemove = _tasks.FirstOrDefault(x => x.Id == id);

        if (itemFotRemove == null)
        {
            return;
        }

        _tasks.Remove(itemFotRemove);
    }

    public List<Item> GetAll()
    {
        return _tasks;
    }

    public Item Update(int id, Item newItem)
    {
        Item itemFotUpdate = _tasks.FirstOrDefault(x => x.Id == id);

        if (itemFotUpdate == null)
        {
            return newItem;
        }

        itemFotUpdate.Name = newItem.Name;
        itemFotUpdate.TaskRepetitionType = newItem.TaskRepetitionType;
        itemFotUpdate.FulfillmentTime = newItem.FulfillmentTime;

        return itemFotUpdate;
    }

    public bool Any() => _tasks.Any();
}



