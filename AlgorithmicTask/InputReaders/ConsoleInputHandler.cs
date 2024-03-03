using AlgorithmicTask.Core;

namespace AlgorithmicTask.InputReaders
{
    public class ConsoleInputHandler
    {
        public Result<string> EnterDataFromConsole()
        {
            Console.Clear();
            Console.WriteLine("Enter your number with an empty space between (1 2 3)");
            Console.WriteLine("To finish press Enter button");

            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input)) return Result<string>.Failure("Incorrect input");

            return Result<string>.Success(input);
        }

        public Result<List<int>> SetNumbersFromConsole(string input)
        {
            if (string.IsNullOrEmpty(input)) return Result<List<int>>.Failure("Incorrect input");

            var splitInput = input.Trim().Split(' ');

            try
            {
                var nums = new List<int>(Array.ConvertAll(splitInput, int.Parse));
                return Result<List<int>>.Success(nums);
            }
            catch (Exception e)
            {
                return Result<List<int>>.Failure($"Unable to read file numbers!");
            }
        }
    }
}
