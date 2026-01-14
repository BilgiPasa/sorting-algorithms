import java.util.Random;

public class SortingAlgorithms {
    // The algorithms are listed from the slowest to the fastest.

    public static void bogoSort(int[] numberArray) {
        /* In Bogo Sort; firstly, the program checks if the array is sorted. If not, it shuffels the array and
        checks again if the array is sorted. The program repeates this process until the array is sorted. */

        int i;
        boolean b = true;

        for (i = 1; i < numberArray.length; i++) { // Cheking if the array is sorted
            if (numberArray[i - 1] > numberArray[i]) {
                b = false;
                break;
            }
        }

        if (b) {
            return;
        }

        while (!b) {
            i = 0;
            b = true;

            fisherYatesAlgorithm(numberArray); // For shuffling the array

            for (i = 1; i < numberArray.length; i++) { // Cheking if the array is sorted
                if (numberArray[i - 1] > numberArray[i]) {
                    b = false;
                    break;
                }
            }
        }
    }

    // I couldn't find a built in primitive integer array shuffler. So, here is the Fisher-Yates algorithm.
    static void fisherYatesAlgorithm(int[] numberArray) { // This is for Bogo Sort
        int randomNumber, temp;
        Random r = new Random();

        for (int i = numberArray.length - 1; i > 0; i--) {
            randomNumber = (int)Math.floor(r.nextFloat() * (i + 1));
            temp = numberArray[i];
            numberArray[i] = numberArray[randomNumber];
            numberArray[randomNumber] = temp;
        }
    }

    public static void bozoSort(int[] numberArray) {
        /* In Bozo Sort; firstly, the program checks if the array is sorted. If not, it selects two random
        items and swaps them. Then, it checks again if the array is sorted. The program repeates this process
        until the array is sorted. */

        int i;
        boolean b = true;

        for (i = 1; i < numberArray.length; i++) { // Cheking if the array is sorted
            if (numberArray[i - 1] > numberArray[i]) {
                b = false;
                break;
            }
        }

        if (b) {
            return;
        }

        int index1, index2, temp;
        Random r = new Random();

        while (!b) {
            b = true;

            do {
                index1 = r.nextInt(numberArray.length);
                index2 = r.nextInt(numberArray.length);
            }
            while (index1 == index2);

            temp = numberArray[index1];
            numberArray[index1] = numberArray[index2];
            numberArray[index2] = temp;

            for (i = 1; i < numberArray.length; i++) { // Cheking if the array is sorted
                if (numberArray[i - 1] > numberArray[i]) {
                    b = false;
                    break;
                }
            }
        }
    }

