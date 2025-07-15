using System.Diagnostics;

namespace BubbleSort;

class Program
{
    static void Main(string[] args)
    {
        int[] theArray = new int[120000];
        Random r = new Random();
        Stopwatch s = new Stopwatch();

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
        int i;
        bool b = false;

        while (!b)
        {
            b = true;

            for (i = 1; i < numberArray.Length; i++)
            {
                if (numberArray[i - 1] > numberArray[i])
                {
                    (numberArray[i - 1], numberArray[i]) = (numberArray[i], numberArray[i - 1]); // Swapping elements
                }
            }

            for (i = 1; i < numberArray.Length; i++)
            {
                if (numberArray[i - 1] > numberArray[i])
                {
                    b = false;
                    break;
                }
            }
        }
    }
}

