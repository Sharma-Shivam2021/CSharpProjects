using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode_SOLID_;

internal class GoodCommentExample
{
    public class MathUtils
    {
        // Bad : Calculate the factorial of number
        // Not What but tell Why
        // BAD: Using a recursive approach to calculate factorial

        // Good: We are using a recursive approach here because it's more intiutive
        public int CalculateFactorial(int number)
        {
            if (number <= 1) return 1;
            else
            {
                return number * CalculateFactorial(number - 1);
            }
        }


        // Using binary search to improve the performance of the large dataset
        public int BinarySearch(int[] sortedArray, int target)
        {
            int left = 0;
            int right = sortedArray.Length - 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (sortedArray[mid] == target) { return mid; }
                else if (sortedArray[mid]<target)
                { 
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return -1;
        }


        // TODO: Create a function that performs Foo
        public int Foo()
        {
            return -1;
        }

    }
}
