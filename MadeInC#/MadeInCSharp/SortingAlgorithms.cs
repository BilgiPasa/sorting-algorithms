namespace MadeInCSharp;

public static class SortingAlgorithms
{
    public static bool isSorted(int[] numberArray)
    {
        for (int i = 1; i < numberArray.Length; i++)
        {
            if (numberArray[i - 1] > numberArray[i])
            {
                return false;
            }
        }

        return true;
    }

    // The algorithms are listed from the slowest to the fastest.

    public static void BogoSort(int[] numberArray)
    {
        /* In Bogo Sort; firstly, the program checks if the array is sorted. If not, it shuffels the array and
        checks again if the array is sorted. The program repeates this process until the array is sorted. */

        bool b = isSorted(numberArray);
        Random r = new Random();

        while (!b)
        {
            r.Shuffle(numberArray);
            b = isSorted(numberArray);
        }
    }

    public static void BozoSort(int[] numberArray)
    {
        /* In Bozo Sort; firstly, the program checks if the array is sorted. If not, it selects two random
        items and swaps them. Then, it checks again if the array is sorted. The program repeates this process
        until the array is sorted. */

        bool b = isSorted(numberArray);
        int index1, index2;
        Random r = new Random();

        while (!b)
        {
            do
            {
                index1 = r.Next(numberArray.Length);
                index2 = r.Next(numberArray.Length);
            }
            while (index1 == index2);

            (numberArray[index1], numberArray[index2]) = (numberArray[index2], numberArray[index1]); // Swapping elements
            b = isSorted(numberArray);
        }
    }

    public static void SootageSort(int[] numberArray, int start, int end)
    {
        if (start == end)
        {
            return;
        }

        if (numberArray[start] > numberArray[end])
        {
            (numberArray[start], numberArray[end]) = (numberArray[end], numberArray[start]); // Swapping elements
        }

        if (end - start > 1) // This means if (array size > 2)
        {
            int oneThird = (end - start + 1) / 3;
            SootageSort(numberArray, start, end - oneThird);
            SootageSort(numberArray, start + oneThird, end);
            SootageSort(numberArray, start, end - oneThird);
        }
    }

    public static void BubbleSort(int[] numberArray)
    {
        /* In Bubble Sort, the program goes through the array and checks the elements and the elements next to
        it. If the left element is bigger than the right element, the program swaps the elements. When the
        array ends, if the array is not sorted, the program repeats this process until the array is sorted. */

        int length = numberArray.Length;
        bool swapped;

        do
        {
            swapped = false;

            for (int i = 1; i < length; i++)
            {
                if (numberArray[i - 1] > numberArray[i])
                {
                    (numberArray[i - 1], numberArray[i]) = (numberArray[i], numberArray[i - 1]); // Swapping elements
                    swapped = true;
                }
            }

            length--; // Every time it restarts, the largest elements moves to the end of the array. So, we don't need to check it again.
        }
        while (swapped);
    }

    public static void CocktailShakerSort(int[] numberArray)
    {
        /* You can think Cocktail Shaker Sort as a double sided Bubble Sort. Cocktail Shaker Sort starts from
        the left side and moves to right like Bubble Sort but when it reaches the end, it moves to left. So the
        Cocktail Shaker Sort moves back and forth and swaps the elements if the left element is bigger than the
        right element. While swapping the elements, the smaller elements move to the left side and the bigger
        elements move to the right side. */

        int start = 0, end = numberArray.Length - 1, i;

        while (end - start > 1)
        {
            for (i = start; i < end; i++)
            {
                if (numberArray[i] > numberArray[i + 1])
                {
                    (numberArray[i], numberArray[i + 1]) = (numberArray[i + 1], numberArray[i]); // Swapping elements
                }
            }

            end--;

            for (i = end; i > start; i--)
            {
                if (numberArray[i - 1] > numberArray[i])
                {
                    (numberArray[i - 1], numberArray[i]) = (numberArray[i], numberArray[i - 1]); // Swapping elements
                }
            }

            start++;
        }
    }

    public static void GnomeSort(int[] numberArray)
    {
        int i = 1;

        while (i < numberArray.Length)
        {
            if (i > 0 && numberArray[i - 1] > numberArray[i])
            {
                (numberArray[i - 1], numberArray[i]) = (numberArray[i], numberArray[i - 1]); // Swapping elements
                i--;
            }
            else
            {
                i++;
            }
        }
    }

