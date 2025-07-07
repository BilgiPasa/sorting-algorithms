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

    static void Sort(int[] numberArray)
    {
        if (numberArray.Length < 2)
        {
            return;
        }

        int middle = numberArray.Length / 2;
        int[] leftArray = new int[middle], rightArray = new int[numberArray.Length - middle];

        for (int i = 0; i < middle; i++)
        {
            leftArray[i] = numberArray[i];
        }

        for (int i = middle; i < numberArray.Length; i++)
        {
            rightArray[i - middle] = numberArray[i];
        }

        Sort(leftArray);
        Sort(rightArray);
        Merge(numberArray, leftArray, rightArray);
    }

    static void Merge(int[] numberArray, int[] leftArray, int[] rightArray)
    {
        int i = 0, j = 0, k = 0;

        while (i < leftArray.Length && j < rightArray.Length)
        {
            if (leftArray[i] > rightArray[j])
            {
                numberArray[k++] = rightArray[j++]; // This means numberArray[k] = rightArray[j]; k += 1; j += 1;
            }
            else
            {
                numberArray[k++] = leftArray[i++]; // This means numberArray[k] = leftArray[i]; k += 1; i += 1;
            }
        }

        while (i < leftArray.Length)
        {
            numberArray[k++] = leftArray[i++]; // This means numberArray[k] = leftArray[i]; k += 1; i += 1;
        }

        while (j < rightArray.Length)
        {
            numberArray[k++] = rightArray[j++]; // This means numberArray[k] = rightArray[j]; k += 1; j += 1;
        }
    }
}