    public static void sootageSort(int[] numberArray, int start, int end) {
        if (start == end) {
            return;
        }

        if (numberArray[start] > numberArray[end]) {
            int temp = numberArray[start];
            numberArray[start] = numberArray[end];
            numberArray[end] = temp;
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

        int i, j, temp;

        do {
            i = 0;

            for (j = 1; j < numberArray.length; j++) {
                if (numberArray[j - 1] > numberArray[j]) {
                    temp = numberArray[j - 1];
                    numberArray[j - 1] = numberArray[j];
                    numberArray[j] = temp;
                    i++;
                }
            }
        }
        while (i > 0);
    }

    public static void gnomeSort(int[] numberArray) {
        /* In Gnome Sort, the program goes through the array from the start and checks the elements and the
        elements next to it. If the left element is bigger than the right element, the program swaps the
        elements and starts to go backwards. While going backwards, if the left element is bigger than the
        right next element, the program swaps the elements. When the program is at the start again, it starts
        to go forward and this process repeates until the program is at the end of the array. */

        int i = 1, temp;
        boolean forward = true;

        while (true) {
            while (forward) {
                if (i == numberArray.length) {
                    return;
                }

                if (numberArray[i - 1] <= numberArray[i]) {
                    i++;
                } else {
                    temp = numberArray[i - 1];
                    numberArray[i - 1] = numberArray[i];
                    numberArray[i] = temp;
                    forward = false;
                    break;
                }
            }

            while (!forward) {
                if (i == 1) {
                    forward = true;
                    break;
                }

                if (numberArray[i - 1] > numberArray[i]) {
                    temp = numberArray[i - 1];
                    numberArray[i - 1] = numberArray[i];
                    numberArray[i] = temp;
                }

                i--;
            }
        }
    }

    public static void cocktailShakerSort(int[] numberArray) {
        /* You can think Cocktail Shaker Sort as a double sided Bubble Sort. Cocktail Shaker Sort starts from
        the left side and moves to right like Bubble Sort but when it reaches the end, it moves to left. So the
        Cocktail Shaker Sort moves back and forth and swaps the elements if the left element is bigger than the
        right element. While swapping the elements, the smaller elements move to the left side and the bigger
        elements move to the right side. */

        int start = 0, end = numberArray.length - 1, i, temp;

        while (end - start > 1) {
            for (i = start; i < end; i++) {
                if (numberArray[i] > numberArray[i + 1]) {
                    temp = numberArray[i];
                    numberArray[i] = numberArray[i + 1];
                    numberArray[i + 1] = temp;
                }
            }

            end--;

            for (i = end; i > start; i--) {
                if (numberArray[i - 1] > numberArray[i]) {
                    temp = numberArray[i - 1];
                    numberArray[i - 1] = numberArray[i];
                    numberArray[i] = temp;
                }
            }

            start++;
        }
    }

    public static void insertsionSort(int[] numberArray) {
        /* In Insertsion Sort; the program checks at the array multiple times part by part as first 2 elements,
        first 3 elements, first 4 ... and all of the elements. In each checking, the program goes through each
        part starting from the second to last element of the part and goes to the first element. If the element
        that the program is checking is bigger than the last element of the part, it moves the last element of
        the part in front of the element that the program is checking. The sorting process ends when all of the
        elements are checked. */

        int temp;

        for (int i = 1; i < numberArray.length; i++) {
            for (int j = i - 1; j >= 0; j--) {
                if (numberArray[i] < numberArray[j]) {
                    temp = numberArray[i];

                    for (int k = i; k > j; k--) { // Shifting the elements 1 to the left
                        numberArray[k] = numberArray[k - 1];
                    }

                    numberArray[j] = temp;
                }
            }
        }
    }

    public static void selectionSort(int[] numberArray) {
        /* In Selection Sort, the program goes through the array and looks for the smallest element. When the
        array ends, it swaps the smallest element with the first element. Then it goes through the array again
        and looks for the second smallest element. When the array ends, it swaps the second smallest element
        with the second element and the process goes on like that until the array is sorted. */

        int smallest, temp;

        for (int i = 0; i < numberArray.length - 1; i++) {
            smallest = i;

            for (int j = i; j < numberArray.length; j++) {
                if (numberArray[smallest] > numberArray[j]) {
                    smallest = j;
                }
            }

            temp = numberArray[i];
            numberArray[i] = numberArray[smallest];
            numberArray[smallest] = temp;
        }
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

        int middle = numberArray.length / 2, i;
        int[] leftArray = new int[middle], rightArray = new int[numberArray.length - middle];

        for (i = 0; i < middle; i++) {
            leftArray[i] = numberArray[i];
        }

        for (i = middle; i < numberArray.length; i++) {
            rightArray[i - middle] = numberArray[i];
        }

        mergeSort(leftArray);
        mergeSort(rightArray);
        merge(numberArray, leftArray, rightArray);
    }

    static void merge(int[] numberArray, int[] leftArray, int[] rightArray) { // This is for Merge Sort
        int i = 0, j = 0, k = 0;

        while (i < leftArray.length && j < rightArray.length) {
            if (leftArray[i] > rightArray[j]) {
                numberArray[k++] = rightArray[j++]; // This means numberArray[k] = rightArray[j]; k += 1; j += 1;
            } else {
                numberArray[k++] = leftArray[i++]; // This means numberArray[k] = leftArray[i]; k += 1; i += 1;
            }
        }

        while (i < leftArray.length) {
            numberArray[k++] = leftArray[i++]; // This means numberArray[k] = leftArray[i]; k += 1; i += 1;
        }

        while (j < rightArray.length) {
            numberArray[k++] = rightArray[j++]; // This means numberArray[k] = rightArray[j]; k += 1; j += 1;
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
        int i = start - 1, temp;

        for (int j = start; j < end; j++) { // Initial pivot is the last element of the array
            // The program moves the elements that are smaller than the pivot to the left
            if (numberArray[j] < numberArray[end]) {
                temp = numberArray[++i]; // This means i += 1; temp = numberArray[i];
                numberArray[i] = numberArray[j];
                numberArray[j] = temp;
            }
        }

        temp = numberArray[++i]; // This means i += 1; temp = numberArray[i];
        numberArray[i] = numberArray[end];
        numberArray[end] = temp;
        return i; // Swapped the initial pivot with the new pivot and returning the new pivot
    }
}
