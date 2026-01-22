import java.util.Arrays;
import java.util.Random;

public class SortingAlgorithms {
    public static boolean isSorted(int[] numberArray)
    {
        for (int i = 1; i < numberArray.length; i++)
        {
            if (numberArray[i - 1] > numberArray[i])
            {
                return false;
            }
        }

        return true;
    }

    static void swapElements(int[] numberArray, int a, int b) { // To swap elements using XOR
        if (a == b) {
            return;
        }

        numberArray[a] ^= numberArray[b];
        numberArray[b] ^= numberArray[a];
        numberArray[a] ^= numberArray[b];
    }

    // The algorithms are listed from the slowest to the fastest.

    public static void bogoSort(int[] numberArray) {
        /* In Bogo Sort; firstly, the program checks if the array is sorted. If not, it shuffels the array and
        checks again if the array is sorted. The program repeates this process until the array is sorted. */

        boolean b = isSorted(numberArray);

        while (!b) {
            shuffle(numberArray);
            b = isSorted(numberArray);
        }
    }

    // I couldn't find a built in primitive integer array shuffler. So, here is the Fisher-Yates algorithm.
    static void shuffle(int[] numberArray) { // This is for Bogo Sort
        int lengthMinusOne = numberArray.length - 1, randomNumber;
        Random r = new Random();

        for (int i = lengthMinusOne; i > 0; i--) {
            randomNumber = (int)Math.floor(r.nextFloat() * (i + 1));
            swapElements(numberArray, i, randomNumber);
        }
    }

    public static void bozoSort(int[] numberArray) {
        /* In Bozo Sort; firstly, the program checks if the array is sorted. If not, it selects two random
        items and swaps them. Then, it checks again if the array is sorted. The program repeates this process
        until the array is sorted. */

        boolean b = isSorted(numberArray);
        int index1, index2;
        Random r = new Random();

        while (!b) {
            do {
                index1 = r.nextInt(numberArray.length);
                index2 = r.nextInt(numberArray.length);
            }
            while (index1 == index2);

            swapElements(numberArray, index1, index2);
            b = isSorted(numberArray);
        }
    }

    public static void sootageSort(int[] numberArray, int start, int end) {
        if (start == end) {
            return;
        }

        if (numberArray[start] > numberArray[end]) {
            swapElements(numberArray, start, end);
        }

        if (end - start > 1) { // This means if (array size > 2)
            int oneThird = (end - start + 1) / 3;
            sootageSort(numberArray, start, end - oneThird);
            sootageSort(numberArray, start + oneThird, end);
            sootageSort(numberArray, start, end - oneThird);
        }
    }

    public static void bubbleSort(int[] numberArray) {
        /* In Bubble Sort, the program goes through the array and checks the elements and the elements next to
        it. If the left element is bigger than the right element, the program swaps the elements. When the
        array ends, if the array is not sorted, the program repeats this process until the array is sorted. */

        int length = numberArray.length;
        boolean swapped;

        do {
            swapped = false;

            for (int i = 1; i < length; i++) {
                if (numberArray[i - 1] > numberArray[i]) {
                    swapElements(numberArray, i - 1, i);
                    swapped = true;
                }
            }

            length--; // Every time it restarts, the largest elements moves to the end of the array. So, we don't need to check it again.
        }
        while (swapped);
    }

    public static void cocktailShakerSort(int[] numberArray) {
        /* You can think Cocktail Shaker Sort as a double sided Bubble Sort. Cocktail Shaker Sort starts from
        the left side and moves to right like Bubble Sort but when it reaches the end, it moves to left. So the
        Cocktail Shaker Sort moves back and forth and swaps the elements if the left element is bigger than the
        right element. While swapping the elements, the smaller elements move to the left side and the bigger
        elements move to the right side. */

        int start = 0, end = numberArray.length - 1, i;

        while (end - start > 1) {
            for (i = start; i < end; i++) {
                if (numberArray[i] > numberArray[i + 1]) {
                    swapElements(numberArray, i, i + 1);
                }
            }

            end--;

            for (i = end; i > start; i--) {
                if (numberArray[i - 1] > numberArray[i]) {
                    swapElements(numberArray, i - 1, i);
                }
            }

            start++;
        }
    }

    public static void gnomeSort(int[] numberArray) {
        int i = 1;

        while (i < numberArray.length) {
            if (i > 0 && numberArray[i - 1] > numberArray[i]) {
                swapElements(numberArray, i - 1, i);
                i--;
            } else {
                i++;
            }
        }
    }

