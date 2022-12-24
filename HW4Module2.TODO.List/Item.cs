namespace HW4Module2.TODO.List;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string TaskRepetitionType { get; set; }
    public DateTime FulfillmentTime { get; set; }
}

public class RepetitionTypes
{
    public const string Daily = "Daily";
    public const string Weekly = "Weekly";
    public const string Monthly = "Monthly";
    public const string Yearly = "Yearly";
}

