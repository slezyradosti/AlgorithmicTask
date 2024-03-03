using AlgorithmicTask.Core;
using AlgorithmicTask.Data;
using AlgorithmicTask.Handlers;
using AlgorithmicTask.InputReaders;
using AlgorithmicTask.Types;

namespace AlgorithmicTask
{
    public class UserInterface
    {
        private Input _input;
        private Outcome _outcome;
        private FileInputHandler _fileHandler;
        private ConsoleInputHandler _consoleInputHandler;
        private BuiltinAlgorithmsHandler _algorithmsHandler;
        private ManualAlgorithsHandler _manualAlgorithmsHandler;

        public UserInterface()
        {
            _input = new Input();
            _outcome = new Outcome();
            _fileHandler = new FileInputHandler();
            _algorithmsHandler = new BuiltinAlgorithmsHandler();
            _manualAlgorithmsHandler = new ManualAlgorithsHandler();
            _consoleInputHandler = new ConsoleInputHandler();
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
            Result<string> workRes = null;
            switch (inputTypes)
            {
                case InputTypes.File:
                    workRes = await StartFileWork(algorithmType);
                    break;
                case InputTypes.Console:
                    // console work
                    break;
                default: return;
            }

            if (workRes == null) 
            {
                DisplayErrorMessage("Unexpected error. Finishing...");
                return;
            }
            if (!workRes.IsSuccess) 
            {
                DisplayErrorMessage(workRes.Error);
                return;
            }

            // run algorithms
        }

        private async Task<Result<string>> StartFileWork(AlgorithmTypes algorithmTypes)
        {
            var res = GetNumbersFromFile();
            if (!res.IsSuccess) return res;

            res = await SetNumbersFromFile();
            
            return res;
        }

        private Result<string> GetNumbersFromFile()
        {
            Console.Clear();
            Console.WriteLine("Enter Full file path (C:\\Users\\User\\filename.txt): ");
            _input.FilePath = @"" + Console.ReadLine();

            if (string.IsNullOrEmpty(_input.FilePath))
            {
                DisplayErrorMessage("File path cannot be empty");
                return Result<string>.Failure("");
            }

            return Result<string>.Success("");
        }

        private async Task<Result<string>> SetNumbersFromFile()
        {
            var result = await _fileHandler.ReadDataFromFileToStringAsync(_input.FilePath);

            if (!result.IsSuccess)
            {
                DisplayErrorMessage(result.Error);
                return Result<string>.Failure("");
            }

            var resultList = _fileHandler.GetNumbersList(result.Value);

            if (!resultList.IsSuccess)
            {
                DisplayErrorMessage(resultList.Error);
                return Result<string>.Failure("");
            }

            _input.Numbers = resultList.Value;
            return Result<string>.Success("");
        }

        private void DisplayErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
