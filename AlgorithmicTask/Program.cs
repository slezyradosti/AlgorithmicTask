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

            ManualAlgorithsHandler manualAlgorithsHandler = new();
            var manRes = manualAlgorithsHandler.StartAlgorithms(nums).Value;

            var res = builtinAlgorithsHandler.FindMinMax(nums, out int min, out int max);
            res = builtinAlgorithsHandler.FindMean(nums, out double mean);
            res = builtinAlgorithsHandler.FindMedian(nums, out double median);
            res = builtinAlgorithsHandler.FindMaxSequenceASC(nums, out int resultLenghtAsc, out string resultSequenceAsc);
            res = builtinAlgorithsHandler.FindMaxSequenceDESC(nums, out int resultLenghtDesc, out string resultSequenceDesc);
                        

            Console.WriteLine("Min: " + min + "\n\tManual: " + manRes.Min);
            Console.WriteLine();
            Console.WriteLine("Max: " + max + "\n\tManual: " + manRes.Max);
            Console.WriteLine();
            Console.WriteLine("Mean: " + mean + "\n\tManual: " + manRes.Mean);
            Console.WriteLine();
            Console.WriteLine("Median: " + median + "\n\tManual: " + manRes.Median);
            Console.WriteLine();
            Console.WriteLine("resultLenghtAsc: " + resultLenghtAsc + "\n\tManual: " + manRes.MaxSequenceLengthASC);
            Console.WriteLine();
            Console.WriteLine("resultSequenceAsc: " + resultSequenceAsc + "\n\tManual: " + manRes.MaxSequenceDataASC);
            Console.WriteLine();
            Console.WriteLine("resultLenghtDesc: " + resultLenghtDesc + "\n\tManual: " + manRes.MaxSequenceLengthDESC);
            Console.WriteLine();
            Console.WriteLine("resultSequenceDesc: " + resultSequenceDesc + "\n\tManual: " + manRes.MaxSequenceDataDESC);
        }
    }
}