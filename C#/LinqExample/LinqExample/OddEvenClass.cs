using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExample
{
    internal class OddEvenClass
    {
        public static void OddNumbers(int[] numbers)
        {
            Console.WriteLine("Odd Numbers: ");

            IEnumerable<int> oddNumber = from number in numbers
                                         where number % 2 != 0
                                         select number;
            foreach (int number in oddNumber)
            {
                Console.WriteLine(number);
            }
        }

        public static void EvenNumbers(int[] numbers)
        {
            Console.WriteLine("Even Numbers: ");
            IEnumerable<int> evenNumbers = from number in numbers
                                           where number % 2 == 0
                                           select number;
            foreach (var item in evenNumbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
