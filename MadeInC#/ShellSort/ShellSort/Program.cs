using System.Diagnostics;

namespace ShellSort;

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
        int temp, j;

        for (int interval = numberArray.Length / 2; interval > 0; interval /= 2)
        {
            for (int i = interval; i < numberArray.Length; i++)
            {
                temp = numberArray[i];

                for (j = i; j >= interval && numberArray[j - interval] > temp; j -= interval)
                {
                    numberArray[j] = numberArray[j - interval];
                }

                numberArray[j] = temp;
            }
        }
    }
}
