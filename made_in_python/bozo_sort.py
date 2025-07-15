from random import randint
from time import time

the_list = [0] * 12 # 12 is enough to show how much Bozo Sort is bad at sorting.

for i in range(len(the_list)): # Python's integer is 64 bit. Becuz of that I made the randomizer like this.
    the_list[i] = randint(-2147483648, 2147483647 - 1) # -1 becuz the endpoint is included

def sort(number_list):
    i: int
    b: bool = True

    for i in range(1, len(number_list)): # Cheking if the array is sorted
        if number_list[i - 1] > number_list[i]:
            b = False
            break

    if b:
        return

    index1: int
    index2: int

    while not b:
        b = True

        while True:
            index1 = randint(0, len(number_list) - 1)
            index2 = randint(0, len(number_list) - 1)

            if not index1 == index2:
                break

        number_list[index1], number_list[index2] = number_list[index2], number_list[index1] # Swapping elements

        for i in range(1, len(number_list)): # Cheking if the array is sorted
            if number_list[i - 1] > number_list[i]:
                b = False
                break

start_time: float = time()
sort(the_list)
end_time: float = time()
#print("[" + ", ".join(str(x) for x in the_list) + "]") # To see the array
print((str)(len(the_list)) + " integers sorted in " + (str)((end_time - start_time) * 1000) + " milliseconds.")