    public static void insertsionSort(int[] numberArray) {
        /* In Insertsion Sort; the program checks at the array multiple times part by part as first 2 elements,
        first 3 elements, first 4 ... and all of the elements. In each checking, the program goes through each
        part starting from the second to last element of the part and goes to the first element. If the element
        that the program is checking is bigger than the last element of the part, it moves the last element of
        the part in front of the element that the program is checking. The sorting process ends when all of the
        elements are checked. */

        int temp, j;

        for (int i = 1; i < numberArray.length; i++) {
            temp = numberArray[i];
            j = i - 1;

            while (j >= 0 && numberArray[j] > temp) {
                numberArray[j + 1] = numberArray[j];
                j--;
            }

            numberArray[j + 1] = temp;
        }
    }

    public static void selectionSort(int[] numberArray) {
        /* In Selection Sort, the program goes through the array and looks for the smallest element. When the
        array ends, it swaps the smallest element with the first element. Then it goes through the array again
        and looks for the second smallest element. When the array ends, it swaps the second smallest element
        with the second element and the process goes on like that until the array is sorted. */

        int lengthMinusOne = numberArray.length - 1, j;

        for (int i = 0; i < lengthMinusOne; i++) {
            j = indexOfMin(numberArray, numberArray.length, i);
            swapElements(numberArray, i, j);
        }
    }

    static int indexOfMin(int[] numberArray, int length, int start) // This is for Selection Sort
    {
        int min = start;

        for (int i = start; i < length; i++)
        {
            if (numberArray[min] > numberArray[i])
            {
                min = i;
            }
        }

        return min;
    }

    public static void shellSort(int[] numberArray) {
        int temp, j;

        for (int interval = numberArray.length / 2; interval > 0; interval /= 2) {
            for (int i = interval; i < numberArray.length; i++) {
                temp = numberArray[i];

                for (j = i; j >= interval && numberArray[j - interval] > temp; j -= interval) {
                    numberArray[j] = numberArray[j - interval];
                }

                numberArray[j] = temp;
            }
        }
    }

    public static void mergeSort(int[] numberArray) {
        if (numberArray.length < 2) {
            return;
        }

        int middle = numberArray.length / 2;
        int[] leftArray = Arrays.copyOfRange(numberArray, 0, middle); // Copying the numberArray's first half to the leftArray
        int[] rightArray = Arrays.copyOfRange(numberArray, middle, numberArray.length); // Copying the numberArray's second half to the rightArray
        mergeSort(leftArray);
        mergeSort(rightArray);
        merge(numberArray, leftArray, rightArray);
    }

    static void merge(int[] numberArray, int[] leftArray, int[] rightArray) { // This is for Merge Sort
        int j = 0, k = 0;

		for (int i = 0; i < numberArray.length; i++) {
		    if (j >= leftArray.length) {
		        numberArray[i] = rightArray[k++]; // This means numberArray[i] = rightArray[k]; k += 1;
		    } else if (k >= rightArray.length) {
		        numberArray[i] = leftArray[j++]; // This means numberArray[i] = leftArray[j]; j += 1;
		    } else {
		        if (leftArray[j] < rightArray[k]) {
		            numberArray[i] = leftArray[j++]; // This means numberArray[i] = leftArray[j]; j += 1;
		        } else {
		            numberArray[i] = rightArray[k++]; // This means numberArray[i] = rightArray[k]; k += 1;
		        }
		    }
		}
    }

    public static void quickSort(int[] numberArray, int start, int end) {
        if (start >= end) {
            return;
        }

        int pivot = moveElementsAndReturnPivot(numberArray, start, end);
        quickSort(numberArray, start, pivot - 1);
        quickSort(numberArray, pivot + 1, end);
    }

    static int moveElementsAndReturnPivot(int[] numberArray, int start, int end) { // This is for Quick Sort
        int i = start - 1;

        for (int j = start; j < end; j++) { // Initial pivot is the last element of the array
            // The program moves the elements that are smaller than the pivot to the left
            if (numberArray[j] < numberArray[end]) {
                i++;
                swapElements(numberArray, i, j);
            }
        }

        i++;
        swapElements(numberArray, i, end);
        return i; // Swapped the initial pivot with the new pivot and returning the new pivot
    }
}
