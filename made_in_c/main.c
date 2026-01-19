#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include "sorting_algorithms.h"

int main(void)
{
    srand(time(NULL));

    int n = (rand() % 1000) + 1;

    printf("Array length generated as %d\n", n);

    int nums[n];

    printf("Initial Array:\n");

    for (int i = 0; i < n; i++)
    {
        nums[i] = rand() % 2500;

        printf("%d ", nums[i]);
    }

    printf("\n");

    int a;
    char buf[1024];

    enum SortingAlgorithm {
        BUBBLE_SORT,
        GNOME_SORT,
        INSERTION_SORT,
        SELECTION_SORT
        /* TODO: ADD MORE SORTING ALGORITHMS HERE */
    };

    enum SortingAlgorithm choice;

    do
    {
        printf("Select a sorting algorithm\n");
        printf("1) Bubble Sort\n");
        printf("2) Gnome Sort\n");
        printf("3) Insertion Sort\n");
        printf("4) Selection Sort\n");

        if (!fgets(buf, sizeof(buf), stdin))
        {
            return 1;
        }

        a = atoi(buf);
    } while (a < 1 || a > 4);

    choice = --a;

    switch (choice)
    {
        case BUBBLE_SORT:
            bubble_sort(nums, n);
            break;
        case GNOME_SORT:
            gnome_sort(nums, n);
            break;
        case INSERTION_SORT:
            insertion_sort(nums, n);
            break;
        case SELECTION_SORT:
            selection_sort(nums, n);
            break;
    }

    printf("Sorted Array:\n");

    print_array(nums, n);

    return 0;
}
