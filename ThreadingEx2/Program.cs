using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FindSmallest
{
    class Program
    {
        private static readonly int[][] Data = new int[][]{ //Liste af 5 arrays med tal.
            new[]{1,2,3,4}, 
            new[]{5,6,7,8,9},
            new[]{10,11,12,13,14},
            new[]{15,16,17,18,19},
            new[]{20,21,22,23,24,25}     
        };
       private static List<Task<int>> TaskList = new List<Task<int>>();  //Liste til at holde data.
       private static int[] totalvalues = new int[5]; // Indeholder det laveste tal fra hvert array.
       private static int valocation;
        public static int FindSmallest(int[] numbers) //metode til at finde det laveste nummer.
        {
            if (numbers.Length < 1)
            {
                throw new ArgumentException("There must be at least one element in the array");
            }

            int smallestSoFar = numbers[3]; //FOrklar hvorfor [0] Hvorfor virker 3, men ikke 4?
            foreach (int number in numbers)
            {
                if (number < smallestSoFar)
                {
                    smallestSoFar = number;

                    //Console.WriteLine("\t" + String.Join(", ", number) + "\n-> ");
                }
            }

            

            return smallestSoFar;

        }

        //public static int verysmallest(int[] numbers)
        //{
            
        //}



        private static void Main()  //Her bliver programmet kørt.
        {
            //Task<int> t = new Task<int>();
            foreach (int[] data in Data) //Kører en thread med metoden FindSMallest via lamba expression, for hvert array i data. Adder dem så til TaskList.
            {

                Task<int> t = new Task<int>(() => FindSmallest(data));
             
                TaskList.Add(t);
                t.Start();
            }

            for (int i = 0; i <= Data[0].Length; i++) //FOrklar hvorfor [0]
            {
                int result = TaskList[i].Result; // 
                totalvalues[valocation] = result;
                valocation++;
                Console.WriteLine(String.Join(", ", Data[i]) + " Laveste tal i rækken er " + result);
            }

            int finalresult = FindSmallest(totalvalues);
            Console.WriteLine("Laveste tal i alle rækker er  " + finalresult);
            Console.ReadKey();
        }
        }
    }

