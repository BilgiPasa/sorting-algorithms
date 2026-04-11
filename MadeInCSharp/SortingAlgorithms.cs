namespace MadeInCSharp;

public static class SortingAlgorithms
{
    // The input exceptions are handled at the Program class.
    // So, these functions are assuming that the parameter inputs are non-negative integers or integer arrays.

    public static bool IsSorted(int[] numArr) // To check if the array is sorted
    {
        for (int i = 1; i < numArr.Length; i++)
        {
            if (numArr[i - 1] > numArr[i])
            {
                return false;
            }
        }

        return true;
    }

    // The algorithms are listed from the fastest to the slowest according to my tests.

    public static void QuickSort(int[] numArr, int start, int end)
    {
        if (start >= end)
        {
            return;
        }

        int pivot = MoveElementsAndReturnPivot(numArr, start, end);
        QuickSort(numArr, start, pivot - 1);
        QuickSort(numArr, pivot + 1, end);
    }

    static int MoveElementsAndReturnPivot(int[] numArr, int start, int end) // This is for Quick Sort
    {
        int i = start - 1;

        for (int j = start; j < end; j++)
        {// Initial pivot is the last element of the array
            // The program moves the elements that are smaller than the pivot to the left
            if (numArr[j] < numArr[end])
            {
                (numArr[++i], numArr[j]) = (numArr[j], numArr[i]); // i += 1; int temp = numArr[i]; numArr[i] = numArr[j]; numArr[j] = temp;
            }
        }

        (numArr[++i], numArr[end]) = (numArr[end], numArr[i]); // i += 1; int temp = numArr[i]; numArr[i] = numArr[end]; numArr[end] = temp;
        return i; // Swapped the initial pivot with the new pivot and returning the new pivot
    }

    public static void MergeSort(int[] numArr) {
        int[] temp = new int[numArr.Length];
        MergeSortRange(numArr, temp, 0, numArr.Length - 1);
    }

    static void MergeSortRange(int[] numArr, int[] temp, int low, int high) { // This is for Merge Sort
        if (high <= low) {
            return;
        }

        int mid = low + (high - low) / 2;
        MergeSortRange(numArr, temp, low, mid);
        MergeSortRange(numArr, temp, mid + 1, high);
        Merge(numArr, temp, low, mid, high);
    }

    static void Merge(int[] numArr, int[] temp, int low, int mid, int high) { // This is for Merge Sort
        int i;

        for (i = low; i <= high; i++) {
            temp[i] = numArr[i];
        }

        int k = i = low; // int k = low; i = low;
        int j = mid + 1;

        while (i <= mid && j <= high) {
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

    public static void ShellSort(int[] numArr)
    {
        int temp, j;

        for (int interval = numArr.Length / 2; interval > 0; interval /= 2)
        {
            for (int i = interval; i < numArr.Length; i++)
            {
                temp = numArr[i];

                for (j = i; j >= interval && numArr[j - interval] > temp; j -= interval)
                {
                    numArr[j] = numArr[j - interval];
                }

                numArr[j] = temp;
            }
        }
    }

    public static void InsertsionSort(int[] numArr)
    {
        int temp, j;

        for (int i = 1; i < numArr.Length; i++)
        {
            temp = numArr[i];
            j = i - 1;

            while (j >= 0 && numArr[j] > temp)
            {
                numArr[j + 1] = numArr[j];
                j--;
            }

            numArr[j + 1] = temp;
        }
    }

    public static void SelectionSort(int[] numArr)
    {
        int lengthMinusOne = numArr.Length - 1, j;

        for (int i = 0; i < lengthMinusOne; i++)
        {
            j = IndexOfMin(numArr, numArr.Length, i);
            (numArr[i], numArr[j]) = (numArr[j], numArr[i]); // Swapping elements
        }
    }

    static int IndexOfMin(int[] numArr, int length, int start) // This is for Selection Sort
    {
        int min = start;

        for (int i = start; i < length; i++)
        {
            if (numArr[min] > numArr[i])
            {
                min = i;
            }
        }

        return min;
    }

    public static void GnomeSort(int[] numArr)
    {
        int i = 1;

        while (i < numArr.Length)
        {
            if (i > 0 && numArr[i - 1] > numArr[i])
            {
                (numArr[i - 1], numArr[i]) = (numArr[i], numArr[i - 1]); // Swapping elements
                i--;
            }
            else
            {
                i++;
            }
        }
    }

    public static void CocktailShakerSort(int[] numArr)
    {
        int start = 0, end = numArr.Length - 1, i;

        while (end - start > 1)
        {
            for (i = start; i < end; i++)
            {
                if (numArr[i] > numArr[i + 1])
                {
                    (numArr[i], numArr[i + 1]) = (numArr[i + 1], numArr[i]); // Swapping elements
                }
            }

            end--;

            for (i = end; i > start; i--)
            {
                if (numArr[i - 1] > numArr[i])
                {
                    (numArr[i - 1], numArr[i]) = (numArr[i], numArr[i - 1]); // Swapping elements
                }
            }

            start++;
        }
    }

    public static void BubbleSort(int[] numArr)
    {
        int length = numArr.Length;
        bool swapped;

        do
        {
            swapped = false;

            for (int i = 1; i < length; i++)
            {
                if (numArr[i - 1] > numArr[i])
                {
                    (numArr[i - 1], numArr[i]) = (numArr[i], numArr[i - 1]); // Swapping elements
                    swapped = true;
                }
            }

            length--; // Every time it restarts, the largest elements moves to the end of the array. So, we don't need to check it again.
        } while (swapped);
    }

    public static void SootageSort(int[] numArr, int start, int end)
    {
        if (start == end)
        {
            return;
        }

        if (numArr[start] > numArr[end])
        {
            (numArr[start], numArr[end]) = (numArr[end], numArr[start]); // Swapping elements
        }

        if (end - start > 1) // if (array size > 2)
        {
            int oneThird = (end - start + 1) / 3;
            SootageSort(numArr, start, end - oneThird);
            SootageSort(numArr, start + oneThird, end);
            SootageSort(numArr, start, end - oneThird);
        }
    }

    public static void BozoSort(int[] numArr)
    {
        int index1, index2;
        Random r = new(); // This is the short version of Random r = new Random();

        while (!IsSorted(numArr))
        {
            index1 = r.Next(numArr.Length);
            index2 = r.Next(numArr.Length);
            (numArr[index1], numArr[index2]) = (numArr[index2], numArr[index1]); // Swapping elements
        }
    }

    public static void BogoSort(int[] numArr)
    {
        Random r = new(); // This is the short version of Random r = new Random();

        while (!IsSorted(numArr))
        {
            r.Shuffle(numArr);
        }
    }
}
