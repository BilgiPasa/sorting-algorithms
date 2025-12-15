import java.util.Scanner;
import java.util.Random;
import java.util.Arrays;

public class Main {
    enum AlgorithmTypes {
        BUILT_IN,
        BOGO_SORT,
        BOZO_SORT,
        SOOTAGE_SORT,
        BUBBLE_SORT,
        GNOME_SORT,
        COCKTAIL_SHAKER_SORT,
        INSERTSION_SORT,
        SELECTION_SORT,
        SHELL_SORT,
        MERGE_SORT,
        QUICK_SORT
    }

    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);
        AlgorithmTypes algorithmType;
        System.out.print("\nSorting algorithms (from slowest to fastest)\n1) Bogo Sort\n2) Bozo Sort\n3) Sootage Sort\n4) Bubble Sort\n5) Gnome Sort\n6) Cocktail Shaker Sort\n7) Insertsion Sort\n8) Selection Sort\n9) Shell Sort\n10) Merge Sort\n11) Quick Sort\nSelect an algorithm: ");
        String algorithmTypeSelection = s.nextLine();

        if (algorithmTypeSelection.equals("0") || algorithmTypeSelection.equals("Built In") || algorithmTypeSelection.equals("BuiltIn")) {
            algorithmType = AlgorithmTypes.BUILT_IN;
        } else if (algorithmTypeSelection.equals("1") || algorithmTypeSelection.equals("Bogo Sort") || algorithmTypeSelection.equals("BogoSort")) {
            algorithmType = AlgorithmTypes.BOGO_SORT;
        } else if (algorithmTypeSelection.equals("2") || algorithmTypeSelection.equals("Bozo Sort") || algorithmTypeSelection.equals("BozoSort")) {
            algorithmType = AlgorithmTypes.BOZO_SORT;
        } else if (algorithmTypeSelection.equals("3") || algorithmTypeSelection.equals("Sootage Sort") || algorithmTypeSelection.equals("SootageSort")) {
            algorithmType = AlgorithmTypes.SOOTAGE_SORT;
        } else if (algorithmTypeSelection.equals("4") || algorithmTypeSelection.equals("Bubble Sort") || algorithmTypeSelection.equals("BubbleSort")) {
            algorithmType = AlgorithmTypes.BUBBLE_SORT;
        } else if (algorithmTypeSelection.equals("5") || algorithmTypeSelection.equals("Gnome Sort") || algorithmTypeSelection.equals("GnomeSort")) {
            algorithmType = AlgorithmTypes.GNOME_SORT;
        } else if (algorithmTypeSelection.equals("6") || algorithmTypeSelection.equals("Cocktail Shaker Sort") || algorithmTypeSelection.equals("CocktailShaker Sort") || algorithmTypeSelection.equals("CocktailShakerSort") || algorithmTypeSelection.equals("Cocktail Sort") || algorithmTypeSelection.equals("CocktailSort") || algorithmTypeSelection.equals("Shaker Sort") || algorithmTypeSelection.equals("ShakerSort")) {
            algorithmType = AlgorithmTypes.COCKTAIL_SHAKER_SORT;
        } else if (algorithmTypeSelection.equals("7") || algorithmTypeSelection.equals("Insertsion Sort") || algorithmTypeSelection.equals("InsertsionSort")) {
            algorithmType = AlgorithmTypes.INSERTSION_SORT;
        } else if (algorithmTypeSelection.equals("8") || algorithmTypeSelection.equals("Selection Sort") || algorithmTypeSelection.equals("SelectionSort")) {
            algorithmType = AlgorithmTypes.SELECTION_SORT;
        } else if (algorithmTypeSelection.equals("9") || algorithmTypeSelection.equals("Shell Sort") || algorithmTypeSelection.equals("ShellSort")) {
            algorithmType = AlgorithmTypes.SHELL_SORT;
        } else if (algorithmTypeSelection.equals("10") || algorithmTypeSelection.equals("Merge Sort") || algorithmTypeSelection.equals("MergeSort")) {
            algorithmType = AlgorithmTypes.MERGE_SORT;
        } else if (algorithmTypeSelection.equals("11") || algorithmTypeSelection.equals("Quick Sort") || algorithmTypeSelection.equals("QuickSort")) {
            algorithmType = AlgorithmTypes.QUICK_SORT;
        } else {
            System.out.println("Couldn't understand the input. Aborting.");
            s.close();
            return;
        }

        switch (algorithmType) {
            case AlgorithmTypes.BOGO_SORT:
                System.out.print("Enter the array size (11 is recommended): ");
                break;

            case AlgorithmTypes.BOZO_SORT:
                System.out.print("Enter the array size (12 is recommended): ");
                break;

            case AlgorithmTypes.SOOTAGE_SORT:
                System.out.print("Enter the array size (4444 is recommended): ");
                break;

            case AlgorithmTypes.BUBBLE_SORT:
            case AlgorithmTypes.GNOME_SORT:
            case AlgorithmTypes.COCKTAIL_SHAKER_SORT:
            case AlgorithmTypes.INSERTSION_SORT:
            case AlgorithmTypes.SELECTION_SORT:
                System.out.print("Enter the array size (55555 is recommended): ");
                break;

            case AlgorithmTypes.BUILT_IN:
            case AlgorithmTypes.SHELL_SORT:
            case AlgorithmTypes.MERGE_SORT:
            case AlgorithmTypes.QUICK_SORT:
                System.out.print("Enter the array size (12345678 is recommended): ");
                break;

            default:
                System.out.println("The algorithm type could not found. Aborting.");
                s.close();
                return;
        }

        int length;

        try {
            length = s.nextInt();
        } catch (Exception e) {
            System.out.println("Wrong input. Aborting.");
            s.close();
            return;
        }

        s.close();
        int[] theArray;

        try {
            theArray = new int[length];
        } catch (Exception e) {
            System.out.println("The array size cannot be " + length + ". Aborting.");
            return;
        }

        Random r = new Random();
        System.out.println("Starting to randomize the array.");

        for (int i = 0; i < theArray.length; i++) {
            theArray[i] = r.nextInt(Integer.MAX_VALUE);
        }

        System.out.println("The array has randomized.");
        long startTime = 0, endTime = 0;
        System.out.println("Starting to sort the array.");

        switch (algorithmType)
        {
            case AlgorithmTypes.BUILT_IN:
                startTime = System.nanoTime();
                Arrays.sort(theArray);
                endTime = System.nanoTime();
                break;

            case AlgorithmTypes.BOGO_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.bogoSort(theArray);
                endTime = System.nanoTime();
                break;

            case AlgorithmTypes.BOZO_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.bozoSort(theArray);
                endTime = System.nanoTime();
                break;

            case AlgorithmTypes.SOOTAGE_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.sootageSort(theArray, 0, theArray.length - 1);
                endTime = System.nanoTime();
                break;

            case AlgorithmTypes.BUBBLE_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.bubbleSort(theArray);
                endTime = System.nanoTime();
                break;

            case AlgorithmTypes.GNOME_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.gnomeSort(theArray);
                endTime = System.nanoTime();
                break;

            case AlgorithmTypes.COCKTAIL_SHAKER_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.cocktailShakerSort(theArray);
                endTime = System.nanoTime();
                break;

            case AlgorithmTypes.INSERTSION_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.insertsionSort(theArray);
                endTime = System.nanoTime();
                break;

            case AlgorithmTypes.SELECTION_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.selectionSort(theArray);
                endTime = System.nanoTime();
                break;

            case AlgorithmTypes.SHELL_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.shellSort(theArray);
                endTime = System.nanoTime();
                break;

            case AlgorithmTypes.MERGE_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.mergeSort(theArray);
                endTime = System.nanoTime();
                break;

            case AlgorithmTypes.QUICK_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.quickSort(theArray, 0, theArray.length - 1);
                endTime = System.nanoTime();
                break;

            default:
                System.out.println("The algorithm type could not found. Aborting.");
                return;
        }

        //System.out.println(Arrays.toString(theArray)); // To see the array
        System.out.println(theArray.length + " integers has been sorted in " + ((endTime - startTime) / 1000000.0) + " milliseconds");
    }
}
