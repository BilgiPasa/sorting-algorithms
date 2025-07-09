using System.Diagnostics;

namespace CocktailShakerSort;

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
        int left = 0, right = numberArray.Length - 1;

        while (right - left > 1)
        {
            for (int i = left; i < right; i++)
            {
                if (numberArray[i] > numberArray[i + 1])
                {
                    (numberArray[i], numberArray[i + 1]) = (numberArray[i + 1], numberArray[i]); // Swapping elements
                }
            }

            right--;

            for (int i = right; i > left; i--)
            {
                if (numberArray[i - 1] > numberArray[i])
                {
                    (numberArray[i - 1], numberArray[i]) = (numberArray[i], numberArray[i - 1]); // Swapping elements
                }
            }

            left++;
        }
    }
}
