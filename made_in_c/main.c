#include <stdio.h>
#include <stdlib.h>
#include <limits.h>
#include <time.h>
#include "sorting_algorithms.h"

int main(void)
{
    enum AlgorithmTypes {
        BUBBLE_SORT,
        GNOME_SORT,
        INSERTION_SORT,
        SELECTION_SORT
        // TODO: IMPLEMENT MORE ALGORITHMS AND ADD THEM HERE
    };

    enum AlgorithmTypes algorithm_type;
    printf("\nSorting algorithms (from slowest to fastest)\n");
    printf("1) Bubble Sort\n");
    printf("2) Gnome Sort\n");
    printf("3) Insertion Sort\n");
    printf("4) Selection Sort\n");
    printf("Select an algorithm: ");
    char algorithm_type_selection[1024];

    if (!fgets(algorithm_type_selection, sizeof(algorithm_type_selection), stdin))
    {
        return 1;
    }

    int temp = atoi(algorithm_type_selection);

    if (temp > 4 || temp < 1)
    {
        printf("Couldn't understand the input. Aborting.\n");
        return 1;
    }

    algorithm_type = --temp; // This means temp -= 1; algorithm_type = temp;

    switch (algorithm_type)
    {
        case BUBBLE_SORT:
        case GNOME_SORT:
        case INSERTION_SORT:
        case SELECTION_SORT:
            printf("Enter the array size (55555 is recommended): ");
            break;

        default:
            printf("The algorithm type could not found. Aborting.\n");
            return 1;
    }

    int length;
    scanf("%d", &length);

    if (length < 0)
    {
        printf("The array size cannot be %d. Aborting.\n", length);
        return 1;
    }

    int number_array[length];
    printf("Starting to randomize the array.\n");
    srand((unsigned int)time(NULL));

    for (int i = 0; i < length; i++)
    {
        number_array[i] = rand() % INT_MAX; // Write this next to percent sign: INT_MAX
    }

    printf("The array has randomized.\n");
    //print_array(number_array, length); // To see the array before sorting
    printf("Starting to sort the array.\n");

    clock_t start, end;
    
    switch (algorithm_type)
    {
        case BUBBLE_SORT:
            start = clock();
            bubble_sort(number_array, length);
            end = clock();
            break;
        case GNOME_SORT:
            start = clock();
            gnome_sort(number_array, length);
            end = clock();
            break;
        case INSERTION_SORT:
            start = clock();
            insertion_sort(number_array, length);
            end = clock();
            break;
        case SELECTION_SORT:
            start = clock();
            selection_sort(number_array, length);
            end = clock();
            break;
    }

    //print_array(number_array, length); // To see the array after sorting
    if (is_sorted(number_array, length))
    {
        printf("%d integers has been sorted in %f milliseconds.\n", length, ((double) (end - start) / CLOCKS_PER_SEC) * 1000);
    }
    else
    {
        printf("The sorting algorithm ran but the array is not fully sorted.\n");
    }
    
    return 0;
}
