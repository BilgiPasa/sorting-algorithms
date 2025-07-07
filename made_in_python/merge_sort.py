from random import randint
from time import time

the_list = [0] * 10000

for i in range(0, len(the_list)): # Python's integer is 64 bit. Becuz of that I made the randomizer like this.
    the_list[i] = randint(-2147483648, 2147483647 - 1) # -1 becuz the endpoint is included

def merge(int_list, left_list, right_list):
    i: int = 0
    j: int = 0
    k: int = 0

    while i < len(left_list) and j < len(right_list):
        if left_list[i] > right_list[j]:
            int_list[k] = right_list[j]
            k += 1
            j += 1
        else:
            int_list[k] = left_list[i]
            k += 1
            i += 1

    while i < len(left_list):
        int_list[k] = left_list[i]
        k += 1
        i += 1

    while j < len(right_list):
        int_list[k] = right_list[j]
        k += 1
        j += 1

def sort(int_list):
    if len(int_list) < 2:
        return

    middle: int = len(int_list) // 2
    left_list = [0] * middle
    right_list = [0] * (len(int_list) - middle)

    for i in range(0, middle):
        left_list[i] = int_list[i]

    for a in range(middle, len(int_list)):
        right_list[a - middle] = int_list[a]

    sort(left_list)
    sort(right_list)
    merge(int_list, left_list, right_list)

start_time: float = time()
sort(the_list)
end_time: float = time()
#print("[" + ", ".join(str(x) for x in the_list) + "]") # To see the array
print((str)(len(the_list)) + " integers sorted in " + (str)((end_time - start_time) * 1000) + " milliseconds.")
