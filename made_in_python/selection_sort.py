from random import randint
from time import time

the_list: int = [0] * 10000

for i in range(0, len(the_list)): # Python's integer is 64 bit. Becuz of that I made the randomizer like this.
    the_list[i] = randint(-2147483648, 2147483647 - 1) # -1 becuz the endpoint is included

def sort(int_list):
    smallest: int

    for a in range(0, len(int_list) - 1):
        smallest = a

        for i in range(a, len(int_list)):
            if int_list[smallest] > int_list[i]:
                smallest = i

        int_list[a], int_list[smallest] = int_list[smallest], int_list[a] # Swapping

    return int_list

start_time: float = time()
the_list = sort(the_list)
end_time: float = time()
#print("[" + ", ".join(str(x) for x in the_list) + "]") # To see the array
print((str)(len(the_list)) + " integers sorted in " + (str)((end_time - start_time) * 1000) + " milliseconds.")
