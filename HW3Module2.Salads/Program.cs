namespace HW3Module2.Salads
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuProgram.BuildMenuOperation();
            int userInput = Helpers.GetUserInput(new[] { 1, 2, 3, 4 });
            MenuProgram.HandleUserChoise(userInput);
            MenuProgram.Back();
        }
    }
}