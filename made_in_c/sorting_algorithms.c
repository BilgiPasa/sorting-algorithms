#include <stdio.h>
#include "sorting_algorithms.h"

void swap(int *a, int *b) // Swapping elements using XOR
{
    if (a == b)
    {
        return;
    }

    *a ^= *b;
    *b ^= *a;
    *a ^= *b;
}

bool is_sorted(const int number_array[], int length)
{
    for (int i = 1; i < length; i++)
    {
        if (number_array[i - 1] > number_array[i])
        {
            return false;
        }
    }

    return true;
}

void print_array(const int number_array[], int length)
{
    int length_minus_one = length - 1;
    printf("[");

    for (int i = 0; i < length_minus_one; i++)
    {
        printf("%d, ", number_array[i]);
    }

    printf("%d]\n", number_array[length_minus_one]);
}

// The algorithms are listed from the slowest to the fastest.

// TODO: IMPLEMENT BOGO SORT HERE.

// TODO: IMPLEMENT BOZO SORT HERE.

// TODO: IMPLEMENT SOOTAGE SORT HERE.

void bubble_sort(int number_array[], int length)
{
    /* In Bubble Sort, the program goes through the array and checks the elements and the elements next to
    it. If the left element is bigger than the right element, the program swaps the elements. When the
    array ends, if the array is not sorted, the program repeats this process until the array is sorted. */

    bool swapped;

    do
    {
        swapped = false;

        for (int i = 1; i < length; i++)
        {
            if (number_array[i - 1] > number_array[i])
            {
                swap(&number_array[i - 1], &number_array[i]);
                swapped = true;
            }
        }

        length--; // Every time it restarts, the largest elements moves to the end of the array. So, we don't need to check it again.
    }
    while (swapped);
}

// TODO: IMPLEMENT COCKTAIL SHAKER SORT HERE.

void gnome_sort(int number_array[], int length)
{
    int i = 1;

    while (i < length)
    {
        if (i > 0 && number_array[i - 1] > number_array[i])
        {
            swap(&number_array[i - 1], &number_array[i]);
            i--;
        }
        else
        {
            i++;
        }
    }
}

void insertion_sort(int number_array[], int length)
{
    /* In Insertsion Sort; the program checks at the array multiple times part by part as first 2 elements,
    first 3 elements, first 4 ... and all of the elements. In each checking, the program goes through each
    part starting from the second to last element of the part and goes to the first element. If the element
    that the program is checking is bigger than the last element of the part, it moves the last element of
    the part in front of the element that the program is checking. The sorting process ends when all of the
    elements are checked. */

    int temp, j;

    for (int i = 1; i < length; i++)
    {
        temp = number_array[i];
        j = i - 1;

        while (j >= 0 && number_array[j] > temp)
        {
            number_array[j + 1] = number_array[j];
            j--;
        }

        number_array[j + 1] = temp;
    }
}

void selection_sort(int number_array[], int length)
{
    /* In Selection Sort, the program goes through the array and looks for the smallest element. When the
    array ends, it swaps the smallest element with the first element. Then it goes through the array again
    and looks for the second smallest element. When the array ends, it swaps the second smallest element
    with the second element and the process goes on like that until the array is sorted. */

    int length_minus_one = length - 1, j;

    for (int i = 0; i < length_minus_one - 1; i++)
    {
        j = index_of_min(number_array, length, i);
        swap(&number_array[i], &number_array[j]);
    }
}

int index_of_min(const int number_array[], int length, int start) // This is for Selection Sort
{
    int min = start;

    for (int i = start; i < length; i++)
    {
        if (number_array[min] > number_array[i])
        {
            min = i;
        }
    }

    return min;
}

// TODO: IMPLEMENT SHELL SORT HERE.

// TODO: IMPLEMENT MERGE SORT HERE.

// TODO: IMPLEMENT QUICK SORT HERE.
