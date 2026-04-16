#include "sorting_algorithms.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// The input exceptions are handled at the main.c file.
// So, these functions are assuming that the parameter inputs are non-negative integers or integer arrays.

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

int compare(const void *elem1, const void *elem2) // For qsort (C's built-in sorter)
{
    const int *num1 = elem1, *num2 = elem2;
    return *num1 - *num2;
}

// The algorithms are listed from the fastest to the slowest according to my tests.

// TODO: IMPLEMENT QUICK SORT HERE.

// returns 1 on success which is guaranteed unless malloc fails
// returns 0 if memory allocation for temporary array fails
int merge_sort(int num_arr[], int length)
{
    int *temp = malloc(length * sizeof(int)); // Making a new array because we need to store the elements that we want to sort

    if (!temp)
    {
        return 0;
    }

    merge_sort_range(num_arr, temp, 0, length - 1);
    free(temp);
    return 1;
}

void merge_sort_range(int num_arr[], int temp[], int start, int end) // For Merge Sort
{
    if (end <= start) return;

    int mid = start + (end - start) / 2;

    merge_sort_range(num_arr, temp, start, mid);
    merge_sort_range(num_arr, temp, mid + 1, end);

    merge(num_arr, temp, start, mid, end);
}

void merge(int num_arr[], int temp[], int start, int mid, int end) // For Merge Sort
{
    // Copying some part of the num_arr to temp
    memcpy(temp + start, num_arr + start, sizeof(int) * (end - start + 1));

    int i = start, j = mid + 1, k = start;

    // Putting the values in sorted order
    while (i <= mid && j <= end)
    {
        if (temp[i] <= temp[j]) num_arr[k++] = temp[i++]; // num_arr[k] = temp[i]; k += 1; i += 1;
        else                    num_arr[k++] = temp[j++]; // num_arr[k] = temp[j]; k += 1; j += 1;
    }

    // Putting the leftover elements
    while (i <= mid)
        num_arr[k++] = temp[i++]; // num_arr[k] = temp[i]; k += 1; i += 1;

    // Putting the leftover elements
    while (j <= end)
        num_arr[k++] = temp[j++]; // num_arr[k] = temp[j]; k += 1; j += 1;
}

// TODO: IMPLEMENT SHELL SORT HERE.

void insertion_sort(int num_arr[], int length)
{
    int temp, j;

    for (int i = 1; i < length; i++)
    {
        temp = num_arr[i];

        for (j = i; j >= 1 && num_arr[j - 1] > temp; j--)
        {
            num_arr[j] = num_arr[j - 1];
        }

        num_arr[j] = temp;
    }
}

void selection_sort(int num_arr[], int length)
{
    int length_minus_one = length - 1, j;

    for (int i = 0; i < length_minus_one; i++)
    {
        j = index_of_min(num_arr, length, i); // Finding the index that has the minimum value
        swap(&num_arr[i], &num_arr[j]);
    }
}

// Finds the index that has the minimum value in the array.
int index_of_min(const int num_arr[], int length, int start) // For Selection Sort
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
    } while (swapped);
}

// TODO: IMPLEMENT SOOTAGE SORT HERE.

void bozo_sort(int num_arr[], int length)
{
    // Selects 2 random numbers in the array and swaps them until the array is sorted.
    while (!is_sorted(num_arr, length))
    {
        int i = rand() % length;
        int j = rand() % length;
        swap(&num_arr[i], &num_arr[j]);
    }
}

void bogo_sort(int num_arr[], int length)
{
    // Shuffles the whole array until it is sorted.
    while (!is_sorted(num_arr, length))
    {
        fisher_yates_shuffle(num_arr, length);
    }
}

// Fisher-Yates shuffle algorithm
void fisher_yates_shuffle(int num_arr[], int length) // For Bogo Sort
{
    for (int i = length - 1; i > 0; i--)
    {
        int random_index = rand() % (i + 1);
        swap(&num_arr[i], &num_arr[random_index]);
    }
}
