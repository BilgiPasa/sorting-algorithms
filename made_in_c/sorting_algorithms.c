#include <stdio.h>
#include <stdbool.h>
#include "sorting_algorithms.h"

void print_array(const int arr[], int n)
{
    for (int i = 0; i < n; i++)
    {
        printf("%d ", arr[i]);
    }

    printf("\n");
}

void swap(int *a, int *b)
{
    int temp = *a;
    *a = *b;
    *b = temp;
}

int index_of_min(const int arr[], int n, int start)
{
    int min = start;

    for (int i = start; i < n; i++)
    {
        if (arr[i] < arr[min])
        {
            min = i;
        }
    }

    return min;
}

void selection_sort(int arr[], int n)
{
    for (int i = 0; i < n - 1; i++)
    {
        int j = index_of_min(arr, n, i);
        swap(&arr[i], &arr[j]);
    }
}

void bubble_sort(int arr[], int n)
{
    bool swapped;

    do
    {
        swapped = false;

        for (int i = 0; i < n - 1; i++)
        {
            if (arr[i] > arr[i + 1])
            {
                swap(&arr[i], &arr[i + 1]);
                swapped = true;
            }
        }

        n--;
    } while (swapped);
}

void insertion_sort(int arr[], int n)
{
    for (int i = 1; i < n; i++)
    {
        int temp = arr[i];
        int j = i - 1;

        while (j >= 0 && arr[j] > temp)
        {
            arr[j + 1] = arr[j];
            j--;
        }

        arr[j + 1] = temp;
    }
}
