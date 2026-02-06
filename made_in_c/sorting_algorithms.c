#include "sorting_algorithms.h"

void print_arr(const int num_arr[], int length) // To print the array
{
    int length_minus_one = length - 1;
    printf("[");

    for (int i = 0; i < length_minus_one; i++)
    {
        printf("%d, ", num_arr[i]);
    }

    printf("%d]\n", num_arr[length_minus_one]);
}

bool is_sorted(const int num_arr[], int length) // To check if the array is sorted
{
    for (int i = 1; i < length; i++)
    {
        if (num_arr[i - 1] > num_arr[i])
        {
            return false;
        }
    }

    return true;
}

void swap(int *a, int *b) // To swap elements using XOR
{
    if (a == b)
    {
        return;
    }

    *a ^= *b;
    *b ^= *a;
    *a ^= *b;
}

int compar(const void *elem1, const void *elem2) // This is for qsort
{
    const int *num1 = elem1, *num2 = elem2;

    return *num1 - *num2;
}

// The algorithms are listed from the fastest to the slowest according to my tests.

// TODO: IMPLEMENT QUICK SORT HERE.

// TODO: IMPLEMENT MERGE SORT HERE.

// TODO: IMPLEMENT SHELL SORT HERE.

void insertion_sort(int num_arr[], int length)
{
    /* In Insertsion Sort; the program checks at the array multiple times part by part as first 2 elements,
    first 3 elements, first 4 ... and all of the elements. In each checking, the program goes through each part
    starting from the second to last element of the part and goes to the first element. If the element that the
    program is checking is bigger than the last element of the part, it moves the last element of the part in
    front of the element that the program is checking. The sorting process ends when all of the elements are
    checked. */

    int temp, j;

    for (int i = 1; i < length; i++)
    {
        temp = num_arr[i];
        j = i - 1;

        while (j >= 0 && num_arr[j] > temp)
        {
            num_arr[j + 1] = num_arr[j];
            j--;
        }

        num_arr[j + 1] = temp;
    }
}

void selection_sort(int num_arr[], int length)
{
    /* In Selection Sort, the program goes through the array and looks for the smallest element. When the array
    ends, it swaps the smallest element with the first element. Then it goes through the array again and looks
    for the second smallest element. When the array ends, it swaps the second smallest element with the second
    element and the process goes on like that until the array is sorted. */

    int length_minus_one = length - 1, j;

    for (int i = 0; i < length_minus_one; i++)
    {
        j = index_of_min(num_arr, length, i);
        swap(&num_arr[i], &num_arr[j]);
    }
}

int index_of_min(const int num_arr[], int length, int start) // This is for Selection Sort
{
    int min = start;

    for (int i = start; i < length; i++)
    {
        if (num_arr[min] > num_arr[i])
        {
            min = i;
        }
    }

    return min;
}

void gnome_sort(int num_arr[], int length)
{
    int i = 1;

    while (i < length)
    {
        if (i > 0 && num_arr[i - 1] > num_arr[i])
        {
            swap(&num_arr[i - 1], &num_arr[i]);
            i--;
        }
        else
        {
            i++;
        }
    }
}

// TODO: IMPLEMENT COCKTAIL SHAKER SORT HERE.

void bubble_sort(int num_arr[], int length)
{
    /* In Bubble Sort, the program goes through the array and checks the elements and the elements next to it.
    If the left element is bigger than the right element, the program swaps the elements. When the array ends,
    if the array is not sorted, the program repeats this process until the array is sorted. */

    bool swapped;

    do
    {
        swapped = false;

        for (int i = 1; i < length; i++)
        {
            if (num_arr[i - 1] > num_arr[i])
            {
                swap(&num_arr[i - 1], &num_arr[i]);
                swapped = true;
            }
        }

        length--; // Every time it restarts, the largest elements moves to the end of the array. So, we don't need to check it again.
    }
    while (swapped);
}

// TODO: IMPLEMENT SOOTAGE SORT HERE.

// TODO: IMPLEMENT BOZO SORT HERE.

// TODO: IMPLEMENT BOGO SORT HERE.
