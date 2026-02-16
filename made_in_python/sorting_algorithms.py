from random import randint, shuffle
import main

def is_sorted(num_arr) -> bool: # To check if the array is sorted
    for i in range(1, len(num_arr)):
        if num_arr[i - 1] > num_arr[i]:
            return False

    return True

# The algorithms are listed from the fastest to the slowest according to my tests.

def quick_sort(num_arr, start: int, end: int) -> None:
    if start >= end:
        return

    pivot: int = move_elements_and_return_pivot(num_arr, start, end)
    quick_sort(num_arr, start, pivot - 1)
    quick_sort(num_arr, pivot + 1, end)

def move_elements_and_return_pivot(num_arr, start: int, end: int) -> int: # This is for Quick Sort
    i: int = start - 1

    for j in range(start, end): # Initial pivot is the last element of the array
        # The program moves the elements that are smaller than the pivot to the left
        if num_arr[j] < num_arr[end]:
            i += 1
            num_arr[i], num_arr[j] = num_arr[j], num_arr[i] # Swapping elements

    i += 1
    num_arr[i], num_arr[end] = num_arr[end], num_arr[i] # Swapping elements
    return i # Swapped the initial pivot with the new pivot and returning the new pivot

def merge_sort(num_arr) -> None:
    if len(num_arr) < 2:
        return

    middle: int = len(num_arr) // 2
    i: int
    left_arr = [0] * middle
    right_arr = [0] * (len(num_arr) - middle)

    for i in range(middle):
        left_arr[i] = num_arr[i]

    for i in range(middle, len(num_arr)):
        right_arr[i - middle] = num_arr[i]

    merge_sort(left_arr)
    merge_sort(right_arr)
    merge(num_arr, left_arr, right_arr)

def merge(num_arr, left_arr, right_arr) -> None: # This is for Merge Sort
    j: int = 0
    k: int = 0

    for i in range(len(num_arr)):
        if j >= len(left_arr):
            num_arr[i] = right_arr[k]
            k += 1
        elif k >= len(right_arr):
            num_arr[i] = left_arr[j]
            j += 1
        else:
            if left_arr[j] < right_arr[k]:
                num_arr[i] = left_arr[j]
                j += 1
            else:
                num_arr[i] = right_arr[k]
                k += 1

def shell_sort(num_arr) -> None:
    interval: int = len(num_arr) // 2
    temp: int
    j: int

    while interval > 0:
        for i in range(interval, len(num_arr)):
            temp = num_arr[i]
            j = i

            while j >= interval and num_arr[j - interval] > temp:
                num_arr[j] = num_arr[j - interval]
                j -= interval

            num_arr[j] = temp
        interval = interval // 2

def insertsion_sort(num_arr) -> None:
    temp: int
    j: int

    for i in range(1, len(num_arr)):
        temp = num_arr[i]
        j = i - 1

        while j >= 0 and num_arr[j] > temp:
            num_arr[j + 1] = num_arr[j]
            j -= 1

        num_arr[j + 1] = temp

def selection_sort(num_arr) -> None:
    length_minus_one: int = len(num_arr) - 1
    j: int

    for i in range(length_minus_one):
        j = index_of_min(num_arr, len(num_arr), i)
        num_arr[i], num_arr[j] = num_arr[j], num_arr[i] # Swapping elements

def index_of_min(num_arr, length: int, start: int) -> None: # This is for Selection Sort
    min: int = start

    for i in range(start, length):
        if num_arr[min] > num_arr[i]:
            min = i

    return min

def gnome_sort(num_arr) -> None:
    i: int = 1

    while i < len(num_arr):
        if i > 0 and num_arr[i - 1] > num_arr[i]:
            num_arr[i - 1], num_arr[i] = num_arr[i], num_arr[i - 1] # Swapping elements
            i -= 1
        else:
            i += 1

def cocktail_shaker_sort(num_arr) -> None:
    start: int = 0
    end: int = len(num_arr) - 1
    i: int

    while end - start > 1:
        for i in range(start, end):
            if num_arr[i] > num_arr[i + 1]:
                num_arr[i], num_arr[i + 1] = num_arr[i + 1], num_arr[i] # Swapping elements

        end -= 1

        for i in range(end, start, -1):
            if num_arr[i - 1] > num_arr[i]:
                num_arr[i - 1], num_arr[i] = num_arr[i], num_arr[i - 1] # Swapping elements

        start += 1

def bubble_sort(num_arr) -> None:
    length: int = len(num_arr)
    swapped: bool

    while True:
        swapped = False

        for i in range(1, length):
            if num_arr[i - 1] > num_arr[i]:
                num_arr[i - 1], num_arr[i] = num_arr[i], num_arr[i - 1] # Swapping elements
                swapped = True

        length -= 1

        if not swapped:
            break

def sootage_sort(num_arr, start: int, end: int) -> None:
    if start == end:
        return

    if num_arr[start] > num_arr[end]:
        num_arr[start], num_arr[end] = num_arr[end], num_arr[start] # Swapping elements

    if end - start > 1: # This means if array size > 2
        one_third: int = (end - start + 1) // 3
        sootage_sort(num_arr, start, end - one_third)
        sootage_sort(num_arr, start + one_third, end)
        sootage_sort(num_arr, start, end - one_third)

def bozo_sort(num_arr) -> None:
    length_minus_one: int = len(num_arr) - 1
    index1: int
    index2: int

    while not is_sorted(num_arr):
        index1 = randint(0, length_minus_one)
        index2 = randint(0, length_minus_one)
        num_arr[index1], num_arr[index2] = num_arr[index2], num_arr[index1] # Swapping elements

def bogo_sort(num_arr) -> None:
    while not is_sorted(num_arr):
        shuffle(num_arr)

if __name__ == "__main__":
    main.main()
