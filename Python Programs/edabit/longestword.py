def longest_word_length(sentence):
    count = 0
    longest = 0
    for x in sentence:
        if x != " ":
            count += 1
            if count > longest:
               longest = count
        else:
            count = 0

    return longest

def get_longest_word(sentence):
    wordlist = []
    temp = ""
    sentence += " "
    for x in sentence:
        if x != " ":
            temp += x
        else:
            wordlist.append(temp)
            temp = ""

    wordlist.sort(reverse=True, key=len)
    return wordlist[0]

a = input()

print(get_longest_word(a))
print(longest_word_length(a))
