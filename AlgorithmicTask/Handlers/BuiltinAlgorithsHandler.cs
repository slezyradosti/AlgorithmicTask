using AlgorithmicTask.Core;

namespace AlgorithmicTask.Handlers
{
    public class BuiltinAlgorithsHandler
    {
        public Result<string> FindMinMax(IList<int> nums, out int min, out int max)
        {
            min = 0;
            max = 0;

            if (nums == null || nums.Count == 0) return Result<string>.Failure("Empty data");

            int numsLength = nums.Count;

            if (numsLength == 1)
            {
                min = nums[0];
                max = nums[0];
                return Result<string>.Success("");
            }

            min = nums.Min();
            max = nums.Max();
            return Result<string>.Success("");
        }
    }
}
