#include "sorting_algorithms.h"
#include <stdio.h>
#include <stdlib.h>

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

int compare(const void *elem1, const void *elem2) // This is for qsort (C's built-in sorter)
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

void bogo_sort(int num_arr[], int length)
{
    while (!is_sorted(num_arr, length))
    {
        fisher_yates_shuffle(num_arr, length);
    }
}

// Fisher-Yates shuffle algorithm for shuffling the array.
void fisher_yates_shuffle(int num_arr[], int length) // This is for Bogo Sort
{
    for (int i = length - 1; i > 0; i--)
    {
        int random_index = rand() % (i + 1);
        swap(&num_arr[i], &num_arr[random_index]);
    }
}
