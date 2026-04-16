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
        if (end <= start)
        {
            return;
        }

        int pivot = MoveElementsAndReturnPivot(numArr, start, end);
        QuickSort(numArr, start, pivot - 1);
        QuickSort(numArr, pivot + 1, end);
    }

    static int MoveElementsAndReturnPivot(int[] numArr, int start, int end) // For Quick Sort
    {
        // Note: The initial pivot is the numArr[start] element.

        int i = start, j = end + 1;
        // Initially, i and j are at the points where they shouldn't be. But no problem occurs.
        // Because, we use prefixes in the while loops.

        // Each iteration, the elements that are smaller than or equal to the pivot are moved to the left...
        // ...and the elements that are bigger than the pivot are moved to the right.
        while (true)
        {
            while (numArr[++i] <= numArr[start]) // ++i -> Before this line executes, do i += 1
            {
                if (i == end)
                {
                    break;
                }
            }

            while (numArr[start] < numArr[--j]) // --j -> Before this line executes, do j -= 1
            {
                if (j == start)
                {
                    break;
                }
            }

            if (j <= i)
            {
                break;
            }

            (numArr[i], numArr[j]) = (numArr[j], numArr[i]); // Swapping elements
        }

        // Swapping the initial pivot with the new pivot and returning the new pivot
        (numArr[start], numArr[j]) = (numArr[j], numArr[start]);
        return j;
    }

    public static void MergeSort(int[] numArr)
    {
        int[] temp = new int[numArr.Length]; // Making a new array because we need to store the elements that we want to sort
        MergeSortRange(numArr, temp, 0, numArr.Length - 1);
    }

    static void MergeSortRange(int[] numArr, int[] temp, int start, int end) // For Merge Sort
    {
        if (end <= start)
        {
            return;
        }

        int mid = start + (end - start) / 2;
        MergeSortRange(numArr, temp, start, mid);
        MergeSortRange(numArr, temp, mid + 1, end);
        Merge(numArr, temp, start, mid, end);
    }

    static void Merge(int[] numArr, int[] temp, int start, int mid, int end) // For Merge Sort
    {
        int i;

        // Copying some part of the numArr to temp
        for (i = start; i <= end; i++)
        {
            temp[i] = numArr[i];
        }

        i = start;
        int j = mid + 1, k = start;

        // Putting the values in sorted order
        while (i <= mid && j <= end)
        {
            if (temp[i] <= temp[j])
            {
                numArr[k++] = temp[i++]; // numArr[k] = temp[i]; k += 1; i += 1;
            }
            else
            {
                numArr[k++] = temp[j++]; // numArr[k] = temp[j]; k += 1; j += 1;
            }
        }

        // Putting the leftover elements
        while (i <= mid)
        {
            numArr[k++] = temp[i++]; // numArr[k] = temp[i]; k += 1; i += 1;
        }

        // Putting the leftover elements
        while (j <= mid)
        {
            numArr[k++] = temp[j++]; // numArr[k] = temp[j]; k += 1; j += 1;
        }
    }

    public static void ShellSort(int[] numArr)
    {
        int interval = 1, temp, j;

        // Initializing the interval to 3n + 1 where 3n + 1 is smaller than the array length
        while (interval < numArr.Length / 3)
        {
            interval = (interval * 3) + 1;
        }

        while (interval >= 1)
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

            interval /= 3; // Making the interval smaller
        }
    }

    public static void InsertsionSort(int[] numArr)
    {
        int temp, j;

        for (int i = 1; i < numArr.Length; i++)
        {
            temp = numArr[i];

            for (j = i; j >= 1 && numArr[j - 1] > temp; j--)
            {
                numArr[j] = numArr[j - 1];
            }

            numArr[j] = temp;
        }
    }

    public static void SelectionSort(int[] numArr)
    {
        int lengthMinusOne = numArr.Length - 1, j;

        for (int i = 0; i < lengthMinusOne; i++)
        {
            j = IndexOfMin(numArr, numArr.Length, i); // Finding the index that has the minimum value
            (numArr[i], numArr[j]) = (numArr[j], numArr[i]); // Swapping elements
        }
    }

    // Finds the index that has the minimum value in the array.
    static int IndexOfMin(int[] numArr, int length, int start) // For Selection Sort
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

        // Selects 2 random numbers in the array and swaps them until the array is sorted.
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

        // Shuffles the whole array until it is sorted.
        while (!IsSorted(numArr))
        {
            r.Shuffle(numArr);
        }
    }
}
