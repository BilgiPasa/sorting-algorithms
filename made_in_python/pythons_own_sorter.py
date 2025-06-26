list_in_text = input("Write me an integer list (split the numbers with comma): ")
list_in_string_list = list_in_text.split(",")
the_list = [0] * len(list_in_string_list)

for i in range(0, len(list_in_string_list)):
    the_list[i] = int(list_in_string_list[i].strip())

the_list = sorted(the_list)
print("[" + ", ".join(str(x) for x in the_list) + "]")
