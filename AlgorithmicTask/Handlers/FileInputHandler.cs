using AlgorithmicTask.Core;
using System.Net;

namespace AlgorithmicTask.Handlers
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

        
    }
}
