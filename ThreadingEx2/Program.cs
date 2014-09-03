using System;
using System.Threading;

namespace FindSmallest
{
    class Program
    {

        

        //test
        private static readonly int[][] Data = new int[][]{
            new[]{1,5,4,2}, 
            new[]{3,2,4,11,4},
            new[]{33,2,3,-1, 10},
            new[]{3,2,8,9,-1},
            new[]{1, 22,1,9,-3, 5}        

        };

        private static void threads()
        {
            foreach (int[] data in Data)
            {
                Thread t1 = new Thread(() => FindSmallest(data));
                Thread t2 = new Thread(() => FindSmallest(data));
                Thread t3 = new Thread(() => FindSmallest(data));
                Thread t4 = new Thread(() => FindSmallest(data));
                Thread t5 = new Thread(() => FindSmallest(data));
            }
        }

        private static int FindSmallest(int[] numbers)
        {
            if (numbers.Length < 1)
            {
                throw new ArgumentException("There must be at least one element in the array");
            }

            int smallestSoFar = numbers[0];
            foreach (int number in numbers)
            {
                if (number < smallestSoFar)
                {
                    smallestSoFar = number;
                }
            }
            return smallestSoFar;
        }

        static void Main()
        {
            foreach (int[] data in Data)
            {
                Thread t = new Thread(() => FindSmallest(data));
                int smallest = FindSmallest(data);
                Console.WriteLine("\t" + String.Join(", ", data) + "\n-> " + smallest + t);
            }
        }
    }
}
