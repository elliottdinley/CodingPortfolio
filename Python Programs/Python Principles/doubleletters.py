def double_letters(word):
    check = 0
    temp = 0
    for i in range(len(word)):
        if i != 0:
            if word[i] == word[i-1]:
                return True
    return False

print(double_letters(input("Enter word >")))
