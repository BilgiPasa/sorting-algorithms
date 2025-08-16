using System.Diagnostics;

namespace SelectionSort;

class Program
{
    static void Main(string[] args)
    {
        int[] theArray = new int[55555];
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
        /* In Selection Sort, the program goes through the array and looks for the smallest element. When the
        array ends, it swaps the smallest element with the first element. Then it goes through the array again
        and looks for the second smallest element. When the array ends, it swaps the second smallest element
        with the second element and the process goes on like that until the array is sorted. */

        int smallest;

        for (int i = 0; i < numberArray.Length - 1; i++)
        {
            smallest = i;

            for (int j = i; j < numberArray.Length; j++)
            {
                if (numberArray[smallest] > numberArray[j])
                {
                    smallest = j;
                }
            }

            (numberArray[i], numberArray[smallest]) = (numberArray[smallest], numberArray[i]); // Swapping elements
        }
    }
}
