#include <stdbool.h>
#include <stdio.h>
#include "sorting_algorithms.h"

// TODO: ADD A FUNCTION NAMED is_sorted TO CHECK IF THE ARRAY SORTED OR NOT

void print_array(const int number_array[], int length)
{
    printf("[");

    for (int i = 0; i < length; i++)
    {
        printf("%d, ", number_array[i]);
    }

    printf("]\n");
}

void swap(int *a, int *b)
{
    int temp = *a;
    *a = *b;
    *b = temp;
}

// The algorithms are listed from the slowest to the fastest.

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

    int j;

    for (int i = 1; i < length; i++)
    {
        int temp = number_array[i];
        j = i - 1;

        while (j >= 0 && number_array[j] > temp)
        {
            number_array[j + 1] = number_array[j];
            j--;
        }

        number_array[j + 1] = temp;
    }
}

void selection_sort(int arr[], int length)
{
    /* In Selection Sort, the program goes through the array and looks for the smallest element. When the
    array ends, it swaps the smallest element with the first element. Then it goes through the array again
    and looks for the second smallest element. When the array ends, it swaps the second smallest element
    with the second element and the process goes on like that until the array is sorted. */

    int j;

    for (int i = 0; i < length - 1; i++)
    {
        j = index_of_min(arr, length, i);
        swap(&arr[i], &arr[j]);
    }
}

int index_of_min(const int number_array[], int length, int start) // This is for Selection Sort
{
    int min = start;

    for (int i = start; i < length; i++)
    {
        if (number_array[i] < number_array[min])
        {
            min = i;
        }
    }

    return min;
}
