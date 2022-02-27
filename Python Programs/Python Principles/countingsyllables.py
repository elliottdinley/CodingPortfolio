def count(word):
    countsyl = 0
    for x in word:
        if x == "-":
            countsyl += 1
    countsyl += 1
    return countsyl

print(count(input("Enter word >")))
