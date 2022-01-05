﻿/*
You are a product manager and currently leading a team to develop a new product. Unfortunately, the latest version of your product fails the quality check. Since each version is developed based on the previous version, all the versions after a bad version are also bad.

Suppose you have n versions [1, 2, ..., n] and you want to find out the first bad one, which causes all the following ones to be bad.

You are given an API bool isBadVersion(version) which returns whether version is bad. Implement a function to find the first bad version. You should minimize the number of calls to the API.

Example 1:
Input: n = 5, bad = 4
Output: 4

Explanation:
call isBadVersion(3) -> false
call isBadVersion(5) -> true
call isBadVersion(4) -> true
Then 4 is the first bad version.

Example 2:
Input: n = 1, bad = 1
Output: 1

Constraints:
1 <= bad <= n <= 231 - 1
*/

using System;

namespace FirstBadVersion_278
{
    class Program : VersionControl
    {
        static void Main(string[] args)
        {
            int FirstBadVersion(int n)
            {
                int start = 1;
                int end = n;

                // because we're not looking for a specific value but instead a change in value we don't have to use "<=" and go that extra step
                while (start < end)
                {
                    // this way of finding a mid prevents number overflow
                    int mid = start + ((end - start) / 2);
                    /* Value of these two lines in terms of performance improvement is debatable
                    if (IsBadVersion(mid) == true && IsBadVersion(mid - 1) == false) return mid;
                    if (IsBadVersion(mid) == false && IsBadVersion(mid + 1) == true) return mid + 1;
                    */
                    if (IsBadVersion(mid) == true)
                    {
                        // end is inclusive (not "- 1") because of the comparative nature of the search and needs to remain in bounds
                        end = mid;
                    }
                    else
                    {
                        start = mid + 1;
                    }
                }
                return start;
            }
        }
    }
}