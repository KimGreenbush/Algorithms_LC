/*
Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.

You must write an algorithm with O(log n) runtime complexity.

Example 1:
Input: nums = [1,3,5,6], target = 5
Output: 2

Example 2:
Input: nums = [1,3,5,6], target = 2
Output: 1

Example 3:
Input: nums = [1,3,5,6], target = 7
Output: 4

Constraints:
1 <= nums.length <= 104
-104 <= nums[i] <= 104
nums contains distinct values sorted in ascending order.
-104 <= target <= 104
*/

/*
Notes on initializing and updating "mid":
Initialized outside the loop => update **after** if/else left/right search.
Initialized inside the loop => update **before**(obviously) if/else left/right search.
*/

using System;
namespace SearchInsertPosition_35
{
    class Program
    {
        static void Main(string[] args)
        {
            int SearchInsert(int[] nums, int target)
            {
                int left = 0;
                int right = nums.Length - 1;

                while (left <= right)
                {
                    // this way of finding a mid prevents number overflow vs (left + right)/2
                    int mid = left + (right - left) / 2;
                    if (nums[mid] == target) return mid;
                    if (nums[mid] > target) right = mid - 1;
                    else left = mid + 1;

                    // when down to two comparisons, if left and right are neighbors and left is smaller than target and right is larger than target, return the right index value
                    if (right - left == 1 && nums[left] < target && nums[right] > target) return right;
                }

                // if array is empty this returns 0 (left is 0 and right would equal -1 since the lenght is 0 - 1) or the target value would be inserted after the final index (loop exits once left is passed right indicating the insertion point is outside the array)
                return left;
            }

            int[] numbers = { 1, 3, 5, 6 };

            SearchInsert(numbers, 2);
        }
    }
}
