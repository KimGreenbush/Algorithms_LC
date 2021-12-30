using System;

namespace BinarySearch_704
{
    class Solution
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int Search(int[] nums, int target)
            {
                int mid = nums.Length / 2;
                int start = 0;
                int end = nums.Length-1;

                while (start <= end)
                {
                    if (target == nums[mid]) return mid;
                    if (target < nums[mid]) end = mid - 1;
                    else start = mid + 1;
                    mid = (start + end) / 2;
                }
                return -1;
            }

            int[] numbers = { -1, 0, 3, 5, 9, 12 };
            int integer = 9;
            Search(numbers, integer);
        }
    }
}
