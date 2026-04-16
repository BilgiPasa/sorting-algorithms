import java.util.Arrays;
import java.util.Random;
import java.util.Scanner;

public class Main {
    enum AlgorithmTypes {
        BUILT_IN(0),
        QUICK_SORT(1),
        MERGE_SORT(2),
        SHELL_SORT(3),
        INSERTION_SORT(4),
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
        System.out.println();
        System.out.println("Sorting algorithms (from fastest to slowest)");
        System.out.println("1) Quick Sort");
        System.out.println("2) Merge Sort");
        System.out.println("3) Shell Sort");
        System.out.println("4) Insertion Sort");
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

        /* I did not use switch-case to compare integers with the enum indexes
        because of the "case expressions must be constant expressions" warning. */
        if (selectedAlgorithm == AlgorithmTypes.BUILT_IN.index || selectedAlgorithm == AlgorithmTypes.QUICK_SORT.index || selectedAlgorithm == AlgorithmTypes.MERGE_SORT.index || selectedAlgorithm == AlgorithmTypes.SHELL_SORT.index) {
            System.out.print("Enter the array size (22222222 is recommended): ");
        } else if (selectedAlgorithm == AlgorithmTypes.INSERTION_SORT.index || selectedAlgorithm == AlgorithmTypes.SELECTION_SORT.index || selectedAlgorithm == AlgorithmTypes.GNOME_SORT.index || selectedAlgorithm == AlgorithmTypes.COCKTAIL_SHAKER_SORT.index || selectedAlgorithm == AlgorithmTypes.BUBBLE_SORT.index) {
            System.out.print("Enter the array size (123456 is recommended): ");
        } else if (selectedAlgorithm == AlgorithmTypes.SOOTAGE_SORT.index) {
            System.out.print("Enter the array size (4444 is recommended): ");
        } else if (selectedAlgorithm == AlgorithmTypes.BOZO_SORT.index || selectedAlgorithm == AlgorithmTypes.BOGO_SORT.index) {
            System.out.print("Enter the array size (maximum 12 is recommended): ");
        } else {
            System.out.println("Couldn't understand the input. Aborting.");
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

        if (length == 0) {
            System.out.println("Don't make the array size as 0. Aborting.");
            return;
        } else if (length == Integer.MAX_VALUE) {
            System.out.println("Don't make the array size as Integer.MAX_VALUE. Aborting.");
            return;
        } else if (length < 0) {
            System.out.println("Don't try to make the array size as a negative integer. Aborting.");
            return;
        }

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
            // If X is a positive integer, the r.nextInt(X) returns a random number from 0 to X.
            // Note: X is not included.
            numArr[i] = r.nextInt(Integer.MAX_VALUE);
            // Don't forget to write Integer.MAX_VALUE as the parameter.
        }

        System.out.println("The array has randomized.");
        //System.out.println(Arrays.toString(numArr)); // To see the array before sorting
        long startTime = 0, endTime = 0;
        String usedAlgorithmType;
        System.out.println("Starting to sort the array.");

        /* I did not use switch-case to compare integers with the enum indexes
        because of the "case expressions must be constant expressions" warning. */
        if (selectedAlgorithm == AlgorithmTypes.BUILT_IN.index) {
            usedAlgorithmType = "Java's built-in sorter";
            startTime = System.nanoTime();
            Arrays.sort(numArr);
            endTime = System.nanoTime();
        } else if (selectedAlgorithm == AlgorithmTypes.QUICK_SORT.index) {
            usedAlgorithmType = "Quick Sort";
            startTime = System.nanoTime();
            SortingAlgorithms.quickSort(numArr, 0, numArr.length - 1);
            endTime = System.nanoTime();
        } else if (selectedAlgorithm == AlgorithmTypes.MERGE_SORT.index) {
            usedAlgorithmType = "Merge Sort";
            startTime = System.nanoTime();
            SortingAlgorithms.mergeSort(numArr);
            endTime = System.nanoTime();
        } else if (selectedAlgorithm == AlgorithmTypes.SHELL_SORT.index) {
            usedAlgorithmType = "Shell Sort";
            startTime = System.nanoTime();
            SortingAlgorithms.shellSort(numArr);
            endTime = System.nanoTime();
        } else if (selectedAlgorithm == AlgorithmTypes.INSERTION_SORT.index) {
            usedAlgorithmType = "Insertion Sort";
            startTime = System.nanoTime();
            SortingAlgorithms.insertionSort(numArr);
            endTime = System.nanoTime();
        } else if (selectedAlgorithm == AlgorithmTypes.SELECTION_SORT.index) {
            usedAlgorithmType = "Selection Sort";
            startTime = System.nanoTime();
            SortingAlgorithms.selectionSort(numArr);
            endTime = System.nanoTime();
        } else if (selectedAlgorithm == AlgorithmTypes.GNOME_SORT.index) {
            usedAlgorithmType = "Gnome Sort";
            startTime = System.nanoTime();
            SortingAlgorithms.gnomeSort(numArr);
            endTime = System.nanoTime();
        } else if (selectedAlgorithm == AlgorithmTypes.COCKTAIL_SHAKER_SORT.index) {
            usedAlgorithmType = "Cocktail Shaker Sort";
            startTime = System.nanoTime();
            SortingAlgorithms.cocktailShakerSort(numArr);
            endTime = System.nanoTime();
        } else if (selectedAlgorithm == AlgorithmTypes.BUBBLE_SORT.index) {
            usedAlgorithmType = "Bubble Sort";
            startTime = System.nanoTime();
            SortingAlgorithms.bubbleSort(numArr);
            endTime = System.nanoTime();
        } else if (selectedAlgorithm == AlgorithmTypes.SOOTAGE_SORT.index) {
            usedAlgorithmType = "Sootage Sort";
            startTime = System.nanoTime();
            SortingAlgorithms.sootageSort(numArr, 0, numArr.length - 1);
            endTime = System.nanoTime();
        } else if (selectedAlgorithm == AlgorithmTypes.BOZO_SORT.index) {
            usedAlgorithmType = "Bozo Sort";
            startTime = System.nanoTime();
            SortingAlgorithms.bozoSort(numArr);
            endTime = System.nanoTime();
        } else if (selectedAlgorithm == AlgorithmTypes.BOGO_SORT.index) {
            usedAlgorithmType = "Bogo Sort";
            startTime = System.nanoTime();
            SortingAlgorithms.bogoSort(numArr);
            endTime = System.nanoTime();
        } else {
            System.out.println("The 'selectedAlgorithm' variable has a problem. Aborting.");
            return;
        }

        //System.out.println(Arrays.toString(numArr)); // To see the array after sorting

        if (!SortingAlgorithms.isSorted(numArr)) {
            System.out.println("The sorting algorithm ran but the array is not fully sorted.");
            return;
        }

        System.out.println(numArr.length + " random integers has been sorted in " + ((endTime - startTime) / 1000000.0) + " milliseconds using " + usedAlgorithmType + ".");
        System.out.println();
    }
}
