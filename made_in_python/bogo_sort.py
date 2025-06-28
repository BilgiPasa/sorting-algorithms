from random import randint
from time import time

the_list: int = [0] * 12 # 12 is more than enough to show how much BogoSort is bad at sorting.

for i in range(0, len(the_list)): # Python's integer is 64 bit. Becuz of that I made the randomizer like this.
    the_list[i] = randint(-2147483648, 2147483647 - 1) # -1 becuz the endpoint is included

def sort(int_list):
    b: bool = True

    for i in range(0, len(int_list) - 1):
        if int_list[i] > int_list[i + 1]:
            b = False
            break

    if not b:
        bogo_sorted_list: int = [0] * len(int_list)

        while not b:
            b = True
            a: int = 0
            temp: int = 0
            did_i_use_this_element_for_selecting_randomly_array: bool = [False] * len(int_list)

            while a < len(int_list):
                temp = randint(0, len(int_list) - 1)

                if not did_i_use_this_element_for_selecting_randomly_array[temp]:
                    bogo_sorted_list[a] = int_list[temp]
                    did_i_use_this_element_for_selecting_randomly_array[temp] = True
                    a += 1

            for i in range(0, len(int_list) - 1):
                if bogo_sorted_list[i] > bogo_sorted_list[i + 1]:
                    b = False
                    break

        return bogo_sorted_list
    else:
        return int_list

start: float = time()
the_list = sort(the_list)
end: float = time()
#print("[" + ", ".join(str(x) for x in the_list) + "]") # To see the array
print((str)(len(the_list)) + " integers sorted in " + (str)(end - start) + " seconds.")
