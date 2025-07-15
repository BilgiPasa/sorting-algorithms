using System.Diagnostics;

namespace SootageSort;

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
        Sort(theArray, 0, theArray.Length - 1);
        s.Stop();
        //Console.WriteLine("[{0}]", string.Join(", ", theArray)); // To see the array
        Console.WriteLine($"{theArray.Length} integers sorted in {s.Elapsed.TotalNanoseconds / 1000000} milliseconds");
    }

    static void Sort(int[] numberArray, int start, int end)
    {
        if (start == end)
        {
            return;
        }

        if (numberArray[start] > numberArray[end])
        {
            (numberArray[start], numberArray[end]) = (numberArray[end], numberArray[start]); // Swapping elements
        }

        if (end - start > 1) // This means if (array size > 2)
        {
            int oneThird = (end - start + 1) / 3;
            Sort(numberArray, start, end - oneThird);
            Sort(numberArray, start + oneThird, end);
            Sort(numberArray, start, end - oneThird);
        }
    }
}

