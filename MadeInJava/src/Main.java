import java.util.Arrays;
import java.util.Random;
import java.util.Scanner;

public class Main {
    enum AlgorithmTypes {
        BUILT_IN,
        BOGO_SORT,
        BOZO_SORT,
        SOOTAGE_SORT,
        BUBBLE_SORT,
        COCKTAIL_SHAKER_SORT,
        GNOME_SORT,
        SELECTION_SORT,
        INSERTSION_SORT,
        SHELL_SORT,
        MERGE_SORT,
        QUICK_SORT
    }

    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);
        AlgorithmTypes algorithmType;
        System.out.println("\nSorting algorithms (from slowest to fastest)");
        System.out.println("1) Bogo Sort");
        System.out.println("2) Bozo Sort");
        System.out.println("3) Sootage Sort");
        System.out.println("4) Bubble Sort");
        System.out.println("5) Cocktail Shaker Sort");
        System.out.println("6) Gnome Sort");
        System.out.println("7) Selection Sort");
        System.out.println("8) Insertsion Sort");
        System.out.println("9) Shell Sort");
        System.out.println("10) Merge Sort");
        System.out.println("11) Quick Sort");
        System.out.print("Select an algorithm: ");
        String algorithmTypeSelection = s.nextLine();

        if (algorithmTypeSelection.equals("0") || algorithmTypeSelection.equals("Built In") || algorithmTypeSelection.equals("BuiltIn") || algorithmTypeSelection.equals("Built-In")) {
            algorithmType = AlgorithmTypes.BUILT_IN;
        } else if (algorithmTypeSelection.equals("1") || algorithmTypeSelection.equals("Bogo Sort") || algorithmTypeSelection.equals("BogoSort")) {
            algorithmType = AlgorithmTypes.BOGO_SORT;
        } else if (algorithmTypeSelection.equals("2") || algorithmTypeSelection.equals("Bozo Sort") || algorithmTypeSelection.equals("BozoSort")) {
            algorithmType = AlgorithmTypes.BOZO_SORT;
        } else if (algorithmTypeSelection.equals("3") || algorithmTypeSelection.equals("Sootage Sort") || algorithmTypeSelection.equals("SootageSort")) {
            algorithmType = AlgorithmTypes.SOOTAGE_SORT;
        } else if (algorithmTypeSelection.equals("4") || algorithmTypeSelection.equals("Bubble Sort") || algorithmTypeSelection.equals("BubbleSort")) {
            algorithmType = AlgorithmTypes.BUBBLE_SORT;
        } else if (algorithmTypeSelection.equals("5") || algorithmTypeSelection.equals("Cocktail Shaker Sort") || algorithmTypeSelection.equals("CocktailShaker Sort") || algorithmTypeSelection.equals("CocktailShakerSort") || algorithmTypeSelection.equals("Cocktail Sort") || algorithmTypeSelection.equals("CocktailSort") || algorithmTypeSelection.equals("Shaker Sort") || algorithmTypeSelection.equals("ShakerSort")) {
            algorithmType = AlgorithmTypes.COCKTAIL_SHAKER_SORT;
        } else if (algorithmTypeSelection.equals("6") || algorithmTypeSelection.equals("Gnome Sort") || algorithmTypeSelection.equals("GnomeSort")) {
            algorithmType = AlgorithmTypes.GNOME_SORT;
        } else if (algorithmTypeSelection.equals("7") || algorithmTypeSelection.equals("Selection Sort") || algorithmTypeSelection.equals("SelectionSort")) {
            algorithmType = AlgorithmTypes.SELECTION_SORT;
        } else if (algorithmTypeSelection.equals("8") || algorithmTypeSelection.equals("Insertsion Sort") || algorithmTypeSelection.equals("InsertsionSort")) {
            algorithmType = AlgorithmTypes.INSERTSION_SORT;
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
            case AlgorithmTypes.BOZO_SORT:
                System.out.print("Enter the array size (maximum 12 is recommended): ");
                break;

            case AlgorithmTypes.SOOTAGE_SORT:
                System.out.print("Enter the array size (3223 is recommended): ");
                break;

            case AlgorithmTypes.BUBBLE_SORT:
            case AlgorithmTypes.COCKTAIL_SHAKER_SORT:
            case AlgorithmTypes.GNOME_SORT:
            case AlgorithmTypes.SELECTION_SORT:
            case AlgorithmTypes.INSERTSION_SORT:
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
        int[] numberArray;

        try {
            numberArray = new int[length];
        } catch (Exception e) {
            System.out.println("The array size cannot be " + length + ". Aborting.");
            return;
        }

        Random r = new Random();
        System.out.println("Starting to randomize the array.");

        for (int i = 0; i < numberArray.length; i++) {
            numberArray[i] = r.nextInt(Integer.MAX_VALUE); // Write this in as the parameter: Integer.MAX_VALUE
        }

        System.out.println("The array has randomized.");
        //System.out.println(Arrays.toString(numberArray)); // To see the array before sorting
        long startTime = 0, endTime = 0;
        String usedAlgorithmType;
        System.out.println("Starting to sort the array.");

        switch (algorithmType)
        {
            case AlgorithmTypes.BUILT_IN:
                startTime = System.nanoTime();
                Arrays.sort(numberArray);
                endTime = System.nanoTime();
                usedAlgorithmType = "Java's built-in sorter";
                break;

            case AlgorithmTypes.BOGO_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.bogoSort(numberArray);
                endTime = System.nanoTime();
                usedAlgorithmType = "Bogo Sort";
                break;

            case AlgorithmTypes.BOZO_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.bozoSort(numberArray);
                endTime = System.nanoTime();
                usedAlgorithmType = "Bozo Sort";
                break;

            case AlgorithmTypes.SOOTAGE_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.sootageSort(numberArray, 0, numberArray.length - 1);
                endTime = System.nanoTime();
                usedAlgorithmType = "Sootage Sort";
                break;

            case AlgorithmTypes.BUBBLE_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.bubbleSort(numberArray);
                endTime = System.nanoTime();
                usedAlgorithmType = "Bubble Sort";
                break;

            case AlgorithmTypes.COCKTAIL_SHAKER_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.cocktailShakerSort(numberArray);
                endTime = System.nanoTime();
                usedAlgorithmType = "Cocktail Shaker Sort";
                break;

            case AlgorithmTypes.GNOME_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.gnomeSort(numberArray);
                endTime = System.nanoTime();
                usedAlgorithmType = "Gnome Sort";
                break;

            case AlgorithmTypes.SELECTION_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.selectionSort(numberArray);
                endTime = System.nanoTime();
                usedAlgorithmType = "Selection Sort";
                break;

            case AlgorithmTypes.INSERTSION_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.insertsionSort(numberArray);
                endTime = System.nanoTime();
                usedAlgorithmType = "Insertsion Sort";
                break;

            case AlgorithmTypes.SHELL_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.shellSort(numberArray);
                endTime = System.nanoTime();
                usedAlgorithmType = "Shell Sort";
                break;

            case AlgorithmTypes.MERGE_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.mergeSort(numberArray);
                endTime = System.nanoTime();
                usedAlgorithmType = "Merge Sort";
                break;

            case AlgorithmTypes.QUICK_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.quickSort(numberArray, 0, numberArray.length - 1);
                endTime = System.nanoTime();
                usedAlgorithmType = "Quick Sort";
                break;

            default:
                System.out.println("The algorithm type could not found. Aborting.");
                return;
        }

        //System.out.println(Arrays.toString(numberArray)); // To see the array after sorting

        if (SortingAlgorithms.isSorted(numberArray)) {
            System.out.println(numberArray.length + " random integers has been sorted in " + ((endTime - startTime) / 1000000.0) + " milliseconds using " + usedAlgorithmType + ".");
        } else {
            System.out.println("The sorting algorithm ran but the array is not fully sorted.");
        }
    }
}
