using System.Diagnostics;

namespace MergeSort;

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

    static void Sort(int[] intArray)
    {
        if (intArray.Length < 2)
        {
            return;
        }

        int middle = intArray.Length / 2;
        int[] leftArray = new int[middle], rightArray = new int[intArray.Length - middle];

        for (int i = 0; i < middle; i++)
        {
            leftArray[i] = intArray[i];
        }

        for (int i = middle; i < intArray.Length; i++)
        {
            rightArray[i - middle] = intArray[i];
        }

        Sort(leftArray);
        Sort(rightArray);
        Merge(intArray, leftArray, rightArray);
    }

    static void Merge(int[] intArray, int[] leftArray, int[] rightArray)
    {
        int i = 0, j = 0, k = 0;

        while (i < leftArray.Length && j < rightArray.Length)
        {
            if (leftArray[i] > rightArray[j])
            {
                intArray[k++] = rightArray[j++]; // This means intArray[k] = rightArray[j]; k += 1; j += 1;
            }
            else
            {
                intArray[k++] = leftArray[i++]; // This means intArray[k] = leftArray[i]; k += 1; i += 1;
            }
        }

        while (i < leftArray.Length)
        {
            intArray[k++] = leftArray[i++]; // This means intArray[k] = leftArray[i]; k += 1; i += 1;
        }

        while (j < rightArray.Length)
        {
            intArray[k++] = rightArray[j++]; // This means intArray[k] = rightArray[j]; k += 1; j += 1;
        }
    }
}
