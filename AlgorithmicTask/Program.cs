using AlgorithmicTask.Handlers;

namespace AlgorithmicTask
{
    class Program
    {
        static async Task Main(string[] args)
        {
            FileInputHandler fileInputHandler = new FileInputHandler();

            string filepath = @"" + Console.ReadLine();

            var splitInput = await fileInputHandler.ReadDataFromFileToStringAsync(filepath);
            var nums = fileInputHandler.GetNumersList(splitInput.Value);

            foreach ( var i in nums.Value )
            {
                Console.WriteLine(i);
            }
        }
    }
}