using System;

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
    }
}
