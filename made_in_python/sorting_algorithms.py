from random import randint, shuffle

# The input exceptions are handled at the main.py file.
# So, these functions are assuming that the parameter inputs are non-negative integers or integer lists.

def is_sorted(num_list: list[int]) -> bool: # To check if the list is sorted
    for i in range(1, len(num_list)):
        if num_list[i - 1] > num_list[i]:
            return False

    return True

# The algorithms are listed from the fastest to the slowest according to my tests.

def quick_sort(num_list: list[int], start: int, end: int) -> None:
    if end <= start:
        return

    pivot: int = move_elements_and_return_pivot(num_list, start, end)
    quick_sort(num_list, start, pivot - 1)
    quick_sort(num_list, pivot + 1, end)

def move_elements_and_return_pivot(num_list: list[int], start: int, end: int) -> int: # For Quick Sort
    # Note: The initial pivot is the num_list[start] element.

    i: int = start
    j: int = end + 1
    # Initially, i and j are at the points where they shouldn't be. But no problem occurs.
    # Because, we do i += 1 and j -= 1 in the while loops before the if statements execute.

    # Each iteration, the elements that are smaller than or equal to the pivot are moved to the left...
    # ...and the elements that are bigger than the pivot are moved to the right.
    while True:
        while True:
            i += 1 # I can't do ++i in Python.

            if not (num_list[i] <= num_list[start]) or i == end:
                break

        while True:
            j -= 1 # I can't do --j in Python.

            if not (num_list[start] < num_list[j]) or j == start:
                break

        if j <= i:
            break

        num_list[i], num_list[j] = num_list[j], num_list[i] # Swapping elements

    # Swapping the initial pivot with the new pivot and returning the new pivot
    num_list[start], num_list[j] = num_list[j], num_list[start]
    return j

def merge_sort(num_list: list[int]) -> None:
    temp: list[int] = [0] * len(num_list) # Making a new list because we need to store the elements that we want to sort
    merge_sort_range(num_list, temp, 0, len(num_list) - 1)

def merge_sort_range(num_list: list[int], temp: list[int], start: int, end: int) -> None: # For Merge Sort
    if end <= start:
        return

    mid: int = start + (end - start) // 2
    merge_sort_range(num_list, temp, start, mid)
    merge_sort_range(num_list, temp, mid + 1, end)
    merge(num_list, temp, start, mid, end)

def merge(num_list: list[int], temp: list[int], start: int, mid: int, end: int) -> None: # For Merge Sort
    i: int

    # Copying some part of the num_list to temp
    for i in range(start, end + 1): # end + 1 to make the end included
        temp[i] = num_list[i]

    i = start
    k: int = start
    j: int = mid + 1

    # Putting the values in sorted order
    while i <= mid and j <= end:
        if temp[i] <= temp[j]:
            num_list[k] = temp[i]
            k += 1
            i += 1
        else:
            num_list[k] = temp[j]
            k += 1
            j += 1

    # Putting the leftover elements
    while i <= mid:
        num_list[k] = temp[i]
        k += 1
        i += 1

    # Putting the leftover elements
    while j <= mid:
        num_list[k] = temp[j]
        k += 1
        j += 1

def shell_sort(num_list: list[int]) -> None:
    interval: int = 1
    temp: int
    j: int

    # Initializing the interval to 3n + 1 where 3n + 1 is smaller than the list length
    while interval < len(num_list) // 3:
        interval = (interval * 3) + 1

    while interval >= 1:
        for i in range(interval, len(num_list)):
            temp = num_list[i]
            j = i

            while j >= interval and num_list[j - interval] > temp:
                num_list[j] = num_list[j - interval]
                j -= interval

            num_list[j] = temp

        interval //= 3 # Making the interval smaller

def insertion_sort(num_list: list[int]) -> None:
    temp: int
    j: int

    for i in range(1, len(num_list)):
        temp = num_list[i]
        j = i

        while j >= 1 and num_list[j - 1] > temp:
            num_list[j] = num_list[j - 1]
            j -= 1

        num_list[j] = temp

def selection_sort(num_list: list[int]) -> None:
    length_minus_one: int = len(num_list) - 1
    j: int

    for i in range(length_minus_one):
        j = index_of_min(num_list, len(num_list), i) # Finding the index that has the minimum value
        num_list[i], num_list[j] = num_list[j], num_list[i] # Swapping elements

# Finds the index that has the minimum value in the list.
def index_of_min(num_list: list[int], length: int, start: int) -> int: # For Selection Sort
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

        for i in range(1, length):
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

    if end - start > 1: # if list size > 2
        one_third: int = (end - start + 1) // 3
        sootage_sort(num_list, start, end - one_third)
        sootage_sort(num_list, start + one_third, end)
        sootage_sort(num_list, start, end - one_third)

def bozo_sort(num_list: list[int]) -> None:
    length_minus_one: int = len(num_list) - 1
    index1: int
    index2: int

    # Selects 2 random numbers in the list and swaps them until the list is sorted.
    while not is_sorted(num_list):
        index1 = randint(0, length_minus_one)
        index2 = randint(0, length_minus_one)
        num_list[index1], num_list[index2] = num_list[index2], num_list[index1] # Swapping elements

def bogo_sort(num_list: list[int]) -> None:
    # Shuffles the whole list until it is sorted.
    while not is_sorted(num_list):
        shuffle(num_list)
