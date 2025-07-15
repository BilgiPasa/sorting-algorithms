using System.Diagnostics;

namespace QuickSort;

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
        if (start >= end)
        {
            return;
        }

        int pivot = PivotAssignerAndElementShifter(numberArray, start, end);
        Sort(numberArray, start, pivot - 1);
        Sort(numberArray, pivot + 1, end);
    }

    static int PivotAssignerAndElementShifter(int[] numberArray, int start, int end)
    {
        int i = start - 1;

        for (int j = start; j < end; j++)
        {// Initial pivot is the last element of the array
            // Moving elements that is smaller than our pivot to the left.
            if (numberArray[j] < numberArray[end])
            {
                (numberArray[++i], numberArray[j]) = (numberArray[j], numberArray[i]); // This means i += 1; int temp = numberArray[i]; numberArray[i] = numberArray[j]; numberArray[j] = temp;
            }
        }

        (numberArray[++i], numberArray[end]) = (numberArray[end], numberArray[i]); // This means i += 1; int temp = numberArray[i]; numberArray[i] = numberArray[end]; numberArray[end] = temp;
        return i; // Swapped the initial pivot with our new pivot and returned the new pivot
    }
}
