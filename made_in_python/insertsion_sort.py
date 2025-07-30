from random import randint
from time import time

the_list = [0] * 120000

for i in range(len(the_list)): # Python's integer is 64 bit. Becuz of that I made the randomizer like this.
    the_list[i] = randint(-2147483648, 2147483647 - 1) # -1 becuz the endpoint is included

def sort(number_list):
    """ In Insertsion Sort; the program checks at the array multiple times part by part as first 2 elements,
    first 3 elements, first 4 ... and all of the elements. In each checking, the program goes through each part
    starting from the second to last element of the part and goes to the first element. If the element that the
    program is checking is bigger than the last element of the part, it moves the last element of the part in
    front of the element that program is checking. This goes on like that until all of the elements are checked.
    """

    temp: int

    for i in range(1, len(number_list)):
        for j in range(i - 1, -1, -1): # j starts with i - 1 and ends with 0 (included) while going back 1 step
            if number_list[i] < number_list[j]:
                temp = number_list[i]

                for k in range(i, j, -1):
                    number_list[k] = number_list[k - 1]

                number_list[j] = temp

start_time: float = time()
sort(the_list)
end_time: float = time()
#print("[" + ", ".join(str(x) for x in the_list) + "]") # To see the array
print((str)(len(the_list)) + " integers sorted in " + (str)((end_time - start_time) * 1000) + " milliseconds.")
