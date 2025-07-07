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

        for (int a = 0; a < numberArray.Length - 1; a++)
        {
            smallest = a;

            for (int i = a; i < numberArray.Length; i++)
            {
                if (numberArray[smallest] > numberArray[i])
                {
                    smallest = i;
                }
            }

            (numberArray[a], numberArray[smallest]) = (numberArray[smallest], numberArray[a]);
        }
    }
}
