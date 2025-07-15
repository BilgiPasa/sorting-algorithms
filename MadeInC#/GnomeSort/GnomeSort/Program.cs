using System.Diagnostics;

namespace GnomeSort;

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
        int i = 1;
        bool forward = true;

        while (true)
        {
            while (forward)
            {
                if (i == numberArray.Length)
                {
                    return;
                }

                if (numberArray[i - 1] <= numberArray[i])
                {
                    i++;
                }
                else
                {
                    (numberArray[i - 1], numberArray[i]) = (numberArray[i], numberArray[i - 1]); // Swapping elements
                    forward = false;
                    break;
                }
            }

            while (!forward)
            {
                if (i == 1)
                {
                    forward = true;
                    break;
                }

                if (numberArray[i - 1] > numberArray[i])
                {
                    (numberArray[i - 1], numberArray[i]) = (numberArray[i], numberArray[i - 1]); // Swapping elements
                }

                i--;
            }
        }
    }
}
