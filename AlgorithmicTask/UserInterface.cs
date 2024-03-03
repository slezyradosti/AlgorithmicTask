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
        private BuiltinAlgorithmsHandler _algorithmsHandler;
        private ManualAlgorithsHandler _manualAlgorithmsHandler;

        public UserInterface()
        {
            _input = new Input();
            _outcome = new Outcome();
            _fileHandler = new FileInputHandler();
            _algorithmsHandler = new BuiltinAlgorithmsHandler();
            _manualAlgorithmsHandler = new ManualAlgorithsHandler();
        }

        public char Start()
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

            AlgorithmChoiceAndRun(inputType);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPress Enter to continue");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();

            return option;
        }

        private void AlgorithmChoiceAndRun(InputTypes inputTypes)
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
            switch (inputTypes)
            {
                case InputTypes.File:
                    // file work
                    break;
                case InputTypes.Console:
                    // console work
                    break;
                default: break;
            }

            // run algorithms
        }
    }
}
