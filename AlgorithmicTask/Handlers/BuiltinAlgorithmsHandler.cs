using AlgorithmicTask.Core;
using AlgorithmicTask.Data;
using System;
using System.Text;

namespace AlgorithmicTask.Handlers
{
    public class BuiltinAlgorithmsHandler
    {
        public Result<Outcome> StartAlgorithms(IList<int> nums)
        {
            Outcome outcome = new Outcome();

            FindMinMax(nums, out int min, out int max);
            FindMean(nums, out double mean);
            FindMedian(nums, out double median);
            FindMaxSequenceASC(nums, out int ascSeqLength, out string ascSequence);
            FindMaxSequenceDESC(nums, out int descSeqLength, out string descSequence);

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

        private Result<string> FindMinMax(IList<int> nums, out int min, out int max)
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
        private Result<string> FindMean(IList<int> nums, out double mean)
        {
            mean = 0;

            if (nums == null || nums.Count == 0) Result<string>.Failure("Empty data");

            // sum of all numbers could be more than int value can contain
            // that why we use long int and parallel couting
            long sum = nums.AsParallel().Sum(x => (long)x);
            mean = sum / (double)nums.Count;

            return Result<string>.Success("");
        }

        private Result<string> FindMedian(IList<int> nums, out double median)
        {
            if (nums == null || nums.Count == 0) Result<string>.Failure("Empty data");

            var sortedArray = nums.Order().ToList();

            if (sortedArray.Count % 2 == 0)
            {
                int middle = sortedArray.Count / 2;
                median = (sortedArray[middle - 1] + sortedArray[middle]) / 2.0;
            }
            else
            {
                median = sortedArray[sortedArray.Count / 2];
            }

            return Result<string>.Success("");
        }

        private Result<string> FindMaxSequenceASC(IList<int> nums, out int resultLength, out string resultSequence)
        {
            resultSequence = "";
            resultLength = 0;

            if (nums == null || nums.Count == 0) return Result<string>.Failure("Empty data");

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

            if (nums == null || nums.Count == 0) return Result<string>.Failure("Empty data");

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
