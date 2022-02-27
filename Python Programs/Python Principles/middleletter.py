def mid(word):
    length = len(word)
    if length % 2 == 0:
        return ""
    else:
        return word[length // 2]

print(mid(input("Enter word >")))
