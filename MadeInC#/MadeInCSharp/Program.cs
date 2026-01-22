using System.Diagnostics;

namespace MadeInCSharp;

class Program
{
    enum AlgorithmTypes
    {
        BuiltIn,
        BogoSort,
        BozoSort,
        SootageSort,
        BubbleSort,
        CocktailShakerSort,
        GnomeSort,
        SelectionSort,
        InsertsionSort,
        ShellSort,
        MergeSort,
        QuickSort
    }

    static void Main(string[] args)
    {
        AlgorithmTypes algorithmType;
        Console.WriteLine("\nSorting algorithms (from slowest to fastest)");
        Console.WriteLine("1) Bogo Sort");
        Console.WriteLine("2) Bozo Sort");
        Console.WriteLine("3) Sootage Sort");
        Console.WriteLine("4) Bubble Sort");
        Console.WriteLine("5) Cocktail Shaker Sort");
        Console.WriteLine("6) Gnome Sort");
        Console.WriteLine("7) Selection Sort");
        Console.WriteLine("8) Insertsion Sort");
        Console.WriteLine("9) Shell Sort");
        Console.WriteLine("10) Merge Sort");
        Console.WriteLine("11) Quick Sort");
        Console.Write("Select an algorithm: ");
        string? algorithmTypeSelection = Console.ReadLine();

        if (!string.IsNullOrEmpty(algorithmTypeSelection))
        {
            if (algorithmTypeSelection.Equals("0") || algorithmTypeSelection.Equals("Built In") || algorithmTypeSelection.Equals("BuiltIn") || algorithmTypeSelection.Equals("Built-In"))
            {
                algorithmType = AlgorithmTypes.BuiltIn;
            }
            else if (algorithmTypeSelection.Equals("1") || algorithmTypeSelection.Equals("Bogo Sort") || algorithmTypeSelection.Equals("BogoSort"))
            {
                algorithmType = AlgorithmTypes.BogoSort;
            }
            else if (algorithmTypeSelection.Equals("2") || algorithmTypeSelection.Equals("Bozo Sort") || algorithmTypeSelection.Equals("BozoSort"))
            {
                algorithmType = AlgorithmTypes.BozoSort;
            }
            else if (algorithmTypeSelection.Equals("3") || algorithmTypeSelection.Equals("Sootage Sort") || algorithmTypeSelection.Equals("SootageSort"))
            {
                algorithmType = AlgorithmTypes.SootageSort;
            }
            else if (algorithmTypeSelection.Equals("4") || algorithmTypeSelection.Equals("Bubble Sort") || algorithmTypeSelection.Equals("BubbleSort"))
            {
                algorithmType = AlgorithmTypes.BubbleSort;
            }
            else if (algorithmTypeSelection.Equals("5") || algorithmTypeSelection.Equals("Cocktail Shaker Sort") || algorithmTypeSelection.Equals("CocktailShaker Sort") || algorithmTypeSelection.Equals("CocktailShakerSort") || algorithmTypeSelection.Equals("Cocktail Sort") || algorithmTypeSelection.Equals("CocktailSort") || algorithmTypeSelection.Equals("Shaker Sort") || algorithmTypeSelection.Equals("ShakerSort"))
            {
                algorithmType = AlgorithmTypes.CocktailShakerSort;
            }
            else if (algorithmTypeSelection.Equals("6") || algorithmTypeSelection.Equals("Gnome Sort") || algorithmTypeSelection.Equals("GnomeSort"))
            {
                algorithmType = AlgorithmTypes.GnomeSort;
            }
            else if (algorithmTypeSelection.Equals("7") || algorithmTypeSelection.Equals("Selection Sort") || algorithmTypeSelection.Equals("SelectionSort"))
            {
                algorithmType = AlgorithmTypes.SelectionSort;
            }
            else if (algorithmTypeSelection.Equals("8") || algorithmTypeSelection.Equals("Insertsion Sort") || algorithmTypeSelection.Equals("InsertsionSort"))
            {
                algorithmType = AlgorithmTypes.InsertsionSort;
            }
            else if (algorithmTypeSelection.Equals("9") || algorithmTypeSelection.Equals("Shell Sort") || algorithmTypeSelection.Equals("ShellSort"))
            {
                algorithmType = AlgorithmTypes.ShellSort;
            }
            else if (algorithmTypeSelection.Equals("10") || algorithmTypeSelection.Equals("Merge Sort") || algorithmTypeSelection.Equals("MergeSort"))
            {
                algorithmType = AlgorithmTypes.MergeSort;
            }
            else if (algorithmTypeSelection.Equals("11") || algorithmTypeSelection.Equals("Quick Sort") || algorithmTypeSelection.Equals("QuickSort"))
            {
                algorithmType = AlgorithmTypes.QuickSort;
            }
            else
            {
                Console.WriteLine("Couldn't understand the input. Aborting.");
                return;
            }
        }
        else
        {
            Console.WriteLine("The input should not be null. Aborting.");
            return;
        }

        switch (algorithmType)
        {
            case AlgorithmTypes.BogoSort:
            case AlgorithmTypes.BozoSort:
                Console.Write("Enter the array size (maximum 12 is recommended): ");
                break;

            case AlgorithmTypes.SootageSort:
                Console.Write("Enter the array size (3223 is recommended): ");
                break;

            case AlgorithmTypes.BubbleSort:
            case AlgorithmTypes.CocktailShakerSort:
            case AlgorithmTypes.GnomeSort:
            case AlgorithmTypes.SelectionSort:
            case AlgorithmTypes.InsertsionSort:
                Console.Write("Enter the array size (55555 is recommended): ");
                break;

            case AlgorithmTypes.BuiltIn:
            case AlgorithmTypes.ShellSort:
            case AlgorithmTypes.MergeSort:
            case AlgorithmTypes.QuickSort:
                Console.Write("Enter the array size (12345678 is recommended): ");
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

        int[] numberArray;

        try
        {
            numberArray = new int[length];
        }
        catch
        {
            Console.WriteLine("The array size cannot be " + length + ". Aborting.");
            return;
        }

        Random r = new Random();
        Stopwatch s = new Stopwatch();
        Console.WriteLine("Starting to randomize the array.");

        for (int i = 0; i < numberArray.Length; i++)
        {
            numberArray[i] = r.Next(int.MaxValue); // Write this in as the parameter: int.MaxValue
        }

        Console.WriteLine("The array has randomized.");
        //Console.WriteLine("[{0}]", string.Join(", ", numberArray)); // To see the array before sorting
        string usedAlgorithmType;
        Console.WriteLine("Starting to sort the array.");

        switch (algorithmType)
        {
            case AlgorithmTypes.BuiltIn:
                s.Start();
                Array.Sort(numberArray);
                s.Stop();
                usedAlgorithmType = "C#'s built-in sorter";
                break;

            case AlgorithmTypes.BogoSort:
                s.Start();
                SortingAlgorithms.BogoSort(numberArray);
                s.Stop();
                usedAlgorithmType = "Bogo Sort";
                break;

            case AlgorithmTypes.BozoSort:
                s.Start();
                SortingAlgorithms.BozoSort(numberArray);
                s.Stop();
                usedAlgorithmType = "Bozo Sort";
                break;

            case AlgorithmTypes.SootageSort:
                s.Start();
                SortingAlgorithms.SootageSort(numberArray, 0, numberArray.Length - 1);
                s.Stop();
                usedAlgorithmType = "Sootage Sort";
                break;

            case AlgorithmTypes.BubbleSort:
                s.Start();
                SortingAlgorithms.BubbleSort(numberArray);
                s.Stop();
                usedAlgorithmType = "Bubble Sort";
                break;

            case AlgorithmTypes.CocktailShakerSort:
                s.Start();
                SortingAlgorithms.CocktailShakerSort(numberArray);
                s.Stop();
                usedAlgorithmType = "Cocktail Shaker Sort";
                break;

            case AlgorithmTypes.GnomeSort:
                s.Start();
                SortingAlgorithms.GnomeSort(numberArray);
                s.Stop();
                usedAlgorithmType = "Gnome Sort";
                break;

            case AlgorithmTypes.SelectionSort:
                s.Start();
                SortingAlgorithms.SelectionSort(numberArray);
                s.Stop();
                usedAlgorithmType = "Selection Sort";
                break;

            case AlgorithmTypes.InsertsionSort:
                s.Start();
                SortingAlgorithms.InsertsionSort(numberArray);
                s.Stop();
                usedAlgorithmType = "Insertsion Sort";
                break;

            case AlgorithmTypes.ShellSort:
                s.Start();
                SortingAlgorithms.ShellSort(numberArray);
                s.Stop();
                usedAlgorithmType = "Shell Sort";
                break;

            case AlgorithmTypes.MergeSort:
                s.Start();
                SortingAlgorithms.MergeSort(numberArray);
                s.Stop();
                usedAlgorithmType = "Merge Sort";
                break;

            case AlgorithmTypes.QuickSort:
                s.Start();
                SortingAlgorithms.QuickSort(numberArray, 0, numberArray.Length - 1);
                s.Stop();
                usedAlgorithmType = "Quick Sort";
                break;

            default:
                Console.WriteLine("The algorithm type could not found. Aborting.");
                return;
        }

        //Console.WriteLine("[{0}]", string.Join(", ", numberArray)); // To see the array after sorting

        if (SortingAlgorithms.isSorted(numberArray))
        {
            Console.WriteLine($"{numberArray.Length} random integers has been sorted in {s.Elapsed.TotalNanoseconds / 1000000} milliseconds using {usedAlgorithmType}.");
        }
        else
        {
            Console.WriteLine("The sorting algorithm ran but the array is not fully sorted.");
        }
    }
}
