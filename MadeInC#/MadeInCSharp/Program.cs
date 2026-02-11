using System.Diagnostics;

namespace MadeInCSharp;

class Program
{
    enum AlgorithmTypes
    {
        BuiltIn,
        QuickSort,
        MergeSort,
        ShellSort,
        InsertsionSort,
        SelectionSort,
        GnomeSort,
        CocktailShakerSort,
        BubbleSort,
        SootageSort,
        BozoSort,
        BogoSort,
    }

    static void Main(string[] args)
    {
        AlgorithmTypes algorithmType;
        Console.WriteLine();
        Console.WriteLine("Sorting algorithms (from slowest to fastest)");
        Console.WriteLine("1) Quick Sort");
        Console.WriteLine("2) Merge Sort");
        Console.WriteLine("3) Shell Sort");
        Console.WriteLine("4) Insertsion Sort");
        Console.WriteLine("5) Selection Sort");
        Console.WriteLine("6) Gnome Sort");
        Console.WriteLine("7) Cocktail Shaker Sort");
        Console.WriteLine("8) Bubble Sort");
        Console.WriteLine("9) Sootage Sort");
        Console.WriteLine("10) Bozo Sort");
        Console.WriteLine("11) Bogo Sort");
        Console.Write("Select an algorithm: ");
        int selectedAlgorithm;

        try
        {
            string? inputString = Console.ReadLine();

            if (!string.IsNullOrEmpty(inputString))
            {
                selectedAlgorithm = int.Parse(inputString);
            }
            else
            {
                Console.WriteLine("The input should not be null. Aborting.");
                return;
            }
        }
        catch
        {
            Console.WriteLine("Couldn't understand the input. Aborting.");
            return;
        }

        if (selectedAlgorithm == (int)AlgorithmTypes.BuiltIn)
        {
            algorithmType = AlgorithmTypes.BuiltIn;
        }
        else if (selectedAlgorithm == (int)AlgorithmTypes.QuickSort)
        {
            algorithmType = AlgorithmTypes.QuickSort;
        }
        else if (selectedAlgorithm == (int)AlgorithmTypes.MergeSort)
        {
            algorithmType = AlgorithmTypes.MergeSort;
        }
        else if (selectedAlgorithm == (int)AlgorithmTypes.ShellSort)
        {
            algorithmType = AlgorithmTypes.ShellSort;
        }
        else if (selectedAlgorithm == (int)AlgorithmTypes.InsertsionSort)
        {
            algorithmType = AlgorithmTypes.InsertsionSort;
        }
        else if (selectedAlgorithm == (int)AlgorithmTypes.SelectionSort)
        {
            algorithmType = AlgorithmTypes.SelectionSort;
        }
        else if (selectedAlgorithm == (int)AlgorithmTypes.GnomeSort)
        {
            algorithmType = AlgorithmTypes.GnomeSort;
        }
        else if (selectedAlgorithm == (int)AlgorithmTypes.CocktailShakerSort)
        {
            algorithmType = AlgorithmTypes.CocktailShakerSort;
        }
        else if (selectedAlgorithm == (int)AlgorithmTypes.BubbleSort)
        {
            algorithmType = AlgorithmTypes.BubbleSort;
        }
        else if (selectedAlgorithm == (int)AlgorithmTypes.SootageSort)
        {
            algorithmType = AlgorithmTypes.SootageSort;
        }
        else if (selectedAlgorithm == (int)AlgorithmTypes.BozoSort)
        {
            algorithmType = AlgorithmTypes.BozoSort;
        }
        else if (selectedAlgorithm == (int)AlgorithmTypes.BogoSort)
        {
            algorithmType = AlgorithmTypes.BogoSort;
        }
        else
        {
            Console.WriteLine("Couldn't understand the input. Aborting.");
            return;
        }

        switch (algorithmType)
        {
            case AlgorithmTypes.BuiltIn:
            case AlgorithmTypes.QuickSort:
            case AlgorithmTypes.MergeSort:
            case AlgorithmTypes.ShellSort:
                Console.Write("Enter the array size (12345678 is recommended): ");
                break;

            case AlgorithmTypes.InsertsionSort:
            case AlgorithmTypes.SelectionSort:
            case AlgorithmTypes.GnomeSort:
            case AlgorithmTypes.CocktailShakerSort:
            case AlgorithmTypes.BubbleSort:
                Console.Write("Enter the array size (55555 is recommended): ");
                break;

            case AlgorithmTypes.SootageSort:
                Console.Write("Enter the array size (3223 is recommended): ");
                break;

            case AlgorithmTypes.BozoSort:
            case AlgorithmTypes.BogoSort:
                Console.Write("Enter the array size (maximum 12 is recommended): ");
                break;

            default:
                Console.WriteLine("The algorithm type could not found. Aborting.");
                return;
        }

        int length;
        string? lengthInString = Console.ReadLine();

        try
        {
            if (!string.IsNullOrEmpty(lengthInString))
            {
                length = int.Parse(lengthInString);
            }
            else
            {
                Console.WriteLine("The input should not be null. Aborting.");
                return;
            }
        }
        catch
        {
            Console.WriteLine("Wrong input. Aborting.");
            return;
        }

        int[] numArr;

        try
        {
            numArr = new int[length];
        }
        catch
        {
            Console.WriteLine("The array size cannot be " + length + ". Aborting.");
            return;
        }

        Random r = new Random();
        Stopwatch s = new Stopwatch();
        Console.WriteLine("Starting to randomize the array.");

        for (int i = 0; i < numArr.Length; i++)
        {
            // r.Next() function returns a random integer from 0 to INT_MAX (both 0 and INT_MAX are included).
            // If you want to get a random integer from 0 to X, write like this: r.Next(X);
            // Note: X is not included.
            numArr[i] = r.Next();
        }

        Console.WriteLine("The array has randomized.");
        //Console.WriteLine("[{0}]", string.Join(", ", numArr)); // To see the array before sorting
        string usedAlgorithmType;
        Console.WriteLine("Starting to sort the array.");

        switch (algorithmType)
        {
            case AlgorithmTypes.BuiltIn:
                s.Start();
                Array.Sort(numArr);
                s.Stop();
                usedAlgorithmType = "C#'s built-in sorter";
                break;

            case AlgorithmTypes.QuickSort:
                s.Start();
                SortingAlgorithms.QuickSort(numArr, 0, numArr.Length - 1);
                s.Stop();
                usedAlgorithmType = "Quick Sort";
                break;

            case AlgorithmTypes.MergeSort:
                s.Start();
                SortingAlgorithms.MergeSort(numArr);
                s.Stop();
                usedAlgorithmType = "Merge Sort";
                break;

            case AlgorithmTypes.ShellSort:
                s.Start();
                SortingAlgorithms.ShellSort(numArr);
                s.Stop();
                usedAlgorithmType = "Shell Sort";
                break;

            case AlgorithmTypes.InsertsionSort:
                s.Start();
                SortingAlgorithms.InsertsionSort(numArr);
                s.Stop();
                usedAlgorithmType = "Insertsion Sort";
                break;

            case AlgorithmTypes.SelectionSort:
                s.Start();
                SortingAlgorithms.SelectionSort(numArr);
                s.Stop();
                usedAlgorithmType = "Selection Sort";
                break;

            case AlgorithmTypes.GnomeSort:
                s.Start();
                SortingAlgorithms.GnomeSort(numArr);
                s.Stop();
                usedAlgorithmType = "Gnome Sort";
                break;

            case AlgorithmTypes.CocktailShakerSort:
                s.Start();
                SortingAlgorithms.CocktailShakerSort(numArr);
                s.Stop();
                usedAlgorithmType = "Cocktail Shaker Sort";
                break;

            case AlgorithmTypes.BubbleSort:
                s.Start();
                SortingAlgorithms.BubbleSort(numArr);
                s.Stop();
                usedAlgorithmType = "Bubble Sort";
                break;

            case AlgorithmTypes.SootageSort:
                s.Start();
                SortingAlgorithms.SootageSort(numArr, 0, numArr.Length - 1);
                s.Stop();
                usedAlgorithmType = "Sootage Sort";
                break;

            case AlgorithmTypes.BozoSort:
                s.Start();
                SortingAlgorithms.BozoSort(numArr);
                s.Stop();
                usedAlgorithmType = "Bozo Sort";
                break;

            case AlgorithmTypes.BogoSort:
                s.Start();
                SortingAlgorithms.BogoSort(numArr);
                s.Stop();
                usedAlgorithmType = "Bogo Sort";
                break;

            default:
                Console.WriteLine("The algorithm type could not found. Aborting.");
                return;
        }

        //Console.WriteLine("[{0}]", string.Join(", ", numArr)); // To see the array after sorting

        if (!SortingAlgorithms.isSorted(numArr))
        {
            Console.WriteLine("The sorting algorithm ran but the array is not fully sorted.");
            return;
        }

        Console.WriteLine($"{numArr.Length} random integers has been sorted in {s.Elapsed.TotalNanoseconds / 1000000} milliseconds using {usedAlgorithmType}.");
        Console.WriteLine();
    }
}
