using AlgorithmicTask.Handlers;
using AlgorithmicTask.InputReaders;

namespace AlgorithmicTask
{
    class Program
    {
        static async Task Main(string[] args)
        {
            FileInputHandler fileInputHandler = new FileInputHandler();

            string filepath = @"" + Console.ReadLine();

            var splitInput = await fileInputHandler.ReadDataFromFileToStringAsync(filepath);
            var nums = fileInputHandler.GetNumersList(splitInput.Value).Value;

            BuiltinAlgorithsHandler builtinAlgorithsHandler = new BuiltinAlgorithsHandler();

            var res = builtinAlgorithsHandler.FindMinMax(nums, out int min, out int max);
            res = builtinAlgorithsHandler.FindMean(nums, out double mean);
            res = builtinAlgorithsHandler.FindMedian(nums, out double median);
            res = builtinAlgorithsHandler.FindMaxSequenceASC(nums, out int resultLenghtAsc, out string resultSequenceAsc);
            res = builtinAlgorithsHandler.FindMaxSequenceDESC(nums, out int resultLenghtDesc, out string resultSequenceDesc);

            Console.WriteLine("Min: " + min);
            Console.WriteLine("Max: " + max);
            Console.WriteLine("Mean: " + mean);
            Console.WriteLine("Median: " + median);
            Console.WriteLine("resultLenghtAsc: " + resultLenghtAsc);
            Console.WriteLine("resultSequenceAsc: " + resultSequenceAsc);
            Console.WriteLine("resultLenghtDesc: " + resultLenghtDesc);
            Console.WriteLine("resultSequenceDesc: " + resultSequenceDesc);
        }
    }
}