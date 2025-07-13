using System.Diagnostics;

namespace RadixSort;

class Program
{
    static void Main(string[] args)
    {
        Random r = new Random();
        Stopwatch s = new Stopwatch();
        int[] theArray = new int[120000];

        for (int i = 0; i < theArray.Length; i++)
        {
            theArray[i] = r.Next(0, int.MaxValue); // Unfortunately, this version works only with non-negative integers.
        }

        s.Start();
        Sort(theArray);
        s.Stop();
        //Console.WriteLine("[{0}]", string.Join(", ", theArray)); // To see the array
        Console.WriteLine($"{theArray.Length} integers sorted in {s.Elapsed.TotalNanoseconds / 1000000} milliseconds");
    }

    static void Sort(int[] numberArray)
    {
        string[] numberStringArray = new string[numberArray.Length];

        for (int i = 0; i < numberArray.Length; i++)
        {
            numberStringArray[i] = numberArray[i].ToString();
        }

        int maxLenght = numberStringArray[0].Length;

        for (int i = 1; i < numberArray.Length; i++)
        {
            if (numberStringArray[i].Length > maxLenght)
            {
                maxLenght = numberStringArray[i].Length;
            }
        }

        for (int i = 0; i < maxLenght; i++)
        {
            int[] counterArray = new int[10];

            for (int j = 0; j < numberArray.Length; j++)
            {
                if (numberStringArray[j].Length >= i + 1)
                {
                    counterArray[numberStringArray[j][numberStringArray[j].Length - 1 - i] - '0']++;
                }
                else
                {
                    counterArray[0]++;
                }
            }

            for (int j = 1; j < 10; j++)
            {
                counterArray[j] += counterArray[j - 1];
            }

            string[] outputArray = new string[numberArray.Length];

            for (int j = numberArray.Length - 1; j >= 0; j--)
            {
                if (numberStringArray[j].Length >= i + 1)
                {
                    outputArray[--counterArray[numberStringArray[j][numberStringArray[j].Length - 1 - i] - '0']] = numberStringArray[j];
                }
                else
                {
                    outputArray[--counterArray[0]] = numberStringArray[j];
                }
            }

            for (int j = 0; j < numberStringArray.Length; j++)
            {
                numberStringArray[j] = outputArray[j];
            }
        }

        for (int i = 0; i < numberArray.Length; i++)
        {
            numberArray[i] = int.Parse(numberStringArray[i]);
        }
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