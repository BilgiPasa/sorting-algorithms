using System.Diagnostics;

namespace CocktailShakerSort;

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
        /* You can think Cocktail Shaker Sort as double sided Bubble Sort. Cocktail Shaker Sort starts from the
        left side and moves to right like Bubble Sort but when it reaches the end, it moves to left. So the
        Cocktail Shaker Sort moves back and forth and swaps the elements if the left element is bigger than the
        right element. While swapping the elements, the smaller elements move to the left side and the bigger
        elements move to the right side. */

        int start = 0, end = numberArray.Length - 1, i;

        while (end - start > 1)
        {
            for (i = start; i < end; i++)
            {
                if (numberArray[i] > numberArray[i + 1])
                {
                    (numberArray[i], numberArray[i + 1]) = (numberArray[i + 1], numberArray[i]); // Swapping elements
                }
            }

            end--;

            for (i = end; i > start; i--)
            {
                if (numberArray[i - 1] > numberArray[i])
                {
                    (numberArray[i - 1], numberArray[i]) = (numberArray[i], numberArray[i - 1]); // Swapping elements
                }
            }

            start++;
        }
    }
}
