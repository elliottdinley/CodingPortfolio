def capital_indexes(word):
    capindex = []
    for i in range(len(word)):
        if word[i].isupper():
            capindex.append(i)
    return capindex

print(capital_indexes(input("Enter word >")))
