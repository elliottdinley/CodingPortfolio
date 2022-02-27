def only_ints(x, y):
    if str(x).isnumeric() and str(y).isnumeric():
        return True
    return False

a = input("1 >")
b = input("2 >")
print(only_ints(a, b))
