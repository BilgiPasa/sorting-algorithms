list_in_text = input("Write me an integer list (split the numbers with comma): ")
list_in_string_list = list_in_text.split(",")
the_list = [0] * len(list_in_string_list)

for i in range(0, len(list_in_string_list)):
    the_list[i] = int(list_in_string_list[i].strip())

def sort(int_list):
    what_it_looked : int = 0
    smallest : int
    temp : int

    for a in range(0, len(int_list)):
        smallest = int_list[a]

        for i in range(a, len(int_list)):
            if smallest >= int_list[i]:
                smallest = int_list[i]
                what_it_looked = i

        temp = int_list[a]
        int_list[a] = int_list[what_it_looked]
        int_list[what_it_looked] = temp

    return int_list

the_list = sort(the_list)
print("[" + ", ".join(str(x) for x in the_list) + "]")
