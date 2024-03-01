using AlgorithmicTask.Core;
using System.Text;

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

        // mean = sum / count
        public Result<string> FindMean(IList<int> nums, out double mean)
        {
            mean = 0;

            if (nums == null || nums.Count == 0) Result<string>.Failure("Empty data");

            // sum of all numbers could be more than int value can contain
            // that why we use long int and parallel couting
            long sum = nums.AsParallel().Sum(x => (long)x);
            mean = sum / (double)nums.Count;

            return Result<string>.Success("");
        }

        public Result<string> FindMedian(IList<int> nums, out double median)
        {
            if (nums == null || nums.Count == 0) Result<string>.Failure("Empty data");

            var sortedArray = nums.Order().ToList();
            int numbersCount = sortedArray.Count;

            if (numbersCount % 2 == 0)
            {
                int middle = numbersCount / 2;
                median = (sortedArray[middle - 1] + sortedArray[middle]) / 2.0;
            }
            else
            {
                median = sortedArray[numbersCount / 2];
            }

            return Result<string>.Success("");
        }

        public Result<string> FindMaxSequenceASC(IList<int> nums, out int resultLength, out string resultSequence)
        {
            resultSequence = "";
            resultLength = 0;

            if (nums == null || nums.Count == 0) return Result<string>.Failure("Empty data");

            string tempSequence = $"{nums[0]}, ";
            int tempLength = 1;

            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    tempLength++;
                    tempSequence += $"{nums[i]}, ";
                }
                else
                {
                    if (tempLength > resultLength)
                    {
                        resultSequence = tempSequence;
                        resultLength = tempLength;
                    }

                    tempSequence = $"{nums[i]}, ";
                    tempLength = 1;
                }
            }

            if (tempLength > resultLength)
            {
                resultSequence = tempSequence;
                resultLength = tempLength;
            }

            return Result<string>.Success("");
        }

        public Result<string> FindMaxSequenceDESC(IList<int> nums, out int resultLength, out string resultSequence)
        {
            resultSequence = "";
            resultLength = 0;

            if (nums == null || nums.Count == 0) return Result<string>.Failure("Empty data");

            string tempSequence = $"{nums[0]}, ";
            int tempLength = 1;

            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i] < nums[i - 1])
                {
                    tempLength++;
                    tempSequence += $"{nums[i]}, ";
                }
                else
                {
                    if (tempLength > resultLength)
                    {
                        resultSequence = tempSequence;
                        resultLength = tempLength;
                    }

                    tempSequence = $"{nums[i]}, ";
                    tempLength = 1;
                }
            }

            if (tempLength > resultLength)
            {
                resultSequence = tempSequence;
                resultLength = tempLength;
            }

            return Result<string>.Success("");
        }
    }
}
