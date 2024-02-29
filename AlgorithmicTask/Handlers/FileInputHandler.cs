using System.Net;

namespace AlgorithmicTask.Handlers
{
    public class FileInputHandler
    {
        public async Task<string[]> ReadDataFromFileToStringAsync(string fileName)
        {
            string inputDate = "";
            try
            {
                using (var sr = new StreamReader(fileName))
                {
                    inputDate = await sr.ReadToEndAsync();
                }

                return inputDate.Trim(' ', '\n', '\r').Split('\n');
            }
            catch (Exception e)
            {
                return new string[] { "The file could not be read:\n", e.Message };
            }
        }
    }
}
