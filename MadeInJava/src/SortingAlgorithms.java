import java.util.Arrays;
import java.util.Random;

public class SortingAlgorithms {
    public static boolean isSorted(int[] numArr) { // To check if the array is sorted
        for (int i = 1; i < numArr.length; i++) {
            if (numArr[i - 1] > numArr[i]) {
                return false;
            }
        }

        return true;
    }

    static void swapElements(int[] numArr, int a, int b) { // To swap elements using XOR
        if (a == b) {
            return;
        }

        numArr[a] ^= numArr[b];
        numArr[b] ^= numArr[a];
        numArr[a] ^= numArr[b];
    }

    // The algorithms are listed from the fastest to the slowest according to my tests.

    public static void quickSort(int[] numArr, int start, int end) {
        if (start >= end) {
            return;
        }

        int pivot = moveElementsAndReturnPivot(numArr, start, end);
        quickSort(numArr, start, pivot - 1);
        quickSort(numArr, pivot + 1, end);
    }

    static int moveElementsAndReturnPivot(int[] numArr, int start, int end) { // This is for Quick Sort
        int i = start - 1;

        for (int j = start; j < end; j++) { // Initial pivot is the last element of the array
            // The program moves the elements that are smaller than the pivot to the left
            if (numArr[j] < numArr[end]) {
                i++;
                swapElements(numArr, i, j);
            }
        }

        i++;
        swapElements(numArr, i, end);
        return i; // Swapped the initial pivot with the new pivot and returning the new pivot
    }

    public static void mergeSort(int[] numArr) {
        if (numArr.length < 2) {
            return;
        }

        int middle = numArr.length / 2;
        int[] leftArr = Arrays.copyOfRange(numArr, 0, middle); // Copying the numArr's first half to the leftArr
        int[] rightArr = Arrays.copyOfRange(numArr, middle, numArr.length); // Copying the numArr's second half to the rightArr
        mergeSort(leftArr);
        mergeSort(rightArr);
        merge(numArr, leftArr, rightArr);
    }

    static void merge(int[] numArr, int[] leftArr, int[] rightArr) { // This is for Merge Sort
        int j = 0, k = 0;

		for (int i = 0; i < numArr.length; i++) {
		    if (j >= leftArr.length) {
		        numArr[i] = rightArr[k++]; // This means numArr[i] = rightArr[k]; k += 1;
		    } else if (k >= rightArr.length) {
		        numArr[i] = leftArr[j++]; // This means numArr[i] = leftArr[j]; j += 1;
		    } else {
		        if (leftArr[j] < rightArr[k]) {
		            numArr[i] = leftArr[j++]; // This means numArr[i] = leftArr[j]; j += 1;
		        } else {
		            numArr[i] = rightArr[k++]; // This means numArr[i] = rightArr[k]; k += 1;
		        }
		    }
		}
    }

    public static void shellSort(int[] numArr) {
        int temp, j;

        for (int interval = numArr.length / 2; interval > 0; interval /= 2) {
            for (int i = interval; i < numArr.length; i++) {
                temp = numArr[i];

                for (j = i; j >= interval && numArr[j - interval] > temp; j -= interval) {
                    numArr[j] = numArr[j - interval];
                }

                numArr[j] = temp;
            }
        }
    }

    public static void insertsionSort(int[] numArr) {
        int temp, j;

        for (int i = 1; i < numArr.length; i++) {
            temp = numArr[i];
            j = i - 1;

            while (j >= 0 && numArr[j] > temp) {
                numArr[j + 1] = numArr[j];
                j--;
            }

            numArr[j + 1] = temp;
        }
    }

    public static void selectionSort(int[] numArr) {
        int lengthMinusOne = numArr.length - 1, j;

        for (int i = 0; i < lengthMinusOne; i++) {
            j = indexOfMin(numArr, numArr.length, i);
            swapElements(numArr, i, j);
        }
    }

    static int indexOfMin(int[] numArr, int length, int start) { // This is for Selection Sort
        int min = start;

        for (int i = start; i < length; i++) {
            if (numArr[min] > numArr[i]) {
                min = i;
            }
        }

        return min;
    }

    public static void gnomeSort(int[] numArr) {
        int i = 1;

        while (i < numArr.length) {
            if (i > 0 && numArr[i - 1] > numArr[i]) {
                swapElements(numArr, i - 1, i);
                i--;
            } else {
                i++;
            }
        }
    }

    public static void cocktailShakerSort(int[] numArr) {
        int start = 0, end = numArr.length - 1, i;

        while (end - start > 1) {
            for (i = start; i < end; i++) {
                if (numArr[i] > numArr[i + 1]) {
                    swapElements(numArr, i, i + 1);
                }
            }

            end--;

            for (i = end; i > start; i--) {
                if (numArr[i - 1] > numArr[i]) {
                    swapElements(numArr, i - 1, i);
                }
            }

            start++;
        }
    }

    public static void bubbleSort(int[] numArr) {
        int length = numArr.length;
        boolean swapped;

        do {
            swapped = false;

            for (int i = 1; i < length; i++) {
                if (numArr[i - 1] > numArr[i]) {
                    swapElements(numArr, i - 1, i);
                    swapped = true;
                }
            }

            length--; // Every time it restarts, the largest elements moves to the end of the array. So, we don't need to check it again.
        }
        while (swapped);
    }

    public static void sootageSort(int[] numArr, int start, int end) {
        if (start == end) {
            return;
        }

        if (numArr[start] > numArr[end]) {
            swapElements(numArr, start, end);
        }

        if (end - start > 1) { // This means if (array size > 2)
            int oneThird = (end - start + 1) / 3;
            sootageSort(numArr, start, end - oneThird);
            sootageSort(numArr, start + oneThird, end);
            sootageSort(numArr, start, end - oneThird);
        }
    }

    public static void bozoSort(int[] numArr) {
        int index1, index2;
        Random r = new Random();

        while (!isSorted(numArr)) {
            index1 = r.nextInt(numArr.length);
            index2 = r.nextInt(numArr.length);
            swapElements(numArr, index1, index2);
        }
    }

    public static void bogoSort(int[] numArr) {
        while (!isSorted(numArr)) {
            fisherYatesShuffle(numArr);
        }
    }

    // Fisher-Yates shuffle algorithm for shuffling the array.
    static void fisherYatesShuffle(int[] numArr) { // This is for Bogo Sort
        int lengthMinusOne = numArr.length - 1, randomNum;
        Random r = new Random();

        for (int i = lengthMinusOne; i > 0; i--) {
            randomNum = r.nextInt(i + 1);
            swapElements(numArr, i, randomNum);
        }
    }
}
