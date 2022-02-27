def is_anagram(x, y):
    if sorted(x) == sorted(y):
        return True

    return False

a = input("1 >")
b = input("2 >")
print(is_anagram(a, b))
