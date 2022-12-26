using Common;

namespace HW4Module2.TODO.List;

public class Program
{
    static void Main(string[] args)
    {
        MenuProgram.BuildMenuOperation();
        string userInput = Helpers.GetValidStringValue();
        MenuProgram.HandleUserChoise(userInput);
        MenuProgram.Back();
    }
}