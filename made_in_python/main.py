from enum import Enum
from array import array
from random import randint
from time import time
import sorting_algorithms

class AlgorithmTypes(Enum):
    BUILT_IN = 0
    BOGO_SORT = 1
    BOZO_SORT = 2
    SOOTAGE_SORT = 3
    BUBBLE_SORT = 4
    GNOME_SORT = 5
    COCKTAIL_SHAKER_SORT = 6
    INSERTSION_SORT = 7
    SELECTION_SORT = 8
    SHELL_SORT = 9
    MERGE_SORT = 10
    QUICK_SORT = 11

class Main:
    def main():
        algorithm_type: AlgorithmTypes
        algorithm_type_selection: str = input("\nSorting algorithms (from slowest to fastest)\n1) Bogo Sort\n2) Bozo Sort\n3) Sootage Sort\n4) Bubble Sort\n5) Gnome Sort\n6) Cocktail Shaker Sort\n7) Insertsion Sort\n8) Selection Sort\n9) Shell Sort\n10) Merge Sort\n11) Quick Sort\nSelect an algorithm: ")

        if algorithm_type_selection == "0" or algorithm_type_selection == "Built In" or algorithm_type_selection == "BuiltIn":
            algorithm_type = AlgorithmTypes.BUILT_IN
        elif algorithm_type_selection == "1" or algorithm_type_selection == "Bogo Sort" or algorithm_type_selection == "BogoSort":
            algorithm_type = AlgorithmTypes.BOGO_SORT
        elif algorithm_type_selection == "2" or algorithm_type_selection == "Bozo Sort" or algorithm_type_selection == "BozoSort":
            algorithm_type = AlgorithmTypes.BOZO_SORT
        elif algorithm_type_selection == "3" or algorithm_type_selection == "Sootage Sort" or algorithm_type_selection == "SootageSort":
            algorithm_type = AlgorithmTypes.SOOTAGE_SORT
        elif algorithm_type_selection == "4" or algorithm_type_selection == "Bubble Sort" or algorithm_type_selection == "BubbleSort":
            algorithm_type = AlgorithmTypes.BUBBLE_SORT
        elif algorithm_type_selection == "5" or algorithm_type_selection == "Gnome Sort" or algorithm_type_selection == "GnomeSort":
            algorithm_type = AlgorithmTypes.GNOME_SORT
        elif algorithm_type_selection == "6" or algorithm_type_selection == "Cocktail Shaker Sort" or algorithm_type_selection == "CocktailShaker Sort" or algorithm_type_selection == "CocktailShakerSort" or algorithm_type_selection == "Cocktail Sort" or algorithm_type_selection == "CocktailSort" or algorithm_type_selection == "Shaker Sort" or algorithm_type_selection == "ShakerSort":
            algorithm_type = AlgorithmTypes.COCKTAIL_SHAKER_SORT
        elif algorithm_type_selection == "7" or algorithm_type_selection == "Insertsion Sort" or algorithm_type_selection == "InsertsionSort":
            algorithm_type = AlgorithmTypes.INSERTSION_SORT
        elif algorithm_type_selection == "8" or algorithm_type_selection == "Selection Sort" or algorithm_type_selection == "SelectionSort":
            algorithm_type = AlgorithmTypes.SELECTION_SORT
        elif algorithm_type_selection == "9" or algorithm_type_selection == "Shell Sort" or algorithm_type_selection == "ShellSort":
            algorithm_type = AlgorithmTypes.SHELL_SORT
        elif algorithm_type_selection == "10" or algorithm_type_selection == "Merge Sort" or algorithm_type_selection == "MergeSort":
            algorithm_type = AlgorithmTypes.MERGE_SORT
        elif algorithm_type_selection == "11" or algorithm_type_selection == "Quick Sort" or algorithm_type_selection == "QuickSort":
            algorithm_type = AlgorithmTypes.QUICK_SORT
        else:
            print("Couldn't understand the input. Aborting.")
            return

        match algorithm_type:
            case AlgorithmTypes.BUILT_IN:
                print("Enter the array size (Python's built in sorter is fast. 12345678 recommended): ", end="")

            case AlgorithmTypes.BOGO_SORT | AlgorithmTypes.BOZO_SORT | AlgorithmTypes.SOOTAGE_SORT | AlgorithmTypes.BUBBLE_SORT | AlgorithmTypes.GNOME_SORT | AlgorithmTypes.COCKTAIL_SHAKER_SORT | AlgorithmTypes.INSERTSION_SORT | AlgorithmTypes.SELECTION_SORT | AlgorithmTypes.SHELL_SORT | AlgorithmTypes.MERGE_SORT | AlgorithmTypes.QUICK_SORT:
                print("Enter the array size (No recommendation becuz python is slow): ", end="")

            case _:
                print("The algorithm type could not found. Aborting.")
                return

        length: int

        try:
            length = int(input())
        except:
            print("Wrong input. Aborting.")
            return

        try:
            the_array = array('i', (0 for i in range(length)))
        except:
            print("The array size cannot be " + str(length) + ". Aborting.")
            return

        print("Starting to randomize the array.")

        for i in range(len(the_array)): # Python's integer is 64 bit. Because of that I made the randomizer like this.
            the_array[i] = randint(0, 2147483647 - 1) # -1 because the endpoint is included

        print("The array has randomized.")
        start_time: float
        end_time: float
        print("Starting to sort the array.")

        match algorithm_type:
            case AlgorithmTypes.BUILT_IN:
                start_time = time()
                the_array = sorted(the_array)
                end_time = time()

            case AlgorithmTypes.BOGO_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.bogo_sort(the_array)
                end_time = time()

            case AlgorithmTypes.BOZO_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.bozo_sort(the_array)
                end_time = time()

            case AlgorithmTypes.SOOTAGE_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.sootage_sort(the_array, 0, len(the_array) - 1)
                end_time = time()

            case AlgorithmTypes.BUBBLE_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.bubble_sort(the_array)
                end_time = time()

            case AlgorithmTypes.GNOME_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.gnome_sort(the_array)
                end_time = time()

            case AlgorithmTypes.COCKTAIL_SHAKER_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.cocktail_shaker_sort(the_array)
                end_time = time()

            case AlgorithmTypes.INSERTSION_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.insertsion_sort(the_array)
                end_time = time()

            case AlgorithmTypes.SELECTION_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.selection_sort(the_array)
                end_time = time()

            case AlgorithmTypes.SHELL_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.shell_sort(the_array)
                end_time = time()

            case AlgorithmTypes.MERGE_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.merge_sort(the_array)
                end_time = time()

            case AlgorithmTypes.QUICK_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.quick_sort(the_array, 0, len(the_array) - 1)
                end_time = time()

            case _:
                print("The algorithm type could not found. Aborting.")
                return

        #print("[" + ", ".join(str(x) for x in the_array) + "]") # To see the array
        print((str)(len(the_array)) + " integers has been sorted in " + (str)((end_time - start_time) * 1000) + " milliseconds.")

    if __name__ == "__main__":
        main()
