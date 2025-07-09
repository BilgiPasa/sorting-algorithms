using System.Diagnostics;

namespace BogoSort;

class Program
{
    static void Main(string[] args)
    {
        Random r = new Random();
        Stopwatch s = new Stopwatch();
        int[] theArray = new int[12]; // 12 is enough to show how much BogoSort is bad at sorting.

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
        bool b = true;

        for (int i = 0; i < numberArray.Length - 1; i++)
        {
            if (numberArray[i] > numberArray[i + 1])
            {
                b = false;
                break;
            }
        }

        if (!b)
        {
            Random r = new Random();

            while (!b)
            {
                b = true;
                r.Shuffle(numberArray);

                for (int i = 0; i < numberArray.Length - 1; i++)
                {
                    if (numberArray[i] > numberArray[i + 1])
                    {
                        b = false;
                        break;
                    }
                }
            }
        }
    }
}
