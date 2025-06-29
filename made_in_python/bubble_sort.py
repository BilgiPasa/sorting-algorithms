from random import randint
from time import time

the_list: int = [0] * 10000000

for i in range(0, len(the_list)): # Python's integer is 64 bit. Becuz of that I made the randomizer like this.
    the_list[i] = randint(-2147483648, 2147483647 - 1) # -1 becuz the endpoint is included

def sort(int_list):
    b: bool = True

    while not b:
        b = True

        for i in range(0, len(int_list) - 1):
            if int_list[i] > int_list[i + 1]:
                int_list[i], int_list[i + 1] = int_list[i + 1], int_list[i] # Swapping elements

        for i in range(0, len(int_list) - 1):
            if int_list[i] > int_list[i + 1]:
                b = False
                break

    return int_list

start_time: float = time()
the_list = sort(the_list)
end_time: float = time()
#print("[" + ", ".join(str(x) for x in the_list) + "]") # To see the array
print((str)(len(the_list)) + " integers sorted in " + (str)((end_time - start_time) * 1000000000) + " nanoseconds.")
