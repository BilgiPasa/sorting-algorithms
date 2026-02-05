import java.util.Arrays;
import java.util.Random;
import java.util.Scanner;

public class Main {
    enum AlgorithmTypes {
        BUILT_IN(0),
        QUICK_SORT(1),
        MERGE_SORT(2),
        SHELL_SORT(3),
        INSERTSION_SORT(4),
        SELECTION_SORT(5),
        GNOME_SORT(6),
        COCKTAIL_SHAKER_SORT(7),
        BUBBLE_SORT(8),
        SOOTAGE_SORT(9),
        BOZO_SORT(10),
        BOGO_SORT(11);

        private final int index;

        AlgorithmTypes(int index) {
            this.index = index;
        }

        public int index() {
            return index;
        }
    }

    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);
        AlgorithmTypes algorithmType;
        System.out.println("\nSorting algorithms (from slowest to fastest)");
        System.out.println("1) Quick Sort");
        System.out.println("2) Merge Sort");
        System.out.println("3) Shell Sort");
        System.out.println("4) Insertsion Sort");
        System.out.println("5) Selection Sort");
        System.out.println("6) Gnome Sort");
        System.out.println("7) Cocktail Shaker Sort");
        System.out.println("8) Bubble Sort");
        System.out.println("9) Sootage Sort");
        System.out.println("10) Bozo Sort");
        System.out.println("11) Bogo Sort");
        System.out.print("Select an algorithm: ");
        int selectedAlgorithm;

        try {
            selectedAlgorithm = s.nextInt();
        } catch (Exception e) {
            System.out.println("Couldn't understand the input. Aborting.");
            s.close();
            return;
        }

        if (selectedAlgorithm == AlgorithmTypes.BUILT_IN.index) {
            algorithmType = AlgorithmTypes.BUILT_IN;
        } else if (selectedAlgorithm == AlgorithmTypes.QUICK_SORT.index) {
            algorithmType = AlgorithmTypes.QUICK_SORT;
        } else if (selectedAlgorithm == AlgorithmTypes.MERGE_SORT.index) {
            algorithmType = AlgorithmTypes.MERGE_SORT;
        } else if (selectedAlgorithm == AlgorithmTypes.SHELL_SORT.index) {
            algorithmType = AlgorithmTypes.SHELL_SORT;
        } else if (selectedAlgorithm == AlgorithmTypes.INSERTSION_SORT.index) {
            algorithmType = AlgorithmTypes.INSERTSION_SORT;
        } else if (selectedAlgorithm == AlgorithmTypes.SELECTION_SORT.index) {
            algorithmType = AlgorithmTypes.SELECTION_SORT;
        } else if (selectedAlgorithm == AlgorithmTypes.GNOME_SORT.index) {
            algorithmType = AlgorithmTypes.GNOME_SORT;
        } else if (selectedAlgorithm == AlgorithmTypes.COCKTAIL_SHAKER_SORT.index) {
            algorithmType = AlgorithmTypes.COCKTAIL_SHAKER_SORT;
        } else if (selectedAlgorithm == AlgorithmTypes.BUBBLE_SORT.index) {
            algorithmType = AlgorithmTypes.BUBBLE_SORT;
        } else if (selectedAlgorithm == AlgorithmTypes.SOOTAGE_SORT.index) {
            algorithmType = AlgorithmTypes.SOOTAGE_SORT;
        } else if (selectedAlgorithm == AlgorithmTypes.BOZO_SORT.index) {
            algorithmType = AlgorithmTypes.BOZO_SORT;
        } else if (selectedAlgorithm == AlgorithmTypes.BOGO_SORT.index) {
            algorithmType = AlgorithmTypes.BOGO_SORT;
        } else {
            System.out.println("Couldn't understand the input. Aborting.");
            s.close();
            return;
        }

        switch (algorithmType) {
            case AlgorithmTypes.BUILT_IN:
            case AlgorithmTypes.QUICK_SORT:
            case AlgorithmTypes.MERGE_SORT:
            case AlgorithmTypes.SHELL_SORT:
                System.out.print("Enter the array size (12345678 is recommended): ");
                break;

            case AlgorithmTypes.INSERTSION_SORT:
            case AlgorithmTypes.SELECTION_SORT:
            case AlgorithmTypes.GNOME_SORT:
            case AlgorithmTypes.COCKTAIL_SHAKER_SORT:
            case AlgorithmTypes.BUBBLE_SORT:
                System.out.print("Enter the array size (55555 is recommended): ");
                break;

            case AlgorithmTypes.SOOTAGE_SORT:
                System.out.print("Enter the array size (3223 is recommended): ");
                break;

            case AlgorithmTypes.BOZO_SORT:
            case AlgorithmTypes.BOGO_SORT:
                System.out.print("Enter the array size (maximum 12 is recommended): ");
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
        int[] numArr;

        try {
            numArr = new int[length];
        } catch (Exception e) {
            System.out.println("The array size cannot be " + length + ". Aborting.");
            return;
        }

        Random r = new Random();
        System.out.println("Starting to randomize the array.");

        for (int i = 0; i < numArr.length; i++) {
            numArr[i] = r.nextInt(Integer.MAX_VALUE); // Don't forget to write Integer.MAX_VALUE as the parameter.
        }

        System.out.println("The array has randomized.");
        //System.out.println(Arrays.toString(numArr)); // To see the array before sorting
        long startTime = 0, endTime = 0;
        String usedAlgorithmType;
        System.out.println("Starting to sort the array.");

        switch (algorithmType)
        {
            case AlgorithmTypes.BUILT_IN:
                startTime = System.nanoTime();
                Arrays.sort(numArr);
                endTime = System.nanoTime();
                usedAlgorithmType = "Java's built-in sorter";
                break;

            case AlgorithmTypes.QUICK_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.quickSort(numArr, 0, numArr.length - 1);
                endTime = System.nanoTime();
                usedAlgorithmType = "Quick Sort";
                break;

            case AlgorithmTypes.MERGE_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.mergeSort(numArr);
                endTime = System.nanoTime();
                usedAlgorithmType = "Merge Sort";
                break;

            case AlgorithmTypes.SHELL_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.shellSort(numArr);
                endTime = System.nanoTime();
                usedAlgorithmType = "Shell Sort";
                break;

            case AlgorithmTypes.INSERTSION_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.insertsionSort(numArr);
                endTime = System.nanoTime();
                usedAlgorithmType = "Insertsion Sort";
                break;

            case AlgorithmTypes.SELECTION_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.selectionSort(numArr);
                endTime = System.nanoTime();
                usedAlgorithmType = "Selection Sort";
                break;

            case AlgorithmTypes.GNOME_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.gnomeSort(numArr);
                endTime = System.nanoTime();
                usedAlgorithmType = "Gnome Sort";
                break;

            case AlgorithmTypes.COCKTAIL_SHAKER_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.cocktailShakerSort(numArr);
                endTime = System.nanoTime();
                usedAlgorithmType = "Cocktail Shaker Sort";
                break;

            case AlgorithmTypes.BUBBLE_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.bubbleSort(numArr);
                endTime = System.nanoTime();
                usedAlgorithmType = "Bubble Sort";
                break;

            case AlgorithmTypes.SOOTAGE_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.sootageSort(numArr, 0, numArr.length - 1);
                endTime = System.nanoTime();
                usedAlgorithmType = "Sootage Sort";
                break;

            case AlgorithmTypes.BOZO_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.bozoSort(numArr);
                endTime = System.nanoTime();
                usedAlgorithmType = "Bozo Sort";
                break;

            case AlgorithmTypes.BOGO_SORT:
                startTime = System.nanoTime();
                SortingAlgorithms.bogoSort(numArr);
                endTime = System.nanoTime();
                usedAlgorithmType = "Bogo Sort";
                break;

            default:
                System.out.println("The algorithm type could not found. Aborting.");
                return;
        }

        //System.out.println(Arrays.toString(numArr)); // To see the array after sorting

        if (SortingAlgorithms.isSorted(numArr)) {
            System.out.println(numArr.length + " random integers has been sorted in " + ((endTime - startTime) / 1000000.0) + " milliseconds using " + usedAlgorithmType + ".");
        } else {
            System.out.println("The sorting algorithm ran but the array is not fully sorted.");
        }
    }
}
