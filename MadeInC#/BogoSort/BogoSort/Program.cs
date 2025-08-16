using System.Diagnostics;

namespace BogoSort;

class Program
{
    static void Main(string[] args)
    {
        int[] theArray = new int[11]; // Array size that bigger than 11 takes a looong time to sort.
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
        /* In Bogo Sort; firstly, the program checks if the array is sorted. If not, it shuffels the array and
        checks again if the array is sorted. The program repeates this process until the array is sorted. */

        int i;
        bool b = true;

        for (i = 1; i < numberArray.Length; i++) // Cheking if the array is sorted
        {
            if (numberArray[i - 1] > numberArray[i])
            {
                b = false;
                break;
            }
        }

        if (b)
        {
            return;
        }

        Random r = new Random();

        while (!b)
        {
            b = true;
            r.Shuffle(numberArray);

            for (i = 1; i < numberArray.Length; i++) // Cheking if the array is sorted
            {
                if (numberArray[i - 1] > numberArray[i])
                {
                    b = false;
                    break;
                }
            }
        }
    }
}
