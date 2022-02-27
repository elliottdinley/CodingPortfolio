def palindrome(word):
    check = True
    for i in range(len(word)):
        if word[i] != word[-(i+1)]:
            check = False
    return check

print(palindrome(input("Enter word >")))
