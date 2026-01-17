#include <stdio.h>
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
