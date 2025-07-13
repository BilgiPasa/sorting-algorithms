using System.Diagnostics;

namespace RadixSort;

class Program
{
    static void Main(string[] args)
    {
        Random r = new Random();
        Stopwatch s = new Stopwatch();
        int[] theArray = {1,3,2,7,8,9,5,2,6,6,8,5,4,5,4,2,2,4,5,7,0,9,7,5,4,7,4,2,3};
        //int[] theArray = new int[120000];

        /*for (int i = 0; i < theArray.Length; i++)
        {
            theArray[i] = r.Next(int.MinValue, int.MaxValue);
        }*/

        s.Start();
        CountingSort(theArray);
        s.Stop();
        Console.WriteLine("[{0}]", string.Join(", ", theArray)); // To see the array
        Console.WriteLine($"{theArray.Length} integers sorted in {s.Elapsed.TotalNanoseconds / 1000000} milliseconds");
    }

    static void Sort(int[] numberArray)
    {

    }

    static void CountingSort(int[] numeralArray)
    {
        int[] counterArray = new int[10];

        for (int i = 0; i < numeralArray.Length; i++)
        {
            counterArray[numeralArray[i]]++;
        }

        for (int i = 1; i < 10; i++)
        {
            counterArray[i] += counterArray[i - 1];
        }

        int[] outputArray = new int[numeralArray.Length];

        for (int i = numeralArray.Length - 1; i >= 0; i--)
        {
            outputArray[--counterArray[numeralArray[i]]] = numeralArray[i];
        }

        for (int i = 0; i < numeralArray.Length; i++)
        {
            numeralArray[i] = outputArray[i];
        }
    }
}
