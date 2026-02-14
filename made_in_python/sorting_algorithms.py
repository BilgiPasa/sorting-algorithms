from random import randint, shuffle
import main

class SortingAlgorithms:
    def is_sorted(num_list: list[int]) -> bool: # To check if the array is sorted
        for i in range(1, len(num_list)):
            if num_list[i - 1] > num_list[i]:
                return False

        return True

    # The algorithms are listed from the fastest to the slowest according to my tests.

    def quick_sort(num_list: list[int], start: int, end: int) -> None:
        if start >= end:
            return

        pivot: int = SortingAlgorithms.move_elements_and_return_pivot(num_list, start, end)
        SortingAlgorithms.quick_sort(num_list, start, pivot - 1)
        SortingAlgorithms.quick_sort(num_list, pivot + 1, end)

    def move_elements_and_return_pivot(num_list: list[int], start: int, end: int) -> int: # This is for Quick Sort
        i: int = start - 1

        for j in range(start, end): # Initial pivot is the last element of the list
            # The program moves the elements that are smaller than the pivot to the left
            if num_list[j] < num_list[end]:
                i += 1
                num_list[i], num_list[j] = num_list[j], num_list[i] # Swapping elements

        i += 1
        num_list[i], num_list[end] = num_list[end], num_list[i] # Swapping elements
        return i # Swapped the initial pivot with the new pivot and returning the new pivot

    def merge_sort(num_list: list[int]) -> None:
        if len(num_list) < 2:
            return

        middle: int = len(num_list) // 2
        i: int
        left_list = [0] * middle
        right_list = [0] * (len(num_list) - middle)

        for i in range(middle):
            left_list[i] = num_list[i]

        for i in range(middle, len(num_list)):
            right_list[i - middle] = num_list[i]

        SortingAlgorithms.merge_sort(left_list)
        SortingAlgorithms.merge_sort(right_list)
        SortingAlgorithms.merge(num_list, left_list, right_list)

    def merge(num_list: list[int], left_list: list[int], right_list: list[int]) -> None: # This is for Merge Sort
        j: int = 0
        k: int = 0

        for i in range(len(num_list)):
            if j >= len(left_list):
                num_list[i] = right_list[k]
                k += 1
            elif k >= len(right_list):
                num_list[i] = left_list[j]
                j += 1
            else:
                if left_list[j] < right_list[k]:
                    num_list[i] = left_list[j]
                    j += 1
                else:
                    num_list[i] = right_list[k]
                    k += 1

    def shell_sort(num_list: list[int]) -> None:
        interval: int = len(num_list) // 2
        temp: int
        j: int

        while interval > 0:
            for i in range(interval, len(num_list)):
                temp = num_list[i]
                j = i

                while j >= interval and num_list[j - interval] > temp:
                    num_list[j] = num_list[j - interval]
                    j -= interval

                num_list[j] = temp
            interval = interval // 2

    def insertsion_sort(num_list: list[int]) -> None:
        temp: int
        j: int

        for i in range(1, len(num_list)):
            temp = num_list[i]
            j = i - 1

            while j >= 0 and num_list[j] > temp:
                num_list[j + 1] = num_list[j]
                j -= 1

            num_list[j + 1] = temp

    def selection_sort(num_list: list[int]) -> None:
        length_minus_one: int = len(num_list) - 1
        j: int

        for i in range(length_minus_one):
            j = SortingAlgorithms.index_of_min(num_list, len(num_list), i)
            num_list[i], num_list[j] = num_list[j], num_list[i] # Swapping elements

    def index_of_min(num_list: list[int], length: int, start: int) -> None: # This is for Selection Sort
        min: int = start

        for i in range(start, length):
            if num_list[min] > num_list[i]:
                min = i

        return min

    def gnome_sort(num_list: list[int]) -> None:
        i: int = 1

        while i < len(num_list):
            if i > 0 and num_list[i - 1] > num_list[i]:
                num_list[i - 1], num_list[i] = num_list[i], num_list[i - 1] # Swapping elements
                i -= 1
            else:
                i += 1

    def cocktail_shaker_sort(num_list: list[int]) -> None:
        start: int = 0
        end: int = len(num_list) - 1
        i: int

        while end - start > 1:
            for i in range(start, end):
                if num_list[i] > num_list[i + 1]:
                    num_list[i], num_list[i + 1] = num_list[i + 1], num_list[i] # Swapping elements

            end -= 1

            for i in range(end, start, -1):
                if num_list[i - 1] > num_list[i]:
                    num_list[i - 1], num_list[i] = num_list[i], num_list[i - 1] # Swapping elements

            start += 1

    def bubble_sort(num_list: list[int]) -> None:
        length: int = len(num_list)
        swapped: bool

        while True:
            swapped = False

            for i in range(1, len(length)):
                if num_list[i - 1] > num_list[i]:
                    num_list[i - 1], num_list[i] = num_list[i], num_list[i - 1] # Swapping elements
                    swapped = True

            length -= 1

            if not swapped:
                break

    def sootage_sort(num_list: list[int], start: int, end: int) -> None:
        if start == end:
            return

        if num_list[start] > num_list[end]:
            num_list[start], num_list[end] = num_list[end], num_list[start] # Swapping elements

        if end - start > 1: # This means if list size > 2
            one_third: int = (end - start + 1) // 3
            SortingAlgorithms.sootage_sort(num_list, start, end - one_third)
            SortingAlgorithms.sootage_sort(num_list, start + one_third, end)
            SortingAlgorithms.sootage_sort(num_list, start, end - one_third)

    def bozo_sort(num_list: list[int]) -> None:
        length_minus_one: int = len(num_list) - 1
        index1: int
        index2: int

        while not SortingAlgorithms.is_sorted(num_list):
            while True:
                index1 = randint(0, length_minus_one)
                index2 = randint(0, length_minus_one)

                if index1 != index2:
                    break

            num_list[index1], num_list[index2] = num_list[index2], num_list[index1] # Swapping elements

    def bogo_sort(num_list: list[int]) -> None:
        while not SortingAlgorithms.is_sorted(num_list):
            shuffle(num_list)

    if __name__ == "__main__":
        main.Main.main()
