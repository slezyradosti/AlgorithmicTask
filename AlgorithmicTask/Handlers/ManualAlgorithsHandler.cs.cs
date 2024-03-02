using System;
using System.Text;

namespace AlgorithmicTask.Handlers
{
    public class ManualAlgorithsHandler
    {
        private List<int> _nums;

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
        private void GetMinMax(IList<int> nums, out int min, out int max)
        {
            min = 0;
            max = 0;
            if (nums == null || nums.Count == 0) return;

            min = nums[0];
            max = nums[nums.Count - 1];
        }

        private void FindMean(IList<int> nums, out double mean)
        {
            mean = 0;
            long sum = 0;

            if (nums == null || nums.Count == 0) return;

            foreach (long i in nums)
            {
                if (sum + i <= long.MaxValue)
                {
                    sum += i;
                }
            }

            mean = sum / (double)nums.Count();
        }

        // list must be ordered before
        private void FindMedian(IList<int> nums, out double median)
        {
            median = 0;
            if (nums == null || nums.Count == 0) return;

            if (nums.Count % 2 == 0)
            {
                int middle = nums.Count / 2;
                median = (nums[middle - 1] + nums[middle]) / 2.0;
            }
            else
            {
                median = nums[nums.Count / 2];
            }
        }

        private void FindMaxSequenceASC(IList<int> nums, out int resultLength, out string resultSequence)
        {
            resultSequence = "";
            resultLength = 0;

            if (nums == null || nums.Count == 0) return;

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
        }

        private void FindMaxSequenceDESC(IList<int> nums, out int resultLength, out string resultSequence)
        {
            resultSequence = "";
            resultLength = 0;

            if (nums == null || nums.Count == 0) return;

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
        }
    }
}
