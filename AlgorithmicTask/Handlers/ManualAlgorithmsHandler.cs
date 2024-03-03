using AlgorithmicTask.Core;
using AlgorithmicTask.Data;
using System.Text;

namespace AlgorithmicTask.Handlers
{
    public class ManualAlgorithsHandler
    {
        private List<int> _nums;

        public Result<Outcome> StartAlgorithms(IList<int> nums)
        {
            if (nums == null || nums.Count == 0) return Result<Outcome>.Failure("Invalid data");

            Outcome outcome = new Outcome();
            var unsortedNums = new List<int>(nums);
            Result<string> res = new();

            SortASaveToList(new List<int>(nums), 0, nums.Count - 1);

            res = GetMinMax(_nums, out int min, out int max);
            if (!res.IsSuccess) return Result<Outcome>.Failure(res.Error);

            res = FindMean(_nums, out double mean);
            if (!res.IsSuccess) return Result<Outcome>.Failure(res.Error);

            res = FindMedian(_nums, out double median);
            if (!res.IsSuccess) return Result<Outcome>.Failure(res.Error);

            res = FindMaxSequenceASC(unsortedNums, out int ascSeqLength, out string ascSequence);
            if (!res.IsSuccess) return Result<Outcome>.Failure(res.Error);

            res = FindMaxSequenceDESC(unsortedNums, out int descSeqLength, out string descSequence);
            if (!res.IsSuccess) return Result<Outcome>.Failure(res.Error);

            outcome = new Outcome()
            {
                Min = min,
                Max = max,
                Mean = Math.Round(mean, 2),
                Median = Math.Round(median, 2),
                MaxSequenceLengthASC = ascSeqLength,
                MaxSequenceDataASC = ascSequence,
                MaxSequenceLengthDESC = descSeqLength,
                MaxSequenceDataDESC = descSequence,
            };

            return Result<Outcome>.Success(outcome);
        }

        private void SortASaveToList(IList<int> nums, int leftIndex, int rightIndex)
        {
            _nums = QuickSort(nums, leftIndex, rightIndex).ToList();
        }

        private IList<int> QuickSort(IList<int> nums, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = nums[leftIndex];
            while (i <= j)
            {
                while (nums[i] < pivot)
                {
                    i++;
                }

                while (nums[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                QuickSort(nums, leftIndex, j);
            if (i < rightIndex)
                QuickSort(nums, i, rightIndex);
            return nums;
        }

        // list must be ordered before
        private Result<string> GetMinMax(IList<int> nums, out int min, out int max)
        {
            min = 0;
            max = 0;
            if (nums == null || nums.Count == 0) return Result<string>.Failure("Invalid data");

            min = nums[0];
            max = nums[nums.Count - 1];

            return Result<string>.Success("");
        }

        private Result<string> FindMean(IList<int> nums, out double mean)
        {
            mean = 0;
            long sum = 0;

            if (nums == null || nums.Count == 0) return Result<string>.Failure("Invalid data");

            foreach (long i in nums)
            {
                if (sum + i <= long.MaxValue)
                {
                    sum += i;
                }
            }

            mean = sum / (double)nums.Count();

            return Result<string>.Success("");
        }

        // list must be ordered before
        private Result<string> FindMedian(IList<int> nums, out double median)
        {
            median = 0;
            if (nums == null || nums.Count == 0) return Result<string>.Failure("Invalid data");

            if (nums.Count % 2 == 0)
            {
                int middle = nums.Count / 2;
                median = (nums[middle - 1] + nums[middle]) / 2.0;
            }
            else
            {
                median = nums[nums.Count / 2];
            }

            return Result<string>.Success("");
        }

        private Result<string> FindMaxSequenceASC(IList<int> nums, out int resultLength, out string resultSequence)
        {
            resultSequence = "";
            resultLength = 0;

            if (nums == null || nums.Count == 0) return Result<string>.Failure("Invalid data");

            StringBuilder tempSequence = new StringBuilder(nums[0] + ", ");
            int tempLength = 1;

            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    tempLength++;
                    tempSequence.Append(nums[i] + ", ");
                }
                else
                {
                    if (tempLength > resultLength)
                    {
                        resultSequence = tempSequence.ToString();
                        resultLength = tempLength;
                    }

                    tempSequence.Clear();
                    tempSequence.Append(nums[i] + ", ");
                    tempLength = 1;
                }
            }

            if (tempLength > resultLength)
            {
                resultSequence = tempSequence.ToString();
                resultLength = tempLength;
            }

            return Result<string>.Success("");
        }

        private Result<string> FindMaxSequenceDESC(IList<int> nums, out int resultLength, out string resultSequence)
        {
            resultSequence = "";
            resultLength = 0;

            if (nums == null || nums.Count == 0) return Result<string>.Failure("Invalid data");

            StringBuilder tempSequence = new StringBuilder(nums[0] + ", ");
            int tempLength = 1;

            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i] < nums[i - 1])
                {
                    tempLength++;
                    tempSequence.Append(nums[i] + ", ");
                }
                else
                {
                    if (tempLength > resultLength)
                    {
                        resultSequence = tempSequence.ToString();
                        resultLength = tempLength;
                    }

                    tempSequence.Clear();
                    tempSequence.Append(nums[i] + ", ");
                    tempLength = 1;
                }
            }

            if (tempLength > resultLength)
            {
                resultSequence = tempSequence.ToString();
                resultLength = tempLength;
            }

            return Result<string>.Success("");
        }
    }
}
