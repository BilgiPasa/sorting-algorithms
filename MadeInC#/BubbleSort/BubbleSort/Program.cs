using System.Diagnostics;

namespace BubbleSort;

class Program
{
    static void Main(string[] args)
    {
        Random r = new Random();
        Stopwatch s = new Stopwatch();
        int[] theArray = new int[10000];

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
        bool b = false;

        while (!b)
        {
            b = true;

            for (int i = 0; i < numberArray.Length - 1; i++)
            {
                if (numberArray[i] > numberArray[i + 1])
                {
                    (numberArray[i], numberArray[i + 1]) = (numberArray[i + 1], numberArray[i]); // Swapping elements
                }
            }

            for (int i = 0; i < numberArray.Length - 1; i++)
            {
                if (numberArray[i] > numberArray[i + 1])
                {
                    b = false;
                    break;
                }
            }
        }
    }
}

