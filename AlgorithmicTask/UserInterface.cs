using AlgorithmicTask.Core;
using AlgorithmicTask.Data;
using AlgorithmicTask.Handlers;
using AlgorithmicTask.InputReaders;
using AlgorithmicTask.Types;
using System.Diagnostics;

namespace AlgorithmicTask
{
    public class UserInterface
    {
        private Input _input;
        private Outcome _outcome;
        private FileInputHandler _fileHandler;
        private ConsoleInputHandler _consoleInputHandler;
        private BuiltinAlgorithmsHandler _builtinAlgorithmsHandler;
        private ManualAlgorithsHandler _manualAlgorithmsHandler;
        private Stopwatch _stopwatch;

        public UserInterface()
        {
            _input = new Input();
            _outcome = new Outcome();
            _fileHandler = new FileInputHandler();
            _builtinAlgorithmsHandler = new BuiltinAlgorithmsHandler();
            _manualAlgorithmsHandler = new ManualAlgorithsHandler();
            _consoleInputHandler = new ConsoleInputHandler();
            _stopwatch = new Stopwatch();
        }

        public async Task<char> Start()
        {
            char option = ' ';
            InputTypes inputType = new InputTypes();

            Console.WriteLine("Welcome");
            Console.WriteLine("The program finds: Min, Max, Mean, Median, Max Ascending and Descending Sequences from number list");


            Console.WriteLine("\n\nHow would you like to enter your data:");
            Console.WriteLine("\t1 - Via .txt file");
            Console.WriteLine("\t2 - Via console");
            Console.WriteLine("\t3 - Quit");

            while (option != '1' && option != '2' && option != '3')
            {
                option = Console.ReadKey().KeyChar;
                if (option == '3') return option;
            }

            Console.WriteLine();

            int inputOption = int.Parse(option.ToString());
            inputType = (InputTypes)inputOption;

            await AlgorithmChoiceAndRun(inputType);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPress Enter to continue");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();

            return option;
        }

        private async Task AlgorithmChoiceAndRun(InputTypes inputTypes)
        {
            char option = ' ';
            AlgorithmTypes algorithmType = new AlgorithmTypes();

            Console.Clear();
            Console.WriteLine("\nWhich algorithm would you like to use:");
            Console.WriteLine("\t1 - Biult in fucntions");
            Console.WriteLine("\t2 - Manual functions");
            Console.WriteLine("\t3 - Back");

            while (option != '1' && option != '2')
            {
                option = Console.ReadKey().KeyChar;
                if (option == '3') return;
            }

            int algOption = int.Parse(option.ToString());
            algorithmType = (AlgorithmTypes)algOption;

            Console.WriteLine();
            Result<string> inputRes = null;
            // run interaction functions
            switch (inputTypes)
            {
                case InputTypes.File:
                    inputRes = await StartFileWork();
                    break;
                case InputTypes.Console:
                    inputRes = GetASetNumbersFromConsole();
                    break;
                default: return;
            }

            if (inputRes == null) 
            {
                DisplayErrorMessage("Unexpected error. Finishing...");
                return;
            }
            if (!inputRes.IsSuccess) 
            {
                DisplayErrorMessage(inputRes.Error);
                return;
            }

            Result<string> algorithRes = null;
            // run algorithms
            switch (algorithmType)
            {
                case AlgorithmTypes.BuiltIn:
                    algorithRes = StartBuiltinAlgorithms();
                    break;
                case AlgorithmTypes.Manual:
                    algorithRes = StartManualAlgorithms();
                    break;
                default: return;
            }

            if (algorithRes == null)
            {
                DisplayErrorMessage("Unexpected error. Finishing...");
                return;
            }
            if (!algorithRes.IsSuccess)
            {
                DisplayErrorMessage(algorithRes.Error);
                return;
            }

            // show results
            DisplayResults(_outcome);
        }

        private async Task<Result<string>> StartFileWork()
        {
            var res = GetFilepath();
            if (!res.IsSuccess) return res;

            res = await ReadASetNumbersFromFile();
            
            return res;
        }

        private Result<string> GetFilepath()
        {
            Console.Clear();
            Console.WriteLine("Enter Full file path (C:\\Users\\User\\filename.txt): ");
            _input.FilePath = @"" + Console.ReadLine();

            if (string.IsNullOrEmpty(_input.FilePath)) return Result<string>.Failure("File path cannot be empty");

            return Result<string>.Success("");
        }

        private async Task<Result<string>> ReadASetNumbersFromFile()
        {
            var result = await _fileHandler.ReadDataFromFileToStringAsync(_input.FilePath);

            if (!result.IsSuccess) return Result<string>.Failure(result.Error);

            var resultList = _fileHandler.GetNumbersList(result.Value);

            if (!resultList.IsSuccess) return Result<string>.Failure(resultList.Error);

            _input.Numbers = resultList.Value;
            return Result<string>.Success("");
        }

        private Result<string> GetASetNumbersFromConsole()
        {
            var res = _consoleInputHandler.EnterDataFromConsole();
            string input = "";

            if (!res.IsSuccess) return Result<string>.Failure(res.Error);

            input = res.Value;

            var resultNumbers = _consoleInputHandler.SetNumbersFromConsole(input);

            if (!res.IsSuccess) return Result<string>.Failure(res.Error);

            _input.Numbers = resultNumbers.Value;
            return Result<string>.Success("");
        }

        public Result<string> StartBuiltinAlgorithms()
        {
            _stopwatch.Start();

            var nums = new List<int>(_input.Numbers);

            var res = _builtinAlgorithmsHandler.StartAlgorithms(nums);

            if (!res.IsSuccess)
            {
                _stopwatch.Stop();
                return Result<string>.Failure(res.Error);
            }

            _outcome = res.Value;

            _stopwatch.Stop();
            return Result<string>.Success("");
        }

        public Result<string> StartManualAlgorithms()
        {
            _stopwatch.Start();

            var nums = new List<int>(_input.Numbers);

            var res = _manualAlgorithmsHandler.StartAlgorithms(nums);

            if (!res.IsSuccess)
            {
                _stopwatch.Stop();
                return Result<string>.Failure(res.Error);
            }

            _outcome = res.Value;

            _stopwatch.Stop();
            return Result<string>.Success("");
        }

        private void DisplayResults(Outcome outcome)
        {
            TimeSpan timeTaken = _stopwatch.Elapsed;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n-----------------------------Result-----------------------------\n");
            Console.ResetColor();
            Console.WriteLine("Max value: " + outcome.Max);
            Console.WriteLine("Min value: " + outcome.Min);
            Console.WriteLine("Mean value: " + outcome.Mean);
            Console.WriteLine("Median value: " + outcome.Median);
            Console.WriteLine($"Ascending Sequence: \n\tLength: {outcome.MaxSequenceLengthASC}; \n\tSequecne: {outcome.MaxSequenceDataASC}");
            Console.WriteLine($"Descending Sequence: \n\tLength: {outcome.MaxSequenceLengthDESC}; \n\tSequecne: {outcome.MaxSequenceDataDESC}");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nTime taken: " + timeTaken.ToString(@"m\:ss\.fff"));
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n----------------------------------------------------------------\n");
            Console.ResetColor();
        }

        private void DisplayErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
