﻿using System.Diagnostics;

namespace InsertsionSort;

class Program
{
    static void Main(string[] args)
    {
        Random r = new Random();
        Stopwatch s = new Stopwatch();
        int[] theArray = new int[120000];

        for (int i = 0; i < theArray.Length; i++)
        {
            theArray[i] = r.Next(int.MinValue, int.MaxValue);
        }

        s.Start();
        Sort(theArray);
        s.Stop();
        //Console.WriteLine("[{0}]", string.Join(", ", theArray)); // To see the array
        Console.WriteLine($"{theArray.Length} integers sorted in {s.Elapsed.TotalNanoseconds / 1000000} milliseconds");
    }

    static void Sort(int[] numberArray)
    {
        int temp;

        for (int i = 1; i < numberArray.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (numberArray[i] < numberArray[j])
                {
                    temp = numberArray[i];

                    for (int k = i; k > j; k--)
                    {
                        numberArray[k] = numberArray[k - 1];
                    }

                    numberArray[j] = temp;
                }
            }
        }
    }
}
