namespace MadeInCSharp;

public static class SortingAlgorithms
{
    public static bool isSorted(int[] numArr) // To check if the array is sorted
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
                (numArr[++i], numArr[j]) = (numArr[j], numArr[i]); // This means i += 1; int temp = numArr[i]; numArr[i] = numArr[j]; numArr[j] = temp;
            }
        }

        (numArr[++i], numArr[end]) = (numArr[end], numArr[i]); // This means i += 1; int temp = numArr[i]; numArr[i] = numArr[end]; numArr[end] = temp;
        return i; // Swapped the initial pivot with the new pivot and returning the new pivot
    }

    public static void MergeSort(int[] numArr)
    {
        if (numArr.Length < 2)
        {
            return;
        }

        int middle = numArr.Length / 2;
        int[] leftArr = new int[middle], rightArr = new int[numArr.Length - middle];
        Array.Copy(numArr, leftArr, middle); // Copying the numArr's first half to the leftArr
        Array.Copy(numArr, middle, rightArr, 0, numArr.Length - middle); // Copying the numArr's second half to the rightArr
        MergeSort(leftArr);
        MergeSort(rightArr);
        Merge(numArr, leftArr, rightArr);
    }

    static void Merge(int[] numArr, int[] leftArr, int[] rightArr) // This is for Merge Sort
    {
        int j = 0, k = 0;

		for (int i = 0; i < numArr.Length; i++)
        {
		    if (j >= leftArr.Length)
            {
		        numArr[i] = rightArr[k++]; // This means numArr[i] = rightArr[k]; k += 1;
		    }
            else if (k >= rightArr.Length)
            {
		        numArr[i] = leftArr[j++]; // This means numArr[i] = leftArr[j]; j += 1;
		    }
            else
            {
		        if (leftArr[j] < rightArr[k])
                {
		            numArr[i] = leftArr[j++]; // This means numArr[i] = leftArr[j]; j += 1;
		        }
                else
                {
		            numArr[i] = rightArr[k++]; // This means numArr[i] = rightArr[k]; k += 1;
		        }
		    }
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
        /* In Insertsion Sort; the program checks at the array multiple times part by part as first 2 elements,
        first 3 elements, first 4 ... and all of the elements. In each checking, the program goes through each
        part starting from the second to last element of the part and goes to the first element. If the element
        that the program is checking is bigger than the last element of the part, it moves the last element of
        the part in front of the element that the program is checking. The sorting process ends when all of the
        elements are checked. */

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
        /* In Selection Sort, the program goes through the array and looks for the smallest element. When the
        array ends, it swaps the smallest element with the first element. Then it goes through the array again
        and looks for the second smallest element. When the array ends, it swaps the second smallest element
        with the second element and the process goes on like that until the array is sorted. */

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
        /* You can think Cocktail Shaker Sort as a double sided Bubble Sort. Cocktail Shaker Sort starts from
        the left side and moves to right like Bubble Sort but when it reaches the end, it moves to left. So the
        Cocktail Shaker Sort moves back and forth and swaps the elements if the left element is bigger than the
        right element. While swapping the elements, the smaller elements move to the left side and the bigger
        elements move to the right side. */

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
        /* In Bubble Sort, the program goes through the array and checks the elements and the elements next to
        it. If the left element is bigger than the right element, the program swaps the elements. When the
        array ends, if the array is not sorted, the program repeats this process until the array is sorted. */

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
        }
        while (swapped);
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

        if (end - start > 1) // This means if (array size > 2)
        {
            int oneThird = (end - start + 1) / 3;
            SootageSort(numArr, start, end - oneThird);
            SootageSort(numArr, start + oneThird, end);
            SootageSort(numArr, start, end - oneThird);
        }
    }

    public static void BozoSort(int[] numArr)
    {
        /* In Bozo Sort; firstly, the program checks if the array is sorted. If not, it selects two random
        items and swaps them. Then, it checks again if the array is sorted. The program repeates this process
        until the array is sorted. */

        bool b = isSorted(numArr);
        int index1, index2;
        Random r = new Random();

        while (!b)
        {
            do
            {
                index1 = r.Next(numArr.Length);
                index2 = r.Next(numArr.Length);
            }
            while (index1 == index2);

            (numArr[index1], numArr[index2]) = (numArr[index2], numArr[index1]); // Swapping elements
            b = isSorted(numArr);
        }
    }

    public static void BogoSort(int[] numArr)
    {
        /* In Bogo Sort; firstly, the program checks if the array is sorted. If not, it shuffels the array and
        checks again if the array is sorted. The program repeates this process until the array is sorted. */

        bool b = isSorted(numArr);
        Random r = new Random();

        while (!b)
        {
            r.Shuffle(numArr);
            b = isSorted(numArr);
        }
    }
}