    public static void SelectionSort(int[] numberArray)
    {
        /* In Selection Sort, the program goes through the array and looks for the smallest element. When the
        array ends, it swaps the smallest element with the first element. Then it goes through the array again
        and looks for the second smallest element. When the array ends, it swaps the second smallest element
        with the second element and the process goes on like that until the array is sorted. */

        int lengthMinusOne = numberArray.Length - 1, j;

        for (int i = 0; i < lengthMinusOne; i++)
        {
            j = IndexOfMin(numberArray, numberArray.Length, i);
            (numberArray[i], numberArray[j]) = (numberArray[j], numberArray[i]); // Swapping elements
        }
    }

    static int IndexOfMin(int[] numberArray, int length, int start) // This is for Selection Sort
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

    public static void InsertsionSort(int[] numberArray)
    {
        /* In Insertsion Sort; the program checks at the array multiple times part by part as first 2 elements,
        first 3 elements, first 4 ... and all of the elements. In each checking, the program goes through each
        part starting from the second to last element of the part and goes to the first element. If the element
        that the program is checking is bigger than the last element of the part, it moves the last element of
        the part in front of the element that the program is checking. The sorting process ends when all of the
        elements are checked. */

        int temp, j;

        for (int i = 1; i < numberArray.Length; i++)
        {
            temp = numberArray[i];
            j = i - 1;

            while (j >= 0 && numberArray[j] > temp)
            {
                numberArray[j + 1] = numberArray[j];
                j--;
            }

            numberArray[j + 1] = temp;
        }
    }

    public static void ShellSort(int[] numberArray)
    {
        int temp, j;

        for (int interval = numberArray.Length / 2; interval > 0; interval /= 2)
        {
            for (int i = interval; i < numberArray.Length; i++)
            {
                temp = numberArray[i];

                for (j = i; j >= interval && numberArray[j - interval] > temp; j -= interval)
                {
                    numberArray[j] = numberArray[j - interval];
                }

                numberArray[j] = temp;
            }
        }
    }

    public static void MergeSort(int[] numberArray)
    {
        if (numberArray.Length < 2)
        {
            return;
        }

        int middle = numberArray.Length / 2;
        int[] leftArray = new int[middle], rightArray = new int[numberArray.Length - middle];
        Array.Copy(numberArray, leftArray, middle); // Copying the numberArray's first half to the leftArray
        Array.Copy(numberArray, middle, rightArray, 0, numberArray.Length - middle); // Copying the numberArray's second half to the rightArray
        MergeSort(leftArray);
        MergeSort(rightArray);
        Merge(numberArray, leftArray, rightArray);
    }

    static void Merge(int[] numberArray, int[] leftArray, int[] rightArray) // This is for Merge Sort
    {
        int j = 0, k = 0;

		for (int i = 0; i < numberArray.Length; i++)
        {
		    if (j >= leftArray.Length)
            {
		        numberArray[i] = rightArray[k++]; // This means numberArray[i] = rightArray[k]; k += 1;
		    }
            else if (k >= rightArray.Length)
            {
		        numberArray[i] = leftArray[j++]; // This means numberArray[i] = leftArray[j]; j += 1;
		    }
            else
            {
		        if (leftArray[j] < rightArray[k])
                {
		            numberArray[i] = leftArray[j++]; // This means numberArray[i] = leftArray[j]; j += 1;
		        }
                else
                {
		            numberArray[i] = rightArray[k++]; // This means numberArray[i] = rightArray[k]; k += 1;
		        }
		    }
		}
    }

    public static void QuickSort(int[] numberArray, int start, int end)
    {
        if (start >= end)
        {
            return;
        }

        int pivot = MoveElementsAndReturnPivot(numberArray, start, end);
        QuickSort(numberArray, start, pivot - 1);
        QuickSort(numberArray, pivot + 1, end);
    }

    static int MoveElementsAndReturnPivot(int[] numberArray, int start, int end) // This is for Quick Sort
    {
        int i = start - 1;

        for (int j = start; j < end; j++)
        {// Initial pivot is the last element of the array
            // The program moves the elements that are smaller than the pivot to the left
            if (numberArray[j] < numberArray[end])
            {
                (numberArray[++i], numberArray[j]) = (numberArray[j], numberArray[i]); // This means i += 1; int temp = numberArray[i]; numberArray[i] = numberArray[j]; numberArray[j] = temp;
            }
        }

        (numberArray[++i], numberArray[end]) = (numberArray[end], numberArray[i]); // This means i += 1; int temp = numberArray[i]; numberArray[i] = numberArray[end]; numberArray[end] = temp;
        return i; // Swapped the initial pivot with the new pivot and returning the new pivot
    }
}
