using System.Diagnostics;

namespace SelectionSort;

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
