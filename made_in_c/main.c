#include "sorting_algorithms.h"
#include <errno.h>
#include <limits.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>

// RAND_MAX is guaranteed to be at least 32767
#define RAND_MAX_GUARANTEED 32767

int get_int(int *num);

// Note: returning 0 means the procces works as intended, returning 1 means there was a problem when running.
int main(void)
{
    enum AlgorithmTypes
    {
        BUILT_IN,
        INSERTION_SORT,
        SELECTION_SORT,
        GNOME_SORT,
        BUBBLE_SORT,
        BOZO_SORT,
        BOGO_SORT,
        SIZE
    };

    enum AlgorithmTypes algorithm_type;
    printf("\n");
    printf("Sorting algorithms (from slowest to fastest)\n");
    printf("1) Insertion Sort\n");
    printf("2) Selection Sort\n");
    printf("3) Gnome Sort\n");
    printf("4) Bubble Sort\n");
    printf("5) Bozo Sort\n");
    printf("6) Bogo Sort\n");
    printf("Select an algorithm: ");
    int selected_algorithm;
    int ok = get_int(&selected_algorithm); // The "ok" acts as a boolean.

    if (!ok || selected_algorithm >= SIZE || selected_algorithm < 0)
    {
        fprintf(stderr, "Couldn't understand the input. Aborting.\n");
        return 1;
    }

    algorithm_type = selected_algorithm;

    switch (algorithm_type)
    {
        case BUILT_IN:
            printf("Enter the array size (12345678 is recommended): ");
            break;

        case INSERTION_SORT:
        case SELECTION_SORT:
        case GNOME_SORT:
        case BUBBLE_SORT:
            printf("Enter the array size (55555 is recommended): ");
            break;

        case BOZO_SORT:
        case BOGO_SORT:
            printf("Enter the array size (maximum 12 is recommended): ");
            break;

        default:
            fprintf(stderr, "The algorithm type could not found. Aborting.\n");
            return 1;
    }

    int length;
    ok = get_int(&length);

    if (!ok) // If ok == 0, it gives an error.
    {
        fprintf(stderr, "Couldn't understand the input. Aborting.\n");
        return 1;
    }

    if (length <= 0)
    {
        fprintf(stderr, "Don't make the array size as 0 or less. Aborting.\n");
        return 1;
    }
    
    // if length > SIZE_MAX / sizeof(int)
    // then length * sizeof(int) > SIZE_MAX
    // which means size overflow will occur
    if ((size_t) length > SIZE_MAX / sizeof(int))
    {
        fprintf(stderr, "Given length causes size overflow. Aborting.\n");
        return 1;
    }

    int *num_arr = malloc(length * sizeof(int));

    if (!num_arr)
    {
        fprintf(stderr, "Memory allocation for array has failed. Aborting.\n");
        return 1;
    }

    printf("Starting to randomize the array.\n");
    srand((unsigned int)time(NULL));

    for (int i = 0; i < length; i++)
    {
        // rand() function returns a random integer from 0 to RAND_MAX (both 0 and RAND_MAX are included).
        // In Linux, RAND_MAX is INT_MAX. In Windows, RAND_MAX is RAND_MAX_GUARANTEED (32767).
        // If you want to get a random integer from 0 to X, write like this: num_arr[i] = rand() % X;
        // Note: X is not included.
        num_arr[i] = rand();
    }

    printf("The array has randomized.\n");
    //print_arr(num_arr, length); // To see the array before sorting
    clock_t start, end;
    const char *used_algorithm_type;
    printf("Starting to sort the array.\n");

    switch (algorithm_type)
    {
        case BUILT_IN:
            start = clock();
            qsort(num_arr, length, sizeof(int), compare);
            end = clock();
            used_algorithm_type = "C's built-in sorter";
            break;

        case INSERTION_SORT:
            start = clock();
            insertion_sort(num_arr, length);
            end = clock();
            used_algorithm_type = "Insertion Sort";
            break;

        case SELECTION_SORT:
            start = clock();
            selection_sort(num_arr, length);
            end = clock();
            used_algorithm_type = "Selection Sort";
            break;

        case GNOME_SORT:
            start = clock();
            gnome_sort(num_arr, length);
            end = clock();
            used_algorithm_type = "Gnome Sort";
            break;

        case BUBBLE_SORT:
            start = clock();
            bubble_sort(num_arr, length);
            end = clock();
            used_algorithm_type = "Bubble Sort";
            break;


        case BOZO_SORT:
            // In Linux, RAND_MAX is INT_MAX. In Windows, RAND_MAX is RAND_MAX_GUARANTEED (32767).
            // Because of that, don't enter a number greater than RAND_MAX_GUARANTEED (which you shouldn't anyways).
            if (length > RAND_MAX_GUARANTEED)
            {
                fprintf(stderr, "You should not enter a number greater than %d in this Bogo Sort. Aborting.\n", RAND_MAX_GUARANTEED);
                free(num_arr); // free before returning
                return 1;
            }

            start = clock();
            bozo_sort(num_arr, length);
            end = clock();
            used_algorithm_type = "Bozo Sort";
            break;

        case BOGO_SORT:
            // In Linux, RAND_MAX is INT_MAX. In Windows, RAND_MAX is RAND_MAX_GUARANTEED (32767).
            // Because of that, don't enter a number greater than RAND_MAX_GUARANTEED (which you shouldn't anyways).
            if (length > RAND_MAX_GUARANTEED)
            {
                fprintf(stderr, "You should not enter a number greater than %d in this Bogo Sort. Aborting.\n", RAND_MAX_GUARANTEED);
                free(num_arr); // free before returning
                return 1;
            }

            start = clock();
            bogo_sort(num_arr, length);
            end = clock();
            used_algorithm_type = "Bogo Sort";
            break;

        default:
            fprintf(stderr, "The algorithm type could not found. Aborting.\n");
            free(num_arr); // free before returning
            return 1;
    }

    //print_arr(num_arr, length); // To see the array after sorting

    if (!is_sorted(num_arr, length))
    {
        fprintf(stderr, "The sorting algorithm ran but the array is not fully sorted.\n");
        free(num_arr); // free before returning
        return 1;
    }

    printf("%d random integers has been sorted in %f milliseconds using %s.\n", length, ((double)(end - start) / CLOCKS_PER_SEC) * 1000, used_algorithm_type);
    printf("\n");
    free(num_arr);
    return 0;
}

/* Because C does not have try-catch, for a safe input system for C, bartu-g made this function. This function
returns 1 on success and 0 on failure. Also, this function is based on beginners' guide away from scanf(). */
int get_int(int *num)
{
    long a;
    char buffer[1024];

    if (!fgets(buffer, sizeof(buffer), stdin)) // If the input reading fails
    {
        return 0;
    }

    if (!strchr(buffer, '\n'))
    {
        // If fgets doesn't cover the whole input, make sure we have empty input buffer before returning.
        int c;
        while ((c = getchar()) != '\n' && c != EOF) { }
        return 0;
    }

    char *ptr_end;
    errno = 0; // reset error number
    a = strtol(buffer, &ptr_end, 10);

    if (errno == ERANGE) // If the input doesn't fit in a long
    {
        return 0;
    }

    if (ptr_end == buffer) // If no character was read
    {
        return 0;
    }

    if (*ptr_end && *ptr_end != '\n') // If the reading doesn't convert the whole input
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
