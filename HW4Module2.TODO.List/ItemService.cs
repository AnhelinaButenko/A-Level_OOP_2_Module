using Common;
using System.Net;

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

    private FileLogger _logger;

    public ItemService()
    {
        _logger = FileLogger.Instance;
    }

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
        
        if (_tasks.Count >= 3)
        {
            throw new OutOfRangeForTasksException();
        }

        _logger.LogInfo($"Item with {newItem} was added");
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

        _logger.LogInfo($"Item with {newItem} was added");
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

        _logger.LogInfo($"Item with {newItem} was added");
    }

    public void Remove(int id)
    {
        Item itemForRemove = _tasks.FirstOrDefault(x => x.Id == id);

        if (itemForRemove == null)
        {
            string message = $"Item with Id: {id} not found";
            _logger.LogError(message);
            throw new Exception(message);
        }

        _tasks.Remove(itemForRemove);
    }

    public List<Item> GetAll()
    {
        _logger.LogInfo($"Getting all items: {_tasks}");
        return _tasks;
    }

    public Item Update(int id, Item newItem)
    {
        Item itemForUpdate = _tasks.FirstOrDefault(x => x.Id == id);

        if (itemForUpdate == null)
        {
            string message = $"Item with Id: {id} not found";
            _logger.LogError(message);
            throw new Exception(message);           
        }

        itemForUpdate.Name = newItem.Name;
        itemForUpdate.TaskRepetitionType = newItem.TaskRepetitionType;
        itemForUpdate.FulfillmentTime = newItem.FulfillmentTime;

        return itemForUpdate;
    }

    public bool Any() => _tasks.Any();
}



