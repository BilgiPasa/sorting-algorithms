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
        /* In Bubble Sort, the program goes through the array and checks the elements and the elements next to
        it. If the left element that program is checking is bigger than the right next element, the program
        swaps the elements. When the array ends, if the array is not sorted, the program repeats this process
        until the array is sorted. */

        int i, j;

        do
        {
            i = 0;

            for (j = 1; j < numberArray.Length; j++)
            {
                if (numberArray[j - 1] > numberArray[j])
                {
                    (numberArray[j - 1], numberArray[j]) = (numberArray[j], numberArray[j - 1]); // Swapping elements
                    i++;
                }
            }
        }
        while (i > 0);
    }
}

