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
        InsertsionSort,
        SelectionSort,
        ShellSort,
        MergeSort,
        QuickSort
    }

    static void Main(string[] args)
    {
        AlgorithmTypes algorithmType;
        Console.Write("\nSorting algorithms (from slowest to fastest)\n1) Bogo Sort\n2) Bozo Sort\n3) Sootage Sort\n4) Bubble Sort\n5) Cocktail Shaker Sort\n6) Gnome Sort\n7) Insertsion Sort\n8) Selection Sort\n9) Shell Sort\n10) Merge Sort\n11) Quick Sort\nSelect an algorithm: ");
        string? algorithmTypeSelection = Console.ReadLine();

        if (!string.IsNullOrEmpty(algorithmTypeSelection))
        {
            if (algorithmTypeSelection.Equals("0") || algorithmTypeSelection.Equals("Built In") || algorithmTypeSelection.Equals("BuiltIn"))
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
            else if (algorithmTypeSelection.Equals("7") || algorithmTypeSelection.Equals("Insertsion Sort") || algorithmTypeSelection.Equals("InsertsionSort"))
            {
                algorithmType = AlgorithmTypes.InsertsionSort;
            }
            else if (algorithmTypeSelection.Equals("8") || algorithmTypeSelection.Equals("Selection Sort") || algorithmTypeSelection.Equals("SelectionSort"))
            {
                algorithmType = AlgorithmTypes.SelectionSort;
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
            case AlgorithmTypes.InsertsionSort:
            case AlgorithmTypes.SelectionSort:
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

        int[] theArray;

        try
        {
            theArray = new int[length];
        }
        catch
        {
            Console.WriteLine("The array size cannot be " + length + ". Aborting.");
            return;
        }

        Random r = new Random();
        Stopwatch s = new Stopwatch();
        Console.WriteLine("Starting to randomize the array.");

        for (int i = 0; i < theArray.Length; i++)
        {
            theArray[i] = r.Next(int.MaxValue);
        }

        Console.WriteLine("The array has randomized.");
        //Console.WriteLine("[{0}]", string.Join(", ", theArray)); // To see the array before sorting
        Console.WriteLine("Starting to sort the array.");

        switch (algorithmType)
        {
            case AlgorithmTypes.BuiltIn:
                s.Start();
                Array.Sort(theArray);
                s.Stop();
                break;

            case AlgorithmTypes.BogoSort:
                s.Start();
                SortingAlgorithms.BogoSort(theArray);
                s.Stop();
                break;

            case AlgorithmTypes.BozoSort:
                s.Start();
                SortingAlgorithms.BozoSort(theArray);
                s.Stop();
                break;

            case AlgorithmTypes.SootageSort:
                s.Start();
                SortingAlgorithms.SootageSort(theArray, 0, theArray.Length - 1);
                s.Stop();
                break;

            case AlgorithmTypes.BubbleSort:
                s.Start();
                SortingAlgorithms.BubbleSort(theArray);
                s.Stop();
                break;

            case AlgorithmTypes.CocktailShakerSort:
                s.Start();
                SortingAlgorithms.CocktailShakerSort(theArray);
                s.Stop();
                break;

            case AlgorithmTypes.GnomeSort:
                s.Start();
                SortingAlgorithms.GnomeSort(theArray);
                s.Stop();
                break;

            case AlgorithmTypes.InsertsionSort:
                s.Start();
                SortingAlgorithms.InsertsionSort(theArray);
                s.Stop();
                break;

            case AlgorithmTypes.SelectionSort:
                s.Start();
                SortingAlgorithms.SelectionSort(theArray);
                s.Stop();
                break;

            case AlgorithmTypes.ShellSort:
                s.Start();
                SortingAlgorithms.ShellSort(theArray);
                s.Stop();
                break;

            case AlgorithmTypes.MergeSort:
                s.Start();
                SortingAlgorithms.MergeSort(theArray);
                s.Stop();
                break;

            case AlgorithmTypes.QuickSort:
                s.Start();
                SortingAlgorithms.QuickSort(theArray, 0, theArray.Length - 1);
                s.Stop();
                break;

            default:
                Console.WriteLine("The algorithm type could not found. Aborting.");
                return;
        }

        //Console.WriteLine("[{0}]", string.Join(", ", theArray)); // To see the array after sorting
        Console.WriteLine($"{theArray.Length} integers has been sorted in {s.Elapsed.TotalNanoseconds / 1000000} milliseconds");
    }
}
