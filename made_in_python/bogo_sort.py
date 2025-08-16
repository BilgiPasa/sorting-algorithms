from random import randint
from time import time
from random import shuffle

the_list = [0] * 11 # Array size that bigger than 11 takes a looong time to sort.

for i in range(len(the_list)): # Python's integer is 64 bit. Becuz of that I made the randomizer like this.
    the_list[i] = randint(-2147483648, 2147483647 - 1) # -1 becuz the endpoint is included

def sort(number_list):
    """ In Bogo Sort; firstly, the program checks if the array is sorted. If not, it shuffels the array and
    checks again if the array is sorted. The program repeates this process until the array is sorted. """

    i: int
    b: bool = True

    for i in range(1, len(number_list)): # Cheking if the array is sorted
        if number_list[i - 1] > number_list[i]:
            b = False
            break

    while not b:
        b = True
        shuffle(number_list)

        for i in range(1, len(number_list)): # Cheking if the array is sorted
            if number_list[i - 1] > number_list[i]:
                b = False
                break

start_time: float = time()
sort(the_list)
end_time: float = time()
#print("[" + ", ".join(str(x) for x in the_list) + "]") # To see the array
print((str)(len(the_list)) + " integers sorted in " + (str)((end_time - start_time) * 1000) + " milliseconds.")
