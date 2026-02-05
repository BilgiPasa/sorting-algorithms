from random import randint, shuffle
import main

class SortingAlgorithms:
    def is_sorted(num_list) -> bool: # To check if the array is sorted
        for i in range(1, len(num_list)):
            if num_list[i - 1] > num_list[i]:
                return False

        return True

    # The algorithms are listed from the fastest to the slowest according to my tests.

    def quick_sort(num_list, start: int, end: int) -> None:
        if start >= end:
            return

        pivot: int = SortingAlgorithms.move_elements_and_return_pivot(num_list, start, end)
        SortingAlgorithms.quick_sort(num_list, start, pivot - 1)
        SortingAlgorithms.quick_sort(num_list, pivot + 1, end)

    def move_elements_and_return_pivot(num_list, start: int, end: int) -> int: # This is for Quick Sort
        i: int = start - 1

        for j in range(start, end): # Initial pivot is the last element of the list
            # The program moves the elements that are smaller than the pivot to the left
            if num_list[j] < num_list[end]:
                i += 1
                num_list[i], num_list[j] = num_list[j], num_list[i] # Swapping elements

        i += 1
        num_list[i], num_list[end] = num_list[end], num_list[i] # Swapping elements
        return i # Swapped the initial pivot with the new pivot and returning the new pivot

    def merge_sort(num_list) -> None:
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

    def merge(num_list, left_list, right_list) -> None: # This is for Merge Sort
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

    def shell_sort(num_list) -> None:
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

    def insertsion_sort(num_list) -> None:
        """ In Insertsion Sort; the program checks at the list multiple times part by part as first 2
        elements, first 3 elements, first 4 ... and all of the elements. In each checking, the program goes
        through each part starting from the second to last element of the part and goes to the first element.
        If the element that the program is checking is bigger than the last element of the part, it moves the
        last element of the part in front of the element that the program is checking. The sorting process ends
        when all of the elements are checked. """

        temp: int
        j: int

        for i in range(1, len(num_list)):
            temp = num_list[i]
            j = i - 1

            while j >= 0 and num_list[j] > temp:
                num_list[j + 1] = num_list[j]
                j -= 1

            num_list[j + 1] = temp

    def selection_sort(num_list) -> None:
        """ In Selection Sort, the program goes through the list and looks for the smallest element. When the
        list ends, it swaps the smallest element with the first element. Then it goes through the list again
        and looks for the second smallest element. When the list ends, it swaps the second smallest element
        with the second element and the process goes on like that until the list is sorted. """

        length_minus_one: int = len(num_list) - 1
        j: int

        for i in range(length_minus_one):
            j = SortingAlgorithms.index_of_min(num_list, len(num_list), i)
            num_list[i], num_list[j] = num_list[j], num_list[i] # Swapping elements

    def index_of_min(num_list, length: int, start: int) -> None: # This is for Selection Sort
        min: int = start

        for i in range(start, length):
            if num_list[min] > num_list[i]:
                min = i

        return min

    def gnome_sort(num_list) -> None:
        i: int = 1

        while i < len(num_list):
            if i > 0 and num_list[i - 1] > num_list[i]:
                num_list[i - 1], num_list[i] = num_list[i], num_list[i - 1] # Swapping elements
                i -= 1
            else:
                i += 1

    def cocktail_shaker_sort(num_list) -> None:
        """ You can think Cocktail Shaker Sort as a double sided Bubble Sort. Cocktail Shaker Sort starts from
        the left side and moves to right like Bubble Sort but when it reaches the end, it moves to left. So the
        Cocktail Shaker Sort moves back and forth and swaps the elements if the left element is bigger than the
        right element. While swapping the elements, the smaller elements move to the left side and the bigger
        elements move to the right side. """

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

    def bubble_sort(num_list) -> None:
        """ In Bubble Sort, the program goes through the list and checks the elements and the elements next
        to it. If the left element is bigger than the right element, the program swaps the elements. When the
        list ends, if the list is not sorted, the program repeats this process until the list is sorted. """

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

    def sootage_sort(num_list, start: int, end: int) -> None:
        if start == end:
            return

        if num_list[start] > num_list[end]:
            num_list[start], num_list[end] = num_list[end], num_list[start] # Swapping elements

        if end - start > 1: # This means if (list size > 2)
            one_third: int = (end - start + 1) // 3
            SortingAlgorithms.sootage_sort(num_list, start, end - one_third)
            SortingAlgorithms.sootage_sort(num_list, start + one_third, end)
            SortingAlgorithms.sootage_sort(num_list, start, end - one_third)

    def bozo_sort(num_list) -> None:
        """ In Bozo Sort; firstly, the program checks if the list is sorted. If not, it selects two random
        items and swaps them. Then, it checks again if the list is sorted. The program repeates this process
        until the list is sorted. """

        b: bool = SortingAlgorithms.is_sorted(num_list)
        length_minus_one: int = len(num_list) - 1
        index1: int
        index2: int

        while not b:
            while True:
                index1 = randint(0, length_minus_one)
                index2 = randint(0, length_minus_one)

                if index1 != index2:
                    break

            num_list[index1], num_list[index2] = num_list[index2], num_list[index1] # Swapping elements
            b = SortingAlgorithms.is_sorted(num_list)

    def bogo_sort(num_list) -> None:
        """ In Bogo Sort; firstly, the program checks if the list is sorted. If not, it shuffels the list and
        checks again if the list is sorted. The program repeates this process until the list is sorted. """

        b: bool = SortingAlgorithms.is_sorted(num_list)

        while not b:
            shuffle(num_list)
            b = SortingAlgorithms.is_sorted(num_list)

    if __name__ == "__main__":
        main.Main.main()
