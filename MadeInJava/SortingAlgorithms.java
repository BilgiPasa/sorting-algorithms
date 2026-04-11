import java.util.Random;

public class SortingAlgorithms {
    // The input exceptions are handled at the Main class.
    // So, these functions are assuming that the parameter inputs are non-negative integers or integer arrays.

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
        if (end <= start) {
            return;
        }

        int pivot = moveElementsAndReturnPivot(numArr, start, end);
        quickSort(numArr, start, pivot - 1);
        quickSort(numArr, pivot + 1, end);
    }

    static int moveElementsAndReturnPivot(int[] numArr, int start, int end) { // For Quick Sort
        // Note: The initial pivot is the numArr[start] element.

        int i = start, j = end + 1;
        // Yes, i and j are initially out of bounds but no problem occurs...
        // ...because, we use prefixes in the while loops.

        // Each iteration, the elements that are smaller than or equal to the pivot are moved to the left...
        // ...and the elements that are bigger than the pivot are moved to the right.
        while (true) {
            while (numArr[++i] <= numArr[start]) { // ++i -> Before this line executes, do i += 1
                if (i == end) {
                    break;
                }
            }

            while (numArr[start] < numArr[--j]) { // --j -> Before this line executes, do j -= 1
                if (j == start) {
                    break;
                }
            }

            if (j <= i) {
                break;
            }

            swapElements(numArr, i, j);
        }

        // Swapping the initial pivot with the new pivot and returning the new pivot
        swapElements(numArr, start, j);
        return j;
    }

    public static void mergeSort(int[] numArr) {
        int[] temp = new int[numArr.length];
        mergeSortRange(numArr, temp, 0, numArr.length - 1);
    }

    static void mergeSortRange(int[] numArr, int[] temp, int start, int end) { // For Merge Sort
        if (end <= start) {
            return;
        }

        int mid = start + (end - start) / 2;
        mergeSortRange(numArr, temp, start, mid);
        mergeSortRange(numArr, temp, mid + 1, end);
        merge(numArr, temp, start, mid, end);
    }

    static void merge(int[] numArr, int[] temp, int start, int mid, int end) { // For Merge Sort
        // Copying some part of the numArr to temp
        System.arraycopy(numArr, start, temp, start, (end - start + 1));
        int i = start, j = mid + 1, k = start;

        while (i <= mid && j <= end) {
            if (temp[i] <= temp[j]) {
                numArr[k++] = temp[i++]; // numArr[k] = temp[i]; k += 1; i += 1;
            } else {
                numArr[k++] = temp[j++]; // numArr[k] = temp[j]; k += 1; j += 1;
            }
        }

        while (i <= mid) {
            numArr[k++] = temp[i++]; // numArr[k] = temp[i]; k += 1; i += 1;
        }

        while (j <= mid) {
            numArr[k++] = temp[j++]; // numArr[k] = temp[j]; k += 1; j += 1;
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

    static int indexOfMin(int[] numArr, int length, int start) { // For Selection Sort
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
        } while (swapped);
    }

    public static void sootageSort(int[] numArr, int start, int end) {
        if (start == end) {
            return;
        }

        if (numArr[start] > numArr[end]) {
            swapElements(numArr, start, end);
        }

        if (end - start > 1) { // if (array size > 2)
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

    // Fisher-Yates shuffle algorithm
    static void fisherYatesShuffle(int[] numArr) { // For Bogo Sort
        int lengthMinusOne = numArr.length - 1, randomNum;
        Random r = new Random();

        for (int i = lengthMinusOne; i > 0; i--) {
            randomNum = r.nextInt(i + 1);
            swapElements(numArr, i, randomNum);
        }
    }
}
