using AlgorithmicTask.Core;

namespace AlgorithmicTask.InputReaders
{
    public class FileInputHandler
    {
        public async Task<Result<string[]>> ReadDataFromFileToStringAsync(string fileName)
        {
            string inputData = "";
            try
            {
                using (var sr = new StreamReader(fileName))
                {
                    inputData = await sr.ReadToEndAsync();
                }

                if (string.IsNullOrEmpty(inputData))
                {
                    return Result<string[]>.Failure("Empty data.");
                }

                return Result<string[]>.Success(inputData.Trim(' ', '\n', '\r').Split('\n'));
            }
            catch (Exception e)
            {
                return Result<string[]>.Failure("The file could not be read:\n" + e.Message);
            }
        }

        public Result<List<int>> GetNumbersList(string[] splitInput)
        {
            if (splitInput == null || splitInput.Length <= 0)
            {
                return Result<List<int>>.Failure("Empty data.");
            }

            List<int> numbers = new List<int>(splitInput.Length);

            try
            {
                numbers = new List<int>(Array.ConvertAll(splitInput, int.Parse));
                return Result<List<int>>.Success(numbers);
            }
            catch (Exception e)
            {
                numbers = new List<int>();
                return Result<List<int>>.Failure($"Unable to read file numbers!");
            }
        }
    }
}
