namespace AlgorithmicTask
{
    class Program
    {
        static async Task Main(string[] args)
        {
            char option = ' ';
            while (option != '3')
            {
                var userInterface = new UserInterface();
                option = await userInterface.Start();
            }
        }
    }
}