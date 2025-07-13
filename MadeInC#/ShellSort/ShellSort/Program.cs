using System.Diagnostics;

namespace ShellSort;

class Program
{
    static void Main(string[] args)
    {
        Random r = new Random();
        Stopwatch s = new Stopwatch();
        int[] theArray = new int[120000];

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
        int temp, j;

        for (int gap = numberArray.Length / 2; gap > 0; gap /= 2)
        {
            for (int i = gap; i < numberArray.Length; i++)
            {
                temp = numberArray[i];

                for (j = i; j >= gap && numberArray[j - gap] > temp; j -= gap)
                {
                    numberArray[j] = numberArray[j - gap];
                }

                numberArray[j] = temp;
            }
        }
    }
}
