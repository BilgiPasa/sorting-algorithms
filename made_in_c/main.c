#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <errno.h>
#include <limits.h>
#include <time.h>
#include "sorting_algorithms.h"

int get_int(int *num);

int main(void)
{
    enum AlgorithmTypes {
        BUBBLE_SORT,
        GNOME_SORT,
        SELECTION_SORT,
        INSERTION_SORT
        // TODO: IMPLEMENT MORE ALGORITHMS AND ADD THEM HERE.
    };

    enum AlgorithmTypes algorithm_type;
    printf("\nSorting algorithms (from slowest to fastest)\n");
    printf("1) Bubble Sort\n");
    printf("2) Gnome Sort\n");
    printf("3) Selection Sort\n");
    printf("4) Insertion Sort\n");
    printf("Select an algorithm: ");
    int algorithm_type_selection;
    int ok = get_int(&algorithm_type_selection);

    if (!ok || algorithm_type_selection > 4 || algorithm_type_selection < 1)
    {
        fprintf(stderr, "Couldn't understand the input. Aborting.\n");
        return 1;
    }

    algorithm_type = --algorithm_type_selection; // This means algorithm_type_selection -= 1; algorithm_type = algorithm_type_selection;

    switch (algorithm_type)
    {
        case BUBBLE_SORT:
        case GNOME_SORT:
        case SELECTION_SORT:
        case INSERTION_SORT:
            printf("Enter the array size (55555 is recommended): ");
            break;

        default:
            fprintf(stderr, "The algorithm type could not found. Aborting.\n");
            return 1;
    }

    int length;
    ok = get_int(&length);

    if (!ok)
    {
        fprintf(stderr, "Couldn't understand the input. Aborting.\n");
        return 1;
    }

    if (length <= 0)
    {
        fprintf(stderr, "The array size cannot be %d. Aborting.\n", length);
        return 1;
    }

    int number_array[length];
    printf("Starting to randomize the array.\n");
    srand((unsigned int)time(NULL));

    for (int i = 0; i < length; i++)
    {
        number_array[i] = rand(); // rand returns a random integer from 0 to INT_MAX (both 0 and INT_MAX are included)
    }

    printf("The array has randomized.\n");
    //print_array(number_array, length); // To see the array before sorting
    clock_t start, end;
    const char *used_algorithm_type;
    printf("Starting to sort the array.\n");

    switch (algorithm_type)
    {
        case BUBBLE_SORT:
            start = clock();
            bubble_sort(number_array, length);
            end = clock();
            used_algorithm_type = "Bubble Sort";
            break;

        case GNOME_SORT:
            start = clock();
            gnome_sort(number_array, length);
            end = clock();
            used_algorithm_type = "Gnome Sort";
            break;

        case SELECTION_SORT:
            start = clock();
            selection_sort(number_array, length);
            end = clock();
            used_algorithm_type = "Selection Sort";
            break;

        case INSERTION_SORT:
            start = clock();
            insertion_sort(number_array, length);
            end = clock();
            used_algorithm_type = "Insertion Sort";
            break;

        default:
            fprintf(stderr, "The algorithm type could not found. Aborting.\n");
            return 1;
    }

    //print_array(number_array, length); // To see the array after sorting

    if (is_sorted(number_array, length))
    {
        printf("%d random integers has been sorted in %f milliseconds using %s.\n", length, ((double)(end - start) / CLOCKS_PER_SEC) * 1000, used_algorithm_type);
    }
    else
    {
        fprintf(stderr, "The sorting algorithm ran but the array is not fully sorted.\n");
    }

    return 0;
}

// This function returns 1 on success and 0 on failure
// This function is based on beginners' guide away from scanf()
int get_int(int *num)
{
    long a;
    char buffer[1024];

    if (!fgets(buffer, sizeof(buffer), stdin)) // If the input reading failed
    {
        return 0;
    }

    if (!strchr(buffer, '\n'))
    {
        // fgets didn't covered the whole input
        // make sure we have empty input buffer before returning
        int c;
        while ((c = getchar()) != '\n' && c != EOF) { }
        return 0;
    }

    char *end_ptr;
    errno = 0; // reset error number
    a = strtol(buffer, &end_ptr, 10);

    if (errno == ERANGE) // If the input doesn't fit in a long
    {
        return 0;
    }

    if (end_ptr == buffer) // If no character was read
    {
        return 0;
    }

    if (*end_ptr && *end_ptr != '\n') // If the reading doesn't convert the whole input
    {
        return 0;
    }

    if (a > INT_MAX || a < INT_MIN) // If the input doesn't fit in an int
    {
        return 0;
    }

    *num = (int)a;
    return 1;
}
