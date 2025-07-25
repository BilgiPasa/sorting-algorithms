from random import randint
from time import time

the_list = [0] * 120000

for i in range(len(the_list)): # Python's integer is 64 bit. Becuz of that I made the randomizer like this.
    the_list[i] = randint(-2147483648, 2147483647 - 1) # -1 becuz the endpoint is included

def sort(number_list):
    """ You can think Cocktail Shaker Sort as double sided Bubble Sort. Cocktail Shaker Sort starts from the
    left side and moves to right like Bubble Sort but when it reaches the end, it moves to left. So the
    Cocktail Shaker Sort moves back and forth and swaps the elements if the left element is bigger than the
    right element. While swapping the elements, the smaller elements move to the left side and the bigger
    elements move to the right side. """

    start: int = 0
    end: int = len(number_list) - 1
    i: int

    while end - start > 1:
        for i in range(start, end):
            if number_list[i] > number_list[i + 1]:
                number_list[i], number_list[i + 1] = number_list[i + 1], number_list[i]

        end -= 1

        for i in range(end, start, -1):
            if number_list[i - 1] > number_list[i]:
                number_list[i - 1], number_list[i] = number_list[i], number_list[i - 1]

        start += 1

start_time: float = time()
sort(the_list)
end_time: float = time()
#print("[" + ", ".join(str(x) for x in the_list) + "]") # To see the array
print((str)(len(the_list)) + " integers sorted in " + (str)((end_time - start_time) * 1000) + " milliseconds.")
