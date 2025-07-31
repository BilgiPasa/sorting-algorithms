from random import randint
from time import time

the_list = [0] * 12345678

for i in range(len(the_list)): # Python's integer is 64 bit. Becuz of that I made the randomizer like this.
    the_list[i] = randint(-2147483648, 2147483647 - 1) # -1 becuz the endpoint is included

def merge(number_list, left_list, right_list):
    i: int = 0
    j: int = 0
    k: int = 0

    while i < len(left_list) and j < len(right_list):
        if left_list[i] > right_list[j]:
            number_list[k] = right_list[j]
            k += 1
            j += 1
        else:
            number_list[k] = left_list[i]
            k += 1
            i += 1

    while i < len(left_list):
        number_list[k] = left_list[i]
        k += 1
        i += 1

    while j < len(right_list):
        number_list[k] = right_list[j]
        k += 1
        j += 1

def sort(number_list):
    if len(number_list) < 2:
        return

    middle: int = len(number_list) // 2
    i: int
    left_list = [0] * middle
    right_list = [0] * (len(number_list) - middle)

    for i in range(middle):
        left_list[i] = number_list[i]

    for i in range(middle, len(number_list)):
        right_list[i - middle] = number_list[i]

    sort(left_list)
    sort(right_list)
    merge(number_list, left_list, right_list)

start_time: float = time()
sort(the_list)
end_time: float = time()
#print("[" + ", ".join(str(x) for x in the_list) + "]") # To see the array
print((str)(len(the_list)) + " integers sorted in " + (str)((end_time - start_time) * 1000) + " milliseconds.")
